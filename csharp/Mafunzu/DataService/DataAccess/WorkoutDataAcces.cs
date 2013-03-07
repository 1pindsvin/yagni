using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Garmin;
using DataService.Model;

namespace DataService.DataAccess
{
    public class WorkoutDataAcces
    {
        internal static Func<IDataContext> ResolveDataContext = () => new DataContextAdapter(new DbDataContext());
        private readonly IDataContext _dataContext;
        private const string ActivityNotFound = "Activity not found in xml";

        public WorkoutDataAcces()
        {
            _dataContext = ResolveDataContext();
        }

        public WorkoutDataAcces(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public WorkoutQuery GetWorkouts(WorkoutQuery query)
        {
            var workouts = _dataContext.Queryable<Workout>().Where(x => x.Athlete.Equals(query.Athlete));
            if (query.Before.HasValue)
            {
                workouts = workouts.Where(x => x.Start < query.Before.Value);
            }
            if (query.After.HasValue)
            {
                workouts = workouts.Where(x => x.Start > query.After.Value);
            }
            workouts = workouts.Where
                (
                x => ((WorkoutTypeEnumeration) x.WorkoutType &
                      (WorkoutTypeEnumeration) query.WorkoutTypes) == (WorkoutTypeEnumeration) x.WorkoutType);
            var pager =
                new Pager<Workout>(
                    workouts.OrderBy(x => x.Start),
                    query.PagingData.PageOffset,
                    query.PagingData.PageSize,
                    query.PagingData.RequestsLastPage);
            query.PagingData.PageOffset = pager.PageOffset;
            query.PagingData.TotalCount = pager.TotalCount;
            query.Workouts = workouts.ToList();
            return query;
        }

        public string AddWatchData(string uuencoded, string userID)
        {

            var builder = BuildActivityBuilder(uuencoded);
            builder.Build();
            return AddWatchData(builder, userID);
        }

        internal string AddWatchData(ActivityBuilder activityBuilder, string userID)
        {
            if (!activityBuilder.ContainsActivity)
            {
                return ActivityNotFound;
            }

            try
            {
                using (var dataContext = ResolveDataContext())
                {
                    var userDataAccess = new UserDataAccess(dataContext);
                    var athleteDataAccess = new AthleteDataAccess(dataContext);

                    var athleteID = athleteDataAccess.GetAthlete(userDataAccess.FindByEmail(userID)).ID;

                    activityBuilder.Activity.AthleteID = athleteID;

                    dataContext.InsertOnSubmit(activityBuilder.Activity);

                    Save(activityBuilder.Laps, dataContext);
                    Save(activityBuilder.Tracks, dataContext);
                    Save(activityBuilder.TrackPoints, dataContext);

                    dataContext.Commit();

                    return activityBuilder.Activity.ForeignSystemID;
                }

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            
        }

        public ActivityQuery GetActivities(ActivityQuery query)
        {
            var activities = _dataContext.Queryable<Activity>().Where(x => x.Athlete.Equals(query.Athlete));
            if (query.Before.HasValue)
            {
                activities = activities.Where(x => x.Start < query.Before.Value);
            }
            if (query.After.HasValue)
            {
                activities = activities.Where(x => x.Start > query.After.Value);
            }
            activities = activities.Where(x => x.ActivityType == (int) ActivityType.Running); 
            var pager =
                new Pager<Activity>(
                    activities.OrderBy(x => x.Start),
                    query.PagingData.PageOffset,
                    query.PagingData.PageSize,
                    query.PagingData.RequestsLastPage);
            query.PagingData.PageOffset = pager.PageOffset;
            query.PagingData.TotalCount = pager.TotalCount;
            query.Items = activities.ToList();
            return query;
        }

        private static ActivityBuilder BuildActivityBuilder(string uuencoded)
        {
            var bytes = new UudecodedUnGZipper(uuencoded).UnGZip();
            var xmlRawContent = Encoding.UTF8.GetString(bytes);
            var xmlWithoutNamespaceDeclarations = new XmlSanitizer().Sanitize(xmlRawContent);
            return new ActivityBuilder(xmlWithoutNamespaceDeclarations);
        }

        static void Save<T>(IEnumerable<T> items, IDataContext context) where T : class
        {
            foreach (var item in items)
            {
                context.InsertOnSubmit(item);
            }
        }
    }
}