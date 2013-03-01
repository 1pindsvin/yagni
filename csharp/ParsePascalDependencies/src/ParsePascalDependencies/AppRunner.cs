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
        private static readonly ILog Log = LogManager.GetLogger(typeof (AppRunner));
        private static readonly Regex RegExUnit = new Regex(Constants.StartUnitNamePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex RegExUnitName = new Regex(Constants.UnitNameInLinePattern,RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private string Path { get; set; }

        public static AppRunner CreateDefault(string path)
        {
            return new AppRunner(path, new FileEnumerator(path, "*.pas"));
        }

        public AppRunner(string path, IFileEnumerator enumerator)
        {
            if (enumerator == null)
            {
                throw new ArgumentNullException("enumerator");
            }
            _enumerator = enumerator;
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path");
            }
            Path = path;
            
        }

        public bool IsMatchForUnitDeclaration(string line)
        {
            return RegExUnit.IsMatch(line);
        }

        public bool IsMatchForUnitName(string line)
        {
            return RegExUnitName.IsMatch(line);
        }

        public string RemoveSingleLineCommentIfFound(string line)
        {
            return line;
        }

        public string GetUnitName(string line)
        {
            return RegExUnitName.Match(line).Groups[1].Value;
        }

        public void RunWithLineStrategy()
        {
            var units = new List<PascalUnit>();
            var files = _enumerator.EnumerateFiles();

            var regExCommentWithForSlashes = new Regex(Constants.ForslashPattern,
                                                       RegexOptions.Singleline | RegexOptions.IgnoreCase);

            foreach (var path in files)
            {
                var search = SearchStateEnum.Unit;
                var lines = File.ReadAllLines(path);
                PascalUnit unit = null;
                foreach (var line in lines)
                {
                    if (search == SearchStateEnum.Unit)
                    {
                        if (IsMatchForUnitDeclaration(line))
                        {
                            if (IsMatchForUnitName(line))
                            {
                                   
                            }
                            else
                            {
                                search = SearchStateEnum.UnitName;
                            }
                            continue;
                        }
                    }
                    if (search == SearchStateEnum.UnitName)
                    {
                        if (IsMatchForUnitName(line))
                        {
                            search = SearchStateEnum.FirstUses;
                            var name = RegExUnitName.Match(line).Groups[1].Value;
                            unit = new PascalUnit(name, path);
                            units.Add(unit);
                            continue;
                        }
                    }

                    if (search == SearchStateEnum.BeginMultiLineComment)
                    {
                    }
                    if (search == SearchStateEnum.Uses)
                    {
                        continue;
                    }
                }
            }
        }

        public void Run()
        {
            var regEx = new Regex(Constants.UsesUnitsPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            var unitNameRegex = new Regex(Constants.UnitNamePattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var units = new List<PascalUnit>();
            var files = Directory.EnumerateFiles(Path, "*.pas", SearchOption.AllDirectories);

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