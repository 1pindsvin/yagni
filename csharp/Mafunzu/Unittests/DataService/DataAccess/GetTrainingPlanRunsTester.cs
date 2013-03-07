using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class GetTrainingPlanRunsTester : BaseDataAccessTester
    {
        [Test]
        public void AssertReturnsRunsForPlan()
        {
            var plan = new TrainingPlanBuilder().WithAthlete();
            for (var i = 0; i < 10; i++)
            {
                var run =
                    new Run {Distance = 1000, TrainingPlanID = plan.ID, Athlete = plan.Athlete};
                MemoryDataContext.InsertOnSubmit(run);
            }
            MemoryDataContext.Commit();
            var runDataAcces = new RunDataAccess();
            var runs = runDataAcces.GetPlannedRuns(plan);

            Assert.AreEqual(10, runs.Count);
        }
    }
}