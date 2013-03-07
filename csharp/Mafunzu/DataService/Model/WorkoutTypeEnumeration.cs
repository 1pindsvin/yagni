using System;

namespace DataService.Model
{
    [Flags]
    public enum WorkoutTypeEnumeration
    {
        None = 0,

        Easy = 1, Interval = 2, Recovery = 4, Tempo = 8
    }

}