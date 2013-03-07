using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class DataAccessSaveRunTester : BaseDataAccessTester
    {
        [Test]
        public void ShouldSaveRun()
        {
            MemoryDataContext.Clear();
            var e = new RunDataAccess ();

            var athlete = new AthleteBuilder().Build();
            MemoryDataContext.Add(athlete);

            var run = new Run { ID = 0, Athlete = athlete};

            e.SaveRun(run);

            Assert.IsTrue(MemoryDataContext.IsCommited(run));
        }
    }
}
