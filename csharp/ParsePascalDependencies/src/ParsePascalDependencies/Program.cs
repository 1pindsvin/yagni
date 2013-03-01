using System;
using System.Collections.Generic;
using System.Linq;

namespace ParsePascalDependencies
{
    enum SearchStateEnum
    {
        Unit, UnitName, FirstUses, SecondUses, Uses, BeginMultiLineComment, EndComment
    }

    internal class Program
    {
        internal const String FILE_PATH = "b:/op/AdHoc/Excel/AdoExcel/Unit1.pas";

        private const string OpDir = @"b:\op";





        public static void Main(string[] args)
        {
            AppRunner.CreateDefault(OpDir).RunWithLineStrategy();
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

        public static void PrintSuspectUses(List<PascalUnit> units)
        {
            var resolver = new DeepReferenceResolver(units);
            resolver.ResolveDependencies();

            foreach (var unit in units)
            {
                var suspectUnits = unit.Units.Where(x => !PascalUnit.IsUnitNameValid(x.UnitName)).Select(x => x.UnitName);
                
                var print = String.Format("Unitname: {0}{1}Has suspect units in uses statement:{1}{2}", unit.UnitName, Environment.NewLine, string.Join("|", suspectUnits));
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