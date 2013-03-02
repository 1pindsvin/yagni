using System.Linq;
using System.Collections.Generic;
using System;

namespace ParsePascalDependencies
{
    internal class PascalUnitComparer : IEqualityComparer<PascalUnit>
    {
        public bool Equals(PascalUnit x, PascalUnit y)
        {
            return x.HasSameUnitNameAs(y);
        }

        public int GetHashCode(PascalUnit obj)
        {
            return obj.UnitName.GetHashCode();
        }
    }
}