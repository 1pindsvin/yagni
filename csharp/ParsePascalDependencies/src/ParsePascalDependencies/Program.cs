using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ParsePascalDependencies
{
    internal class Program
    {
        //internal const String FILE_PATH = "b:/op/AdHoc/Excel/AdoExcel/Unit1.pas";
        private const string OpDir = @"b:\op";

        public static void Main(string[] args)
        {
            var regEx = new Regex(Constants.UsesUnitsPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            var unitNameRegex = new Regex(Constants.UnitNamePattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var units = new List<PascalUnit>();
            var files = Directory.EnumerateFiles(OpDir, "*.pas", SearchOption.AllDirectories);
            const int max = 7;
            foreach (var path in files)
            {
                var text = File.ReadAllText(path).Replace(Environment.NewLine, " ");
                var unitName = unitNameRegex.Match(text).Groups[1].Value.Trim();
                var unit = new PascalUnit(unitName, path);
                units.Add(unit);
                foreach (var match in regEx.Matches(text).Cast<Match>())
                {
                    var matchInParanthetis = match.Groups[1].Value;
                    var parser = new RawoutPutFromRegexMatcParser(matchInParanthetis);
                    unit.AddUnitNames(parser.AsIEnumerable());
                }
                if (units.Count < max)
                {
                    continue;
                }
                break;
            }
            PrintAllUnitNames(units);
            Console.WriteLine("===============================================");
            PrintAllUnits(units);
            Console.Read();
        }

        private static void PrintAllUnits(List<PascalUnit> units)
        {
            var resolver = new DeepReferenceResolver(units);
            resolver.ResolveDependencies();

            foreach (var unit in units)
            {
                var print = String.Format("Unitname: {0}{1}Uses:{1}{2}", unit.UnitName, Environment.NewLine, string.Join("|", unit.DeepReferences.Select(x => x.UnitName)));
                Console.WriteLine(print);
            }

        }

        private static void PrintAllUnitNames(IEnumerable<PascalUnit> units)
        {
            var print = string.Join("|", units.Select(x=>x.UnitNameLowered));
            Console.WriteLine(print);

        }

    }
}