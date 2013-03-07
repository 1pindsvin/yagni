using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class DayOfWeekTester
    {
        [Test]
        public void SubtractShouldFindDifferenceAsInteger()
        {
            var dateTime = new DateTime(2009, 11, 1);
            Assert.AreEqual(DayOfWeek.Sunday, dateTime.DayOfWeek);
            dateTime = dateTime.AddDays(- (int) DayOfWeek.Saturday);
            Assert.AreEqual(DayOfWeek.Monday, dateTime.DayOfWeek);
        }
    }
}
