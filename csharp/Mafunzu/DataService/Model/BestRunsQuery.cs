using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public class BestRunsQuery
    {
        public Athlete Athlete { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
        public int DistanceMaximum { get; set; }
        public int DistanceMinimum { get; set; }
        public int NumberOfRunsToFetch { get; set; }
        public List<Run> Runs { get; set; }

        internal bool IsExactDistance
        {
            get { return DistanceMinimum == DistanceMaximum; }
        }

        public void EnsureQueryValid()
        {
            if (Athlete==null)
            {
                throw new InvalidOperationException("Athlete not set");
            }
            if (Before.HasValue && After.HasValue)
            {
                if (After > Before)
                {
                    throw new InvalidOperationException("After > Before");
                }
            }
            if (DistanceMinimum>DistanceMaximum)
            {
                throw new InvalidOperationException("DistanceMinimum>DistanceMaximum");
            }
        }
    }
}
