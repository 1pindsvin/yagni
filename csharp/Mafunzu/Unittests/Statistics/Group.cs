using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unittests.Statistics
{
    public class Group<T>
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public IEnumerable<T> Items { get; set; }
        public double PercentageOf { get; set; }
    }
}
