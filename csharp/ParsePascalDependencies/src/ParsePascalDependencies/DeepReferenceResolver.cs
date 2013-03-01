using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParsePascalDependencies
{
    class DeepReferenceResolver
    {
        private readonly List<PascalUnit> _units;

        public DeepReferenceResolver(List<PascalUnit>  units)
        {
            _units = units;
        }

        IEnumerable<PascalUnit> FindByUnitNamesLowered(IEnumerable<string> unitNamesLowered)
        {
            return unitNamesLowered.Select(unitName => _units.Find(x => x.UnitNameLowered.Equals(unitName)) ?? PascalUnit.CreateInvalidUnit(unitName));
        }

        public void ResolveDependencies()
        {
            foreach (var unit in _units)
            {
                unit.Units = FindByUnitNamesLowered(unit.DistinctUses.Select(x => x.ToLower())).ToList();
            }
        }

    }
}
