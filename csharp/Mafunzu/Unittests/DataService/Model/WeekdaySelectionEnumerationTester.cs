using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class WeekdaySelectionEnumerationTester
    {
        [Test]
        public void TestEnumeration()
        {
            const int alldaysSelected = ((int)WeekdaySelectionEnumeration.SeventhDayOfWeek * 2) - 1;
            /*
                        var b = new StringBuilder();
                        for (var combinedFlags = 0; combinedFlags <= alldaysSelected; combinedFlags++)
                        {
                            var selection = string.Format( "{0,3} - {1}", combinedFlags, ( (WeekdaySelectionEnumeration)combinedFlags ).ToString( ) );
                            b.AppendLine(selection);
                        }
                        Debug.WriteLine(b.ToString());
            */
            var allDaysActual = ((WeekdaySelectionEnumeration)alldaysSelected).ToString();
            var expected = "FirstDayOfWeek, SecondDayOfWeek, ThirdDayOfWeek, FourthDayOfWeek, FifthDayOfWeek, SixthDayOfWeek, SeventhDayOfWeek";
            Assert.AreEqual(expected, allDaysActual);

            var weekdays =
                WeekdaySelectionEnumeration.FirstDayOfWeek |
                WeekdaySelectionEnumeration.SecondDayOfWeek |
                WeekdaySelectionEnumeration.ThirdDayOfWeek |
                WeekdaySelectionEnumeration.FourthDayOfWeek |
                WeekdaySelectionEnumeration.FifthDayOfWeek |
                WeekdaySelectionEnumeration.SixthDayOfWeek |
                WeekdaySelectionEnumeration.SeventhDayOfWeek;

            Assert.AreEqual(alldaysSelected, (int)weekdays);


            weekdays = weekdays ^ WeekdaySelectionEnumeration.SecondDayOfWeek;
            expected = "FirstDayOfWeek, ThirdDayOfWeek, FourthDayOfWeek, FifthDayOfWeek, SixthDayOfWeek, SeventhDayOfWeek";
            Assert.AreEqual(expected, weekdays.ToString());

            weekdays ^=  WeekdaySelectionEnumeration.SixthDayOfWeek;
            expected = "FirstDayOfWeek, ThirdDayOfWeek, FourthDayOfWeek, FifthDayOfWeek, SeventhDayOfWeek";
            Assert.AreEqual(expected, weekdays.ToString());

        }

    }
}
