using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class GetBestRunsTester : BaseDataAccessTester
    {
        private readonly AthleteBuilder _athleteBuilder;

        public GetBestRunsTester()
        {
            _athleteBuilder = new AthleteBuilder();

            _testRunStart = new DateTime(2008, 1, 1);

            MemoryDataContext.Clear();
            _athlete = _athleteBuilder.Build();
            InsertRuns(_athlete);

        }

        private DateTime _testRunStart;
        private Athlete _athlete;

        void InsertRuns(Athlete athlete)
        {
            for (int i = 0; i < 10; i++)
            {
                var run =
                    new Run
                        {
                            Athlete = athlete,
                            Distance = i,
                            Start = _testRunStart,
                            Time = 1
                        };
                _testRunStart = _testRunStart.AddDays(7);
                MemoryDataContext.InsertOnSubmit(run);
            }
            MemoryDataContext.Commit();
        }

        [Test]
        public void AssertReturnsRunsWithinDistanceRange()
        {

            const int maximum = 7;
            const int minimum = 5;

            var runsQuery =
                new BestRunsQuery
                    {
                        Athlete = _athlete,
                        DistanceMaximum = maximum,
                        DistanceMinimum = minimum,
                        NumberOfRunsToFetch = 10
                    };

            Assert.DoesNotThrow(runsQuery.EnsureQueryValid);

            var runDataAccess = new RunDataAccess();
            var bestRunsQuery = runDataAccess.GetBestRuns(runsQuery);

            Assert.AreEqual(3, bestRunsQuery.Runs.Count);
            foreach (var run in bestRunsQuery.Runs)
            {
                Assert.IsTrue(run.Distance >= minimum && run.Distance <= maximum);
            }
        }

        [Test]
        public void AssertReturnsRunsWithinDateRange()
        {

            const int maximum = 100;
            const int minimum = 0;

            var runsQuery =
                new BestRunsQuery
                    {
                        Athlete = _athlete,
                        After = new DateTime(2008, 1, 1),
                        Before = new DateTime(2008, 1, 30),
                        DistanceMaximum = maximum,
                        DistanceMinimum = minimum,
                        NumberOfRunsToFetch = 10
                    };

            Assert.DoesNotThrow(runsQuery.EnsureQueryValid);

            var runDataAccess = new RunDataAccess();
            var bestRunsQuery = runDataAccess.GetBestRuns(runsQuery);

            Assert.AreEqual(4, bestRunsQuery.Runs.Count);

        }


    }
}
