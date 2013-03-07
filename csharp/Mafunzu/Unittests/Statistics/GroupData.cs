using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unittests.Statistics
{
    public class GroupData
    {
        public string Description { get; set; }
        public double PercentageOfAll
        {
            get { return ToPercentageOf(GlobalCount, GroupCount); }
        }
        public double PercentageOf
        {
            get { return ToPercentageOf(AllGroupsCount, GroupCount); }
        }

        public int GroupCount { get; set; }
        public int AllGroupsCount { get; set; }
        public int GlobalCount { get; set; }

        private static double ToPercentageOf(int all, int segmentOfAll)
        {
            return Convert.ToDouble(segmentOfAll * 100) / all;
        }

    }
}
