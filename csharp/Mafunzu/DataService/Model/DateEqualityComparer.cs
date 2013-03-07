using System;
using System.Collections.Generic;

namespace DataService.Model
{
    public class DateEqualityComparer : IEqualityComparer<DateTime>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return x.Year == y.Year && x.Month == y.Month && x.Day == y.Day;
        }

        public int GetHashCode(DateTime obj)
        {
            return obj.Date.GetHashCode();
        }
    }
}