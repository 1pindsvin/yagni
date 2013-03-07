using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class CreatePlannedRunsTester : BaseDataAccessTester
    {

        Goal CreateGoal()
        {
            var goal = new Goal { Distance = 10000 };
            return goal;
        }

        [Test]
        public void AssertInsertPlannedRuns()
        {
            var builder = new AthleteBuilder();

            var athlete = builder.Build();

            var selectedDays = WeekdaySelectionEnumeration.FifthDayOfWeek | WeekdaySelectionEnumeration.SeventhDayOfWeek;

            var trainingPlan = new TrainingPlan
                                   {
                                       Workload = 50,
                                       Goal = CreateGoal(),
                                       Athlete = athlete,
                                       Start = new DateTime(2009, 1, 1),
                                       StartDistance = 2000,
                                       PreferredWeekdays = (int)selectedDays
                                   };

            MemoryDataContext.Clear();
            Assert.IsTrue(MemoryDataContext.IsEmpty);
            MemoryDataContext.InsertOnSubmit(athlete);
            MemoryDataContext.InsertOnSubmit(trainingPlan);
            MemoryDataContext.Commit();

            var runDataAccess = new RunDataAccess();

            runDataAccess.CreateRuns(trainingPlan);

            Assert.AreEqual(47, MemoryDataContext.Queryable<Run>().Count());

        }


        [Test]
        public void AssertDeletesAndInsertsRuns()
        {
            var builder = new AthleteBuilder();

            var athlete = builder.Build();

            var selectedDays = WeekdaySelectionEnumeration.FifthDayOfWeek | WeekdaySelectionEnumeration.SeventhDayOfWeek;


            var trainingPlan = new TrainingPlan
                                   {
                                       ID = 1,
                                       Workload = 50,
                                       Goal = CreateGoal(),
                                       Athlete = athlete,
                                       Start = new DateTime(2009, 1, 1),
                                       StartDistance = 2000,
                                       PreferredWeekdays = (int)selectedDays
                                   };

            MemoryDataContext.Clear();
            Assert.IsTrue(MemoryDataContext.IsEmpty);
            MemoryDataContext.InsertOnSubmit(athlete);
            MemoryDataContext.InsertOnSubmit(trainingPlan);

            var runDataAccess = new RunDataAccess();

            runDataAccess.CreateRuns(trainingPlan);

            Assert.AreEqual(47, MemoryDataContext.Queryable<Run>().Count());

            runDataAccess.CreateRuns(trainingPlan);

            Assert.AreEqual(47, MemoryDataContext.Queryable<Run>().Count());


        }

    }
}