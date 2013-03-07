using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{

    public class MonthQuery
    {
        private class ActivityByDateComparer : IComparer<DayActivity>
        {
            public int Compare(DayActivity x, DayActivity y)
            {
                return x.Day.CompareTo(y.Day);
            }
        }

        private const int DayRange = 42;

        public MonthQuery()
        {
            DayActivities = new List<DayActivity>();
        }
        public Athlete Athlete { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public bool WeekStartsOnMonday { get; set; }
        public List<DayActivity> DayActivities { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public void BuildDayActivities(IEnumerable<DayActivity> activities)
        {
            var daysWithActivies = activities.OrderBy(x=>x.Day).ToList();
            var dateComparer = new ActivityByDateComparer();
            for (var i = 0; i < DayRange; i++)
            {
                var find = daysWithActivies.BinarySearch(DayActivities[i], dateComparer);
                if (find >= 0)
                {
                    var activity = daysWithActivies[find];
                    daysWithActivies.RemoveAt(find);
                    DayActivities[i] = activity;
                }
            }
        }

        public void BuildEmptyDayActivityList()
        {
            DayActivities.Clear();

            var currentDate = Start;
            for (var i = 0; i < DayRange; i++)
            {
                var activity = new DayActivity { Day = currentDate, ActivityCount = 0 };
                DayActivities.Add(activity);
                currentDate = currentDate.AddDays(1);
            }
        }

        public void CalculateDateRange()
        {
            var startDate = new DateTime(Year, Month, 1);
            var dayOfWeekOffset = (int)startDate.DayOfWeek;
            if (WeekStartsOnMonday)
            {
                dayOfWeekOffset = dayOfWeekOffset == 0 ? (int)DayOfWeek.Saturday : dayOfWeekOffset - 1;
            }

            Start = startDate.AddDays(-dayOfWeekOffset);
            End = Start.AddDays(DayRange-1);
        }
    }
}
