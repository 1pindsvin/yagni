using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class MonthQueryRunsTester : BaseDataAccessTester
    {
        private Athlete _athlete;

        private void InsertDefaultAthlete()
        {
            var user = new User {ID=1, Password = "0", UserName = "Gryffe" };
            MemoryDataContext.InsertOnSubmit(user);
            MemoryDataContext.Commit();

            new UserDataAccess().Save(user);

            _athlete = new Athlete { ID = 0, User = user };

            new AthleteDataAccess().SaveAthlete(_athlete);
        }

        private void InsertPersistentRun(DateTime dateTime)
        {
            var e = new RunDataAccess();
            var run = new Run { ID = 0, Athlete = _athlete, Start = dateTime};
            e.SaveRun(run);
        }

        [Test]
        public void ShouldSetStartAndEndDate()
        {
            var monthQuery = new MonthQuery
            {
                Athlete = _athlete,
                Month = 11,
                WeekStartsOnMonday = true,
                Year = 2009
            };
            monthQuery.CalculateDateRange();

            Assert.AreEqual(new DateTime(2009,10, 26), monthQuery.Start);
            Assert.AreEqual(new DateTime(2009, 12, 6), monthQuery.End);
        }

        [Test]
        public void WhenWeekStartsOnSundayShouldSetStartAndEndDate()
        {
            var monthQuery = new MonthQuery
            {
                Athlete = _athlete,
                Month = 11,
                WeekStartsOnMonday = false,
                Year = 2009
            };
            monthQuery.CalculateDateRange();
            Assert.AreEqual(new DateTime(2009, 11, 1), monthQuery.Start);
            Assert.AreEqual(new DateTime(2009, 12, 12), monthQuery.End);
        }


        [Test]
        public void ShouldReturn42EmptyDayActivities()
        {
            MemoryDataContext.Clear();
            InsertDefaultAthlete();
            Assert.AreEqual(0, MemoryDataContext.Queryable<Run>().Count());
            var e = new RunDataAccess();

            var monthQuery = new MonthQuery
                        {
                            Athlete = _athlete, 
                            Month = 11, 
                            WeekStartsOnMonday = true, 
                            Year = 2009
                        };

            monthQuery = e.GetMonthQuery(monthQuery);

            foreach (var dayActivity in monthQuery.DayActivities)
            {
                Assert.AreEqual(0, dayActivity.ActivityCount);
            }
            Assert.AreEqual(42, monthQuery.DayActivities.Count);
        }

        [Test]
        public void WhenActivitiesExistShouldSetDayActivityCount()
        {
            MemoryDataContext.Clear();
            InsertDefaultAthlete();
            Assert.AreEqual(0, MemoryDataContext.Queryable<Run>().Count());

            var e = new RunDataAccess();

            var monthQuery = new MonthQuery
            {
                Athlete = _athlete,
                Month = 1,
                WeekStartsOnMonday = true,
                Year = 2009
            };
            monthQuery.CalculateDateRange();

            InsertPersistentRun(monthQuery.Start);
            InsertPersistentRun(monthQuery.End);
            InsertPersistentRun(monthQuery.End);


            monthQuery = e.GetMonthQuery(monthQuery);

            Assert.AreEqual(1, monthQuery.DayActivities.First().ActivityCount);
            Assert.AreEqual(2, monthQuery.DayActivities.Last().ActivityCount);
        }

    }
}
