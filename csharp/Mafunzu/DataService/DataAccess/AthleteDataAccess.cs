using System;
using System.Collections.Generic;
using System.Linq;
using DataService.Model;

namespace DataService.DataAccess
{
    public class AthleteDataAccess
    {
        internal static Func<IDataContext> ResolveDataContext = () => new DataContextAdapter(new DbDataContext());

        public AthleteDataAccess()
        {
            DataContext = ResolveDataContext();
        }

        public AthleteDataAccess(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        private IDataContext DataContext { get; set; }


        public Athlete SaveAthlete(Athlete athlete)
        {
            if (athlete.User == null)
            {
                throw new InvalidOperationException("athlete.User==null");
            }
            if (athlete.User.ID <= 0)
            {
                throw new InvalidOperationException("athlete.User.ID <= 0");
            }
            DataContext.RollbackAndAttach(athlete.User);
            if (athlete.ID > 0)
            {
                UpdateExistingAthlete(ref athlete);
            }
            else
            {
                DataContext.InsertOnSubmit(athlete);
            }
            DataContext.Commit();
            return athlete;
        }

        public void SaveGoal(Goal goal)
        {
            DataContext.RollbackAndAttach(goal.Athlete);
            if (goal.ID > 0)
            {
                DataContext.UpdateAndAttach(goal);
            }
            else
            {
                DataContext.InsertOnSubmit(goal);
            }
            DataContext.Commit();
        }

        public TrainingPlan SaveTrainingPlan(TrainingPlan trainingPlan)
        {
            DataContext.RollbackAndAttach(trainingPlan.Athlete);
            trainingPlan.Goal.Athlete = trainingPlan.Athlete;
            if (trainingPlan.ID > 0)
            {
                DataContext.UpdateAndAttach(trainingPlan.Goal);
                DataContext.UpdateAndAttach(trainingPlan);
            }
            else
            {
                DataContext.InsertOnSubmit(trainingPlan);
            }
            DataContext.Commit();

            var runDataAccess = new RunDataAccess(DataContext);
            runDataAccess.CreateRuns(trainingPlan);

            return trainingPlan;
        }


        public List<TrainingPlan> GetAthleteTrainingPlans(Athlete athlete)
        {
            var plans = DataContext.Queryable<TrainingPlan>().Where(x => x.Athlete.Equals(athlete));
            return plans.ToList();
        }

        private void UpdateExistingAthlete(ref Athlete athlete)
        {
            var athleteID = athlete.ID;
            var existing = DataContext.Queryable<Athlete>().Single(x => x.ID == athleteID);

            var updateHealth =
                !athlete.HasSameHealthAs(existing) && athlete.HealthSnapshot.HasSomeHealthDataSet;

            Athlete.CopyPropertiesExceptVersion(athlete, existing);

            if (updateHealth)
            {
                UpdateHealthHistory(existing);
            }
            athlete = existing;
        }

        private void UpdateHealthHistory(Athlete existingAthlete)
        {
            var athleteHealth = existingAthlete.HealthSnapshot;
            athleteHealth.RegisteredAt = DateTime.Now;
            DataContext.InsertOnSubmit(athleteHealth);
            DataContext.Commit();
        }

        public Athlete GetAthlete(User user)
        {
            var existingAthlete = DataContext.Queryable<Athlete>().Single(athlete => athlete.User.Equals(user));
            return existingAthlete;
        }

        public AthleteHealthQuery GetHealthHistory(AthleteHealthQuery query)
        {
            var healths = DataContext.Queryable<AthleteHealth>().Where(x => x.Athlete.Equals(query.Athlete));
            var pager = new Pager<AthleteHealth>(
                healths,
                query.PagingData.PageOffset,
                query.PagingData.PageSize,
                query.PagingData.RequestsLastPage);

            query.AthleteHealthHistory = pager.GetPagedItems().ToList();
            query.PagingData.TotalCount = pager.TotalCount;
            query.PagingData.PageOffset = pager.PageOffset;
            return query;
        }

        internal IQueryable<AthleteHealth> GetHealthHistory(Athlete athlete)
        {
            return DataContext.Queryable<AthleteHealth>().Where(x => x.AthleteID == athlete.ID);
        }
    }
}