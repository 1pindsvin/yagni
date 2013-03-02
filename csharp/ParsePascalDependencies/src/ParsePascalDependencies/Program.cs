using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using log4net;

namespace ParsePascalDependencies
{
    internal class Program
    {
        internal const String FILE_PATH = "b:/op/AdHoc/Excel/AdoExcel/Unit1.pas";

        private const string OpDir = @"b:\op";

        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));


        public static void Main(string[] args)
        {
            PrintUnitInfo();
        }

        private const string LineSeparator = "=======================================================";

        private static readonly Regex ValidUnitName = new Regex(@"^\w+$");

        private static void PrintUnitInfo()
        {
            //Predicate<string> isValidUnitName = ValidUnitName.IsMatch;
            var appRunner = AppRunner.CreateDefault(OpDir, ValidUnitName.IsMatch);
            appRunner.RunWithLineStrategy();
            var sb = new StringBuilder();
            var validUnits = appRunner.Units.Where(x => x.IsValidReference).ToList();

            sb.AppendLine(string.Format("Number of units searched: [{0}]", appRunner.Units.Count));
            sb.AppendLine(string.Format("Number of valid unitnames resolved: [{0}]", validUnits.Count));
            sb.AppendLine(LineSeparator);
            var distinctUnitReferences =
                validUnits.SelectMany(x => x.DistinctUses).Select(x => x.ToLower()).Distinct().ToList();
            sb.AppendLine("Number of unique references (total): [" + distinctUnitReferences.Count() + "]");
            sb.AppendLine(LineSeparator);
            var invalidUnitNames = distinctUnitReferences.Where(x => !ValidUnitName.IsMatch(x)).ToList();
            sb.AppendLine("Number of bad unitnames (total): [" + invalidUnitNames.Count() + "]");
            sb.AppendLine(LineSeparator);
            var value = "[" + string.Join(Environment.NewLine, invalidUnitNames) + "]";
            //sb.AppendLine(value);
            //Log.Debug(value);
            Console.WriteLine(sb.ToString());
            Console.WriteLine("All logged");
            Console.Read();
        }

        private static void PrintAllUnits(List<PascalUnit> units)
        {
            var resolver = new DeepReferenceResolver(units);
            resolver.ResolveDependencies();

            foreach (var unit in units)
            {
                var print = String.Format("Unitname: {0}{1}Uses:{1}{2}", unit.UnitName, Environment.NewLine,
                                          string.Join("|", unit.DeepReferences.Select(x => x.UnitName)));
                Console.WriteLine(print);
            }
        }

        public static void PrintSuspectUses(List<PascalUnit> units)
        {
            var resolver = new DeepReferenceResolver(units);
            resolver.ResolveDependencies();

            foreach (var unit in units)
            {
                var suspectUnits = unit.Units.Where(x => !PascalUnit.IsUnitNameValid(x.UnitName))
                                       .Select(x => x.UnitName);

                var print = String.Format("Unitname: {0}{1}Has suspect units in uses statement:{1}{2}", unit.UnitName,
                                          Environment.NewLine, string.Join("|", suspectUnits));
                Console.WriteLine(print);
            }
        }


        private static void PrintAllUnitNames(IEnumerable<PascalUnit> units)
        {
            var print = string.Join("|", units.Select(x => x.UnitNameLowered));
            Console.WriteLine(print);
        }
    }
}