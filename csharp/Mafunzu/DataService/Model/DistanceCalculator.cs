using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class DistanceCalculator
    {
        private double _start;
        private readonly double _progression;

        public DistanceCalculator(int start, double progression)
        {
            _start = start;
            _progression = progression;
        }

        public double Next()
        {
            _start = _start + _start*_progression;
            return _start;
        }
    }
}
