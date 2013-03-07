using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using DataService.DataAccess;
using DataService.Model;
using NUnit.Framework;

namespace Unittests
{
    [TestFixture]
    public class RunTester
    {
        private const string _randomFirstNamePrefix = "randomFirstName_";
        private const string _randomLastNamePrefix = "randomLastName_";

        private static void InsertAthleteRuns(Athlete athlete, int numberOfRunsToInsert)
        {
            var r = new RandomProvider();
            using (var db = new DbDataContext())
            {
                var timeMin = 1000;
                var timeMax = 10000;
                var distanceMin = 5000;
                var distanceMax = 12000;
                var dateMin = new DateTime(1920, 1, 1);
                var dateMax = new DateTime(2020, 1, 1);
                var runCountBefore = db.Runs.Count();

                const bool athleteModified = false;
                db.Athletes.Attach(athlete, athleteModified);

                var runs = new List<Run>();
                for (var i = 0; i < numberOfRunsToInsert; i++)
                {
                    var run = new Run
                                  {
                                      Athlete = athlete,
                                      Time = r.Next(timeMin, timeMax),
                                      Distance = r.Next(distanceMin, distanceMax),
                                      Start = r.Next(dateMin, dateMax)
                                  };
                    runs.Add(run);
                    if (runs.Count > 5000)
                    {
                        db.Runs.InsertAllOnSubmit(runs);
                        db.SubmitChanges();
                        runs.Clear();
                    }
                }
                if (runs.Count > 0)
                {
                    db.Runs.InsertAllOnSubmit(runs);
                    db.SubmitChanges();
                    runs.Clear();
                }
                var afterRunsInsertedCount = db.Runs.Count();
                Assert.AreEqual(runCountBefore, afterRunsInsertedCount - numberOfRunsToInsert);
            }
        }


        public List<Athlete> CreateRandomAthletes(int numberOfAthletes)
        {
            var r = new RandomProvider();
            var dateMin = new DateTime(1920, 1, 1);
            var dateMax = new DateTime(2020, 1, 1);
            var athletes = new List<Athlete>();
            using (var db = new DbDataContext())
            {
                var athleteCountBefore = db.Athletes.Count();
                for (var i = 0; i < numberOfAthletes; i++)
                {
                    var firstName = _randomFirstNamePrefix + i;
                    var lastName = _randomLastNamePrefix + i;

                    //var guid = Guid.NewGuid().ToString();
                    var user = new User { Password = "1", UserName = firstName, Roles = "" };

                    var athlete = new Athlete
                                      {
                                          FirstName = firstName,
                                          LastName = lastName,
                                          DateOfBirth = r.Next(dateMin, dateMax),
                                          User = user
                                      };
                    athletes.Add(athlete);
                    db.Users.InsertOnSubmit(user);
                }
                db.SubmitChanges();
                var athleteCountAfter = db.Athletes.Count();
                Assert.AreEqual(numberOfAthletes, athletes.Count);
                Assert.AreEqual(athleteCountAfter, athleteCountBefore + numberOfAthletes);
            }
            return athletes;
        }

        [Test, Category("slow"), Ignore]
        public void InsertOneMillionRandomRuns()
        {
            var numberOfAthletes = 1000;
            var numberOfAthleteRuns = 1000;
            var athletes = CreateRandomAthletes(numberOfAthletes);
            foreach (var athlete in athletes)
            {
                InsertAthleteRuns(athlete, numberOfAthleteRuns);
            }
        }

        [Test, Category("slow"), Ignore]
        public void DeleteRandomUserAthleteAndRuns()
        {
            using (var db = new DbDataContext())
            {
                var athletes = db.Athletes.
                    Where(x => x.FirstName.StartsWith(_randomFirstNamePrefix)).ToList();
                foreach (var athlete in athletes)
                {
                    var runs = db.Runs.Where(x => x.Athlete.Equals(athlete));
                    db.Runs.DeleteAllOnSubmit(runs);
                    db.SubmitChanges(ConflictMode.FailOnFirstConflict);
                    db.Athletes.DeleteOnSubmit(athlete);
                    db.Users.DeleteOnSubmit(athlete.User);
                    db.SubmitChanges();
                }
            }
        }


        [Test, Category("slow"),Ignore]
        public void AssertCanFindRunByRtVersion()
        {
            var db = new DbDataContext();

            var run = db.Runs.ToArray().Where(x => x.RtVersion == 3828904108195053568).Single();
            Assert.NotNull(run);
        }



    }
}