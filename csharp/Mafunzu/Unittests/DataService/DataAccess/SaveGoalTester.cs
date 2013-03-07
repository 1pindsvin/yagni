using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class SaveGoalTester : BaseDataAccessTester
    {
        [Test]
        public void WhenGoalIsNewShouldAddInstance()
        {
            var dataAccess = new AthleteDataAccess();
            var athlete = new Athlete { ID = 1 };
            MemoryDataContext.Clear();
            MemoryDataContext.InsertOnSubmit(athlete);
            MemoryDataContext.Commit();
            Assert.AreEqual(0, MemoryDataContext.Queryable<Goal>().Count());

            var goal = new Goal {Athlete = athlete};
            dataAccess.SaveGoal(goal);

            Assert.AreEqual(1, MemoryDataContext.Queryable<Goal>().Count());
        }

        [Test]
        public void WhenGoalExistShouldUpdateExistingGoal()
        {
            var dataAccess = new AthleteDataAccess();
            var athlete = new Athlete { ID = 1 };
            MemoryDataContext.Clear();
            MemoryDataContext.InsertOnSubmit(athlete);
            MemoryDataContext.Commit();
            var goal = new Goal { Athlete = athlete };
            dataAccess.SaveGoal(goal);
            goal.ID = 1;
            Assert.AreEqual(1, MemoryDataContext.Queryable<Goal>().Count());

            dataAccess.SaveGoal(goal);

            Assert.AreEqual(1, MemoryDataContext.Queryable<Goal>().Count());
        }

    }
}
