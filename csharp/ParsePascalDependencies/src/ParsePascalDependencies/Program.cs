using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            //PrintUnitInfo();
            //PrintUnitnamesNotFoundInFileSystem();
            PrintDependencies("meptypes");
        }

        private const string LineSeparator = "=======================================================";

        private static void PrintUnitnamesNotFoundInFileSystem()
        {
            var parser = DependencyParser.CreateDefault(OpDir,PascalUnit.IsUnitNameValid);
            parser.BuildPascalUnitsWithReferences();
            var pascalUnits = parser.Units.
                                        SelectMany(x => x.Units).
                                        Distinct(PascalUnit.UnitComparer).
                                        Where(x => !x.IsFoundInFileSystem).
                                        OrderBy(x => x.UnitNameLowered).
                                        ToList();
            var header = string.Format("Number of unique units not found in filesystem: {0}",pascalUnits.Count());
            Func<PascalUnit, string> toString = x => string.Format(x.ToNameAndPathString());
            PrintResolvedUnits(header,pascalUnits,toString);
        }

        private static void PrintDependencies(string unitName)
        {
            var appRunner = DependencyParser.CreateDefault(OpDir,PascalUnit.IsUnitNameValid);
            appRunner.BuildPascalUnitsWithReferences();
            var mepTypes = appRunner.Units.Single(x => x.UnitNameLowered.Equals(unitName.ToLower()));
            var dependencies = mepTypes.DeepReferences.Distinct(PascalUnit.UnitComparer).ToList();
            var header = unitName + ", dependencies";
            Func<PascalUnit, string> toString = x => x.UnitName;
            PrintResolvedUnits(header,dependencies.OrderBy(x => x.IsFoundInFileSystem).ThenBy(x => x.UnitNameLowered),toString);
        }

        private static void PrintUnitInfo()
        {
            //Predicate<string> isValidUnitName = ValidUnitName.IsMatch;
            var appRunner = DependencyParser.CreateDefault(OpDir,PascalUnit.IsUnitNameValid);
            appRunner.BuildPascalUnits();
            var sb = new StringBuilder();
            var validUnits = appRunner.Units.Where(x => x.IsValidReference).ToList();

            sb.AppendLine(string.Format("Number of units searched: [{0}]",appRunner.Units.Count));
            sb.AppendLine(string.Format("Number of valid unitnames resolved: [{0}]",validUnits.Count));
            sb.AppendLine(LineSeparator);
            var distinctUnitReferences = validUnits.SelectMany(x => x.DistinctUses).Select(x => x.ToLower()).Distinct().ToList();
            sb.AppendLine("Number of unique references (total): [" + distinctUnitReferences.Count() + "]");
            sb.AppendLine(LineSeparator);
            var invalidUnitNames = distinctUnitReferences.Where(x => !PascalUnit.IsUnitNameValid(x)).ToList();
            sb.AppendLine("Number of bad unitnames (total): [" + invalidUnitNames.Count() + "]");
            sb.AppendLine(LineSeparator);
            var value = "[" + string.Join(Environment.NewLine,invalidUnitNames) + "]";
            //sb.AppendLine(value);
            //Log.Debug(value);
            Console.WriteLine(sb.ToString());
            Console.WriteLine("All logged");
            Console.Read();
        }

        private static void PrintResolvedUnits(string header,IEnumerable<PascalUnit> units,Func<PascalUnit, string> toString)
        {
            var contents = header + Environment.NewLine + string.Join(Environment.NewLine,units.Select(x => string.Format(x.ToNameAndPathString())));
            File.WriteAllText("unitnames.txt",contents);
            Console.WriteLine("All done");
            Console.Read();
        }
    }
}