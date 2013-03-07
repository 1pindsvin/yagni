using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class WeekCaculatorTester
    {
        [Test]
        public void ShouldResolveWeekForDistances()
        {
            var progression = .1;
            var endDistance = 8;
            var startDistance = 2;

            var trainer = new Trainer();

            var weeks = trainer.CalculateNumberOfProgressions(startDistance, endDistance, progression);

            Assert.AreEqual(1455, Math.Round(weeks * 100));
        }


    }
}
