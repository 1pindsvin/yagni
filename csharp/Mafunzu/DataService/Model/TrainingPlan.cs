using System;
using System.Linq;

namespace DataService.Model
{
    public partial class TrainingPlan
    {
        public ulong RtVersion
        {
            get
            {
                return System.BitConverter.ToUInt64(Version.ToArray(), 0);
            }
            set
            {
                this.Version = System.BitConverter.GetBytes(value);
            }
        }

        public void EnsureIsValid()
        {
            if(!(Goal.Distance > StartDistance))
            {
                throw new InvalidOperationException("Goal.Distance > StartDistance");
            }
            if((WeekdaySelectionEnumeration)PreferredWeekdays==WeekdaySelectionEnumeration.None)
            {
                throw new InvalidOperationException("WeekdaySelectionEnumeration.None");
            }
        }

        internal int NumberOfTrainingDaysPerWeek
        {
            get
            {
                return ToNumberOfDaysPerWeek((WeekdaySelectionEnumeration)PreferredWeekdays);
            }

            set { throw new NotImplementedException(); }
        }

        public static int ToNumberOfDaysPerWeek(WeekdaySelectionEnumeration selection)
        {
            Func<WeekdaySelectionEnumeration, bool> isDaySelected =
                day => day != WeekdaySelectionEnumeration.None && (selection & day) == day;
            var days =
                ((WeekdaySelectionEnumeration[])Enum.GetValues(typeof(WeekdaySelectionEnumeration))).Where(
                    isDaySelected);
            return days.Count();
        }

        public WeekdaySelectionEnumeration DaysAsWeekdaySelectionEnumeration()
        {
            return (WeekdaySelectionEnumeration) PreferredWeekdays;
        }
    }
}