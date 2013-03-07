using System;

namespace DataService.Model
{
    [Flags]
    public enum WeekdaySelectionEnumeration
    {
        None = 0, 
        FirstDayOfWeek = 1, 
        SecondDayOfWeek = 2, 
        ThirdDayOfWeek = 4, 
        FourthDayOfWeek = 8,
        FifthDayOfWeek = 16,
        SixthDayOfWeek = 32,
        SeventhDayOfWeek = 64
    }
}