using System;
using System.Collections.Generic;
using System.Linq;

namespace ParsePascalDependencies
{
    internal class PascalUnit
    {
        private class PascalUnitComparer : IEqualityComparer<PascalUnit>
        {
            public bool Equals(PascalUnit x, PascalUnit y)
            {
                return x.UnitNameLowered.Equals(y.UnitNameLowered);
            }

            public int GetHashCode(PascalUnit obj)
            {
                return obj.UnitName.GetHashCode();
            }
        }

        public bool IsValidReference { get; private set; }

        internal static PascalUnit CreateInvalidUnit(string name)
        {
            return new PascalUnit(name) {IsValidReference = false};
        }

        public string UnitNameLowered {
            get { return UnitName.ToLower(); }
        }

        private static readonly PascalUnitComparer UnitComparer = new PascalUnitComparer();

        public IEnumerable<PascalUnit> DeepReferences
        {
            get
            {
                foreach (var pascalUnit in Units)
                {
                    yield return pascalUnit;
                    foreach (var deepRef in pascalUnit.Units.ToList())
                    {
                        if (!deepRef.HasSameUnitNameAs(this))
                        {
                            yield return deepRef;
                        }
                    }
                }
            }
        }

        private bool HasSameUnitNameAs(PascalUnit pascalUnit)
        {
            return UnitNameLowered.Equals(pascalUnit.UnitNameLowered);
        }

        public List<PascalUnit> Units { get; set; }

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

        public string UnitName
        {
            get { return Name; }
        }

        public bool References(PascalUnit other)
        {
            return DistinctUses.Contains(other.Name, UnitNameComparer);
        }


        public bool IsReferencedByUnitName(PascalUnit other)
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