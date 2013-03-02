using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace ParsePascalDependencies
{
    internal class AppRunner
    {
        private readonly IFileEnumerator _enumerator;
        private readonly IUnitBuilder _builder;
        private readonly List<PascalUnit> _units;

        public List<PascalUnit> Units
        {
            get { return _units; }
        }

        public static AppRunner CreateDefault(string path, Func<string, bool> unitNameFilter)
        {
            return new AppRunner(new FileEnumerator(path, "*.pas"), new UnitBuilder(unitNameFilter));
        }

        public AppRunner(IFileEnumerator enumerator, IUnitBuilder builder)
        {
            if (enumerator == null)
            {
                throw new ArgumentNullException("enumerator");
            }
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            _enumerator = enumerator;
            _builder = builder;
            _units = new List<PascalUnit>();
        }


        public void BuildPascalUnitsWithReferences()
        {
            BuildPascalUnits();
            var resolver =new DeepReferenceResolver(Units);
            resolver.ResolveDependencies();
        }


        public void BuildPascalUnits()
        {
            Units.Clear();
            var files = _enumerator.EnumerateFiles();
            foreach (var path in files)
            {
                var lines = File.ReadAllLines(path);
                Units.Add(_builder.Build(path, lines));
            }
        }
    }
}