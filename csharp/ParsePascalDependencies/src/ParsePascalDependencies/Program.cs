using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ParsePascalDependencies
{
    internal class Program
    {
        internal const String FILE_PATH = "b:/op/AdHoc/Excel/AdoExcel/Unit1.pas";
        private const string OP_DIR = "b:/op";

        public static void Main(string[] args)
        {
            var regEx = new Regex(Constants.UsesUnitsPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            var unitNameRegex = new Regex(Constants.UnitNamePattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var units = new List<PascalUnit>();
            var files = Directory.EnumerateFiles(OP_DIR, "*.pas", SearchOption.AllDirectories);
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
                var uses = units.Select(x => string.Join("|", x.DistinctUses));
                var print = string.Join("|", uses);
                Console.WriteLine(print);
                break;
            }
            Console.Read();
        }
    }
}