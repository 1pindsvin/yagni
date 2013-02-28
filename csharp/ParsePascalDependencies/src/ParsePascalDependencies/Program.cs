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
            const string pattern = @"\s+uses\b(.+?)\;";
            var regEx = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            var units = new List<PascalUnit>();
            var files = Directory.EnumerateFiles(OP_DIR, "*.pas", SearchOption.AllDirectories);
            const int max = 7;
            foreach (var file in files)
            {
                var text = File.ReadAllText(file).Replace(Environment.NewLine, " ");
                var unit = new PascalUnit(file);
                units.Add(unit);
                foreach (var match in regEx.Matches(text).Cast<Match>())
                {
                    var matchInParanthetis = match.Groups[1].Value;
                    var parser = new RawoutPutFromRegexMatcParser(matchInParanthetis);
                    unit.AddUses(parser.AsIEnumerable());
                }
                if (units.Count >= max)
                {
                    var uses = units.Select(x => string.Join("|", x.DistinctUses));
                    var print = string.Join("|", uses);
                    Console.WriteLine(print);
                    break;
                }
            }
            Console.Read();
        }
    }
}