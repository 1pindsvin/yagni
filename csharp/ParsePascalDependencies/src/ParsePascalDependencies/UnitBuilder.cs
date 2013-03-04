using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using log4net;

namespace ParsePascalDependencies
{
    internal class UnitBuilder : IUnitBuilder
    {
        private readonly Func<string, bool> _unitNameFilter;
        private static readonly ILog Log = LogManager.GetLogger(typeof (UnitBuilder));

        private static readonly Regex SingleLineCommentRegex = new Regex(Patterns.SingleLineCommentPattern,
                                                                         RegexOptions.Singleline);

        public static readonly Regex MultiLineCommentRegex = new Regex(Patterns.MultiLineCommentInOneLinePattern);

        private static readonly Regex UsesUnitsPatternRegex = new Regex(Patterns.UsesUnitsPattern,
                                                                        RegexOptions.IgnoreCase);

        private static readonly Regex UnitNameRegex = new Regex(Patterns.UnitNamePattern,
                                                                RegexOptions.IgnoreCase);


        private static readonly UnitNameComparer IgnoreCaseOnUnitNameComparer = new UnitNameComparer();


        public static string FilterSingleLineComment(string line)
        {
            return SingleLineCommentRegex.Replace(line,""); 
        }


        private IEnumerable<string> ResolveUnitNames(string uses)
        {
            return uses.Split(',').
                        Select(x => x.Trim()).
                        Distinct(IgnoreCaseOnUnitNameComparer).
                        Where(_unitNameFilter);
        }

        public UnitBuilder(Func<string, bool> unitNameFilter)
        {
            if (unitNameFilter == null)
            {
                throw new ArgumentNullException("unitNameFilter");
            }
            _unitNameFilter = unitNameFilter;
        }


        private const string JoinOnNotSoCommonString = " x_gryffe_x ";

        private string RemoveComments(IEnumerable<string> lines)
        {
            var text = string.Join(JoinOnNotSoCommonString,lines);
            text = MultiLineCommentRegex.Replace(text,"");
            var split = text.Split(new[] {JoinOnNotSoCommonString}, StringSplitOptions.None);
            text = string.Join(" ", split.Select(x => SingleLineCommentRegex.Replace(x, "")));
            return text;
        }

        private PascalUnit CreateUnit(string text, string path)
        {
            var unitName = UnitNameRegex.Match(text).Groups[1].Value.Trim();
            if (string.IsNullOrEmpty(unitName))
            {
                return PascalUnit.CreateInvalidUnitFromPath(path);
            }
            if (!PascalUnit.IsUnitNameValid(unitName))
            {
                return PascalUnit.CreateInvalidUnitWithNameAndPath(unitName,path);
            }
            return new PascalUnit(unitName,path);
        }

        public PascalUnit Build(string path, IEnumerable<string> lines)
        {
            var text = RemoveComments(lines);
            var unit = CreateUnit(text,path);
            foreach (var match in UsesUnitsPatternRegex.Matches(text).Cast<Match>())
            {
                var matchInParanthetis = match.Groups[1].Value;
                var unitNames = ResolveUnitNames(matchInParanthetis);
                unit.AddUnitNames(unitNames);
            }
            return unit;
        }
    }
}