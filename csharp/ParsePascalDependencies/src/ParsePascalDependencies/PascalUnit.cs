using System;
using System.Collections.Generic;
using System.Linq;

namespace ParsePascalDependencies
{
    internal class PascalUnit
    {

        private readonly List<string> _uses;
        private static readonly UnitNameComparer UnitNameComparer = new UnitNameComparer();

        public PascalUnit(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name");
            }
            Name = name;
            _uses = new List<string>();
        }

        public string UnitName {
            get { return Name; }
        }

        public bool References(PascalUnit other)
        {
            return DistinctUses.Contains(other.Name, UnitNameComparer);
        }

        public bool IsReferencedBy(PascalUnit other)
        {
            return other.DistinctUses.Contains(Name, UnitNameComparer);
        }

        public string Name { get; private set; }

        public void AddUses(IEnumerable<string> uses)
        {
            _uses.AddRange(uses);
        }

        public IEnumerable<string> DistinctUses
        {
            get { return _uses.Distinct(UnitNameComparer); }
        }

        public string DistinctUsesToString()
        {
            return "[" + string.Join("|", DistinctUses) + "]";
        }
    }
}