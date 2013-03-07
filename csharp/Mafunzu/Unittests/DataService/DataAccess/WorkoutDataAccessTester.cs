using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataService.Garmin;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class WorkoutDataAccessTester : BaseDataAccessTester
    {

        private static PagingData BuildUnlimitingPagingData()
        {
            var pagingData =
                new PagingData
                    {
                        PageOffset = 0,
                        PageSize = 100,
                        RequestsLastPage = false
                    };
            return pagingData;
        }

        [Test]
        public void AssertReturnsRequestedWorkouts()
        {
            var athleteBuilder = new AthleteBuilder();
            var athlete = athleteBuilder.Build();

            MemoryDataContext.Clear();
            MemoryDataContext.Add(athlete);

            const int noOfWorkOuts = 10;
            InsertTestWorkouts(athlete, noOfWorkOuts);

            var query =
                new WorkoutQuery
                    {
                        PagingData = BuildUnlimitingPagingData(),
                        Athlete = athlete
                    };

            var workoutDataAcces = new WorkoutDataAcces();

            var workoutQuery = workoutDataAcces.GetWorkouts(query);

            Assert.AreEqual(noOfWorkOuts, workoutQuery.Workouts.Count);
        }

        private void InsertTestWorkouts(Athlete athlete, int noOfWorkouts)
        {
            for (int i = 0; i < noOfWorkouts; i++)
            {
                var workout = new Workout { Athlete = athlete };
                MemoryDataContext.Add(workout);
            }
        }

        private static ActivityBuilder BuildBuilder()
        {
            var withoutNamespaceDeclarationsXml = new XmlSanitizer().Sanitize(TestConstants.RawGarminXmlWith5TrackPoints);
            return new ActivityBuilder(withoutNamespaceDeclarationsXml);
        }

        [Test]
        public void AssertInsertsDataFromActivityBuilder()
        {
            var athleteBuilder = new AthleteBuilder();
            var athlete = athleteBuilder.Build();

            MemoryDataContext.Clear();
            MemoryDataContext.Add(athlete);
            MemoryDataContext.Add(athlete.User);

            var activityBuilder = BuildBuilder();
            activityBuilder.Build();

            var e = new WorkoutDataAcces();

            e.AddWatchData(activityBuilder, athlete.User.UserName);

            Assert.AreEqual(1, MemoryDataContext.Queryable<Activity>().Count());

            Assert.AreEqual(1, MemoryDataContext.Queryable<Lap>().Count());

            Assert.AreEqual(2, MemoryDataContext.Queryable<Track>().Count());

            Assert.AreEqual(5, MemoryDataContext.Queryable<Trackpoint>().Count());

        }



        [Test, Category("slow")]
        public void AssertInsertsDataFromUuencodedText()
        {
            var athleteBuilder = new AthleteBuilder();
            var athlete = athleteBuilder.Build();

            MemoryDataContext.Clear();
            MemoryDataContext.Add(athlete);
            MemoryDataContext.Add(athlete.User);

            var uuencoded = File.ReadAllText("garmin-uuencoded.txt");

            var e = new WorkoutDataAcces();

            e.AddWatchData(uuencoded, athlete.User.UserName);

            Assert.AreEqual(1, MemoryDataContext.Queryable<Activity>().Count());

            Assert.AreEqual(1, MemoryDataContext.Queryable<Lap>().Count());

            Assert.AreEqual(4, MemoryDataContext.Queryable<Track>().Count());
            
            Assert.AreEqual(1004, MemoryDataContext.Queryable<Trackpoint>().Count());

        }


    }
}
