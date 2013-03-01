using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using log4net;

namespace ParsePascalDependencies
{
    internal class AppRunner
    {
        private readonly IFileEnumerator _enumerator;
        private readonly IUnitBuilder _builder;
        private readonly string _path;
        private static readonly ILog Log = LogManager.GetLogger(typeof (AppRunner));
        
        
        public static AppRunner CreateDefault(string path)
        {
            return new AppRunner(path, new FileEnumerator(path, "*.pas"),new UnitBuilder());
        }

        public AppRunner(string path, IFileEnumerator enumerator, IUnitBuilder builder)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path");
            }
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
            _path = path;
        }


        PascalUnit BuildUnit(IEnumerable<string> lines, string path)
        {
            return _builder.Build(path, lines);
        }

        public void RunWithLineStrategy()
        {
            var units = new List<PascalUnit>();
            var files = _enumerator.EnumerateFiles();
            foreach (var path in files)
            {
                var lines = File.ReadAllLines(path);
                units.Add(BuildUnit(lines, path));
            }
        }

        public void Run()
        {
            var regEx = new Regex(Patterns.UsesUnitsPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            var unitNameRegex = new Regex(Patterns.UnitNamePattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var units = new List<PascalUnit>();
            var files = Directory.EnumerateFiles(_path, "*.pas", SearchOption.AllDirectories);

            foreach (var path in files)
            {
                var text = File.ReadAllText(path).Replace(Environment.NewLine, " ");
                var unitName = unitNameRegex.Match(text).Groups[1].Value.Trim();
                if (string.IsNullOrEmpty(unitName))
                {
                    Log.Debug(string.Format("Unitname not found in unit [{0}]", path));
                    continue;
                }
                if (!PascalUnit.IsUnitNameValid(unitName))
                {
                    Log.Debug(string.Format("Unitname could not be resolved [{0}]. Path [{1}]", unitName, path));
                    continue;
                }
                var unit = new PascalUnit(unitName, path);
                units.Add(unit);
                foreach (var match in regEx.Matches(text).Cast<Match>())
                {
                    var matchInParanthetis = match.Groups[1].Value;
                    var parser = new RawoutPutFromRegexMatcParser(matchInParanthetis);
                    unit.AddUnitNames(parser.AsIEnumerable());
                }
            }
            Console.WriteLine("===============================================");
            //PrintAllUnits(units);
            Program.PrintSuspectUses(units);
            Console.Read();
            Console.WriteLine("===============================================");
        }
    }
}