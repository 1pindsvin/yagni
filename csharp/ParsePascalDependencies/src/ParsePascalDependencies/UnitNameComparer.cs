using System;
using System.Collections.Generic;

namespace ParsePascalDependencies
{
    internal class UnitNameComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return String.Compare(x,
                                  y,
                                  StringComparison.OrdinalIgnoreCase) == 0;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}