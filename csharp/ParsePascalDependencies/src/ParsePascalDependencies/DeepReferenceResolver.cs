using System.Collections.Generic;
using System.Linq;

namespace ParsePascalDependencies
{
    internal class DeepReferenceResolver
    {
        private readonly List<PascalUnit> _units;
        private readonly List<PascalUnit> _unitsWithoutPaths;

        public DeepReferenceResolver(List<PascalUnit> units)
        {
            _units = units;
            _unitsWithoutPaths = new List<PascalUnit>();
        }

        private PascalUnit FindOrCreateUnit(string unitName)
        {
            var find = _unitsWithoutPaths.Find(x => x.UnitNameLowered.Equals(unitName.ToLower()));
            if (find == null)
            {
                find = PascalUnit.CreateUnitWithoutPath(unitName);
                _unitsWithoutPaths.Add(find);
            }
            return find;
        }

        private IEnumerable<PascalUnit> FindByUnitNamesLowered(IEnumerable<string> unitNamesLowered)
        {
            foreach (var unitName in unitNamesLowered)
            {
                yield return _units.Find(x => x.UnitNameLowered.Equals(unitName)) ?? FindOrCreateUnit(unitName);
            }
        }

        public void ResolveDependencies()
        {
            foreach (var unit in _units)
            {
                var unitNamesLowered = unit.DistinctUses.Select(x => x.ToLower());
                var pascalUnits = FindByUnitNamesLowered(unitNamesLowered).ToList();
                unit.Units = pascalUnits;
            }
        }
    }
}