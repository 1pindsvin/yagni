using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using DataService.Model;

namespace DataService.DataAccess
{
    public class RunDataAccess
    {
        internal static Func<IDataContext> ResolveDataContext = () => new DataContextAdapter(new DbDataContext());

        private readonly IDataContext _dataContext;
        public RunDataAccess()
        {
            _dataContext = ResolveDataContext();
        }

        public RunDataAccess(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private static IQueryable<Run> GetRuns(IQueryable<Run> queryable, Expression<Func<Run, bool>> expression)
        {
            return queryable.Where(expression);
        }

        private IQueryable<Run> GetUnTrashedRuns()
        {
            var runs =
                _dataContext.Queryable<Run>().Where(
                    run => ((LabelEnumeration)run.Labels & LabelEnumeration.Trash) != LabelEnumeration.Trash);
            return runs;
        }

        public IQueryable<Run> GetRuns(Athlete athlete)
        {
            var runs = GetUnTrashedRuns().Where(run => run.Athlete.Equals(athlete));
            return runs;
        }

        private IQueryable<Run> GetUnTrashedRuns(DateTime start, DateTime end)
        {
            var runs = GetUnTrashedRuns();
            runs = runs.Where(x => x.Start >= start && x.Start <= end);
            return runs;
        }

        public IQueryable<Run> GetRuns(MonthQuery monthQuery)
        {
            var runs = GetUnTrashedRuns(monthQuery.Start, monthQuery.End).Where(x => x.Athlete == monthQuery.Athlete);
            return runs;
        }

        public MonthQuery GetMonthQuery(MonthQuery query)
        {
            query.CalculateDateRange();
            query.BuildEmptyDayActivityList();

            //must convert ToList() groupby syntaks is not supported
            var grouped = GetRuns(query).ToList().GroupBy(x => x.Start.Date, new DateEqualityComparer());
            var activities = grouped.ToList().ConvertAll(x => new DayActivity { ActivityCount = x.Count(), Day = x.Key });
            query.BuildDayActivities(activities);
            return query;
        }

        public List<Run> GetPlannedRuns(TrainingPlan trainingPlan)
        {
            if (trainingPlan.ID <= 0)
            {
                throw new InvalidOperationException("trainingPlan.ID <= 0");
            }
            if (trainingPlan.Athlete == null)
            {
                throw new InvalidOperationException("trainingPlan.Athlete == null");
            }
            return GetRuns(trainingPlan.Athlete).Where(x => x.TrainingPlanID == trainingPlan.ID).ToList();
        }

        private static IEnumerable<Run> GetTopRuns(IEnumerable<Run> runs, int top)
        {
            var count = 0;
            foreach (var run in runs)
            {
                if (count++ >= top)
                {
                    yield break;
                }
                yield return run;
            }
        }

        public BestRunsQuery GetBestRuns(BestRunsQuery query)
        {
            var runs = GetRuns(query.Athlete);

            if (query.Before.HasValue)
            {
                runs = runs.Where(x => x.Start < query.Before.Value);
            }
            if (query.After.HasValue)
            {
                runs = runs.Where(x => x.Start > query.After.Value);
            }
            runs = runs.Where(x => x.Time > 0);
            runs = query.IsExactDistance ?
                runs.Where(x => x.Distance == query.DistanceMinimum) :
                runs.Where(x => x.Distance >= query.DistanceMinimum && x.Distance <= query.DistanceMaximum);

            query.Runs = runs.
                OrderBy(x=>x.Time).
                Take(query.NumberOfRunsToFetch).
                ToList();
            return query;
        }


        public RunsPage GetRuns(RunsPage page)
        {
            var runs = GetRuns(page.Athlete);
            if (page.ByDateTime.HasValue)
            {
                var clientDate = page.ByDateTime.Value.Date;
                var year = clientDate.Year;
                var month = clientDate.Month;
                var day = clientDate.Day;
                runs = runs.Where(run => run.Start.Year == year && run.Start.Month == month && run.Start.Day == day);
            }

            var sortSuffix = page.Ascending ? " asc" : " desc";
            var orderBy = page.OrderByExpression + sortSuffix;
            var pager =
                new Pager<Run>(
                    runs.OrderBy(orderBy),
                    page.Start,
                    page.Page,
                    page.RequestsLastPage);

            page.Runs = pager.GetPagedItems().ToList();
            page.Start = pager.PageOffset;
            page.RunCount = pager.TotalCount;

            return page;
        }

        public Run SaveRun(Run run)
        {
            try
            {
                _dataContext.RollbackAndAttach(run.Athlete);
                if (run.Shoe == null)
                {
                    run.ShoeID = new int?();
                }
                else
                {
                    _dataContext.RollbackAndAttach(run.Shoe);
                }
                if (run.ID > 0)
                {
                    _dataContext.UpdateAndAttach(run);
                }
                else
                {
                    _dataContext.InsertOnSubmit(run);
                }
                _dataContext.Commit();
            }
            catch (ChangeConflictException changeConflictException)
            {
                var message =
                    string.Format(
                        "Error, SaveRun, run ID = {0}, AthleteID = {1}, version [{2}], Fluorineversion [{3}]", run.ID,
                        run.AthleteID, run.Version, run.RtVersion);

                throw new ChangeConflictException(message, changeConflictException);
            }
            return run;
        }


        public Run UndoDeleteRun(Run run)
        {
            var deletedRun = _dataContext.Queryable<Run>().Single(x => x.ID == run.ID);
            var labels = (LabelEnumeration)deletedRun.Labels;
            labels ^= LabelEnumeration.Trash;
            deletedRun.Labels = (int)labels;
            deletedRun.LastChanged = run.LastChanged;
            _dataContext.Commit();
            return deletedRun;
        }

        private void DeleteFuturePlannedRuns(TrainingPlan trainingPlan)
        {
            var runs =
                _dataContext.Queryable<Run>().Where(
                    x => x.TrainingPlan.ID == trainingPlan.ID && x.Start >= trainingPlan.Start);
            foreach (var run in runs)
            {
                _dataContext.DeleteOnSubmit(run);
            }
            _dataContext.Commit();
        }

        public void CreateRuns(TrainingPlan trainingPlan)
        {
            var existingPlan = _dataContext.GetExisting(trainingPlan);
            var existingAthlete = _dataContext.GetExisting(trainingPlan.Athlete);

            DeleteFuturePlannedRuns(existingPlan);

            var trainer = new Trainer();
            var runs = trainer.CreateRuns(existingAthlete, existingPlan);
            foreach (var run in runs)
            {
                run.Athlete = existingAthlete;
                run.TrainingPlan = existingPlan;
                run.LastChanged = DateTime.Now;
                _dataContext.InsertOnSubmit(run);
            }
            _dataContext.Commit();
        }


    }
}