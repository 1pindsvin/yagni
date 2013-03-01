using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParsePascalDependencies
{
    class UnitBuilder : IUnitBuilder
    {
        private static readonly Regex RegExUnit = new Regex(Patterns.StartUnitNamePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex RegExUnitName = new Regex(Patterns.UnitNameInLinePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex SingleLineCommentRegex = new Regex(Patterns.SingleLinePattern, RegexOptions.Singleline);
        private static readonly Regex InLineCommentRegex = new Regex(Patterns.InlineCommentPattern, RegexOptions.Singleline);
        private static readonly Regex BeginMultiLineCommentRegex = new Regex(Patterns.BeginMultilineCommentPattern, RegexOptions.Singleline );
        private static readonly Regex EndMultiLineCommentRegex = new Regex(Patterns.EndMultilineCommentPattern, RegexOptions.Singleline);
        private static readonly Regex MultiLineCommentInOneLineRegex = new Regex(Patterns.MultiLineCommentInOneLinePattern, RegexOptions.Singleline);

        public static bool IsMatchForUnitDeclaration(string line)
        {
            return RegExUnit.IsMatch(line);
        }

        public static bool IsMatchForUnitName(string line)
        {
            return RegExUnitName.IsMatch(line);
        }

        public static string RemoveBeginMultiLineComment(string line)
        {
            return BeginMultiLineCommentRegex.Replace(line, "");
        }

        public static string RemoveMultiLineCommentInOneLine(string line)
        {
            return MultiLineCommentInOneLineRegex.Replace(line, "");
        }


        public static bool IsBeginMultiLineComment(string line)
        {
            return BeginMultiLineCommentRegex.IsMatch(line);
        }

        public static string RemoveEndMultiLineComment(string line)
        {
            return EndMultiLineCommentRegex.Replace(line, "");
        }

        public static bool IsEndMultiLineComment(string line)
        {
            return EndMultiLineCommentRegex.IsMatch(line);
        }

        public static string FilterSingleLineComment(string line)
        {
            if (SingleLineCommentRegex.IsMatch(line))
            {
                line = SingleLineCommentRegex.Replace(line, "");
            }
            if (InLineCommentRegex.IsMatch(line))
            {
                line = InLineCommentRegex.Replace(line, "");
            }
            return line;
        }

        public static string GetUnitName(string line)
        {
            return RegExUnitName.Match(line).Groups[1].Value;
        }

        public static IEnumerable<string> FilterMultiLineCommments(IEnumerable<string> lines)
        {
            var inMultiLineCommentSearch = false;
            foreach (var line in lines)
            {
                if (inMultiLineCommentSearch)
                {
                    if (IsEndMultiLineComment(line))
                    {
                        inMultiLineCommentSearch = false;
                        var cleanLine = RemoveEndMultiLineComment(line);
                        yield return cleanLine;
                    }
                    continue;
                }
                if (IsBeginMultiLineComment(line))
                {
                    var isEndMultiLineComment = IsEndMultiLineComment(line);
                    var cleanLine = isEndMultiLineComment
                                        ? RemoveMultiLineCommentInOneLine(line)
                                        : RemoveBeginMultiLineComment(line);
                    inMultiLineCommentSearch = !isEndMultiLineComment;
                    yield return cleanLine;
                    continue;
                }
                yield return line;
            }
        }

        static PascalUnit CreateUnit(string lineWithUnitName, string path)
        {
            var name = GetUnitName(lineWithUnitName);
            return new PascalUnit(name, path);
        }

        public PascalUnit Build(string path,IEnumerable<string> lines)
        {
            var search = SearchStateEnum.Unit;
            PascalUnit unit = null;
            foreach (var line in FilterMultiLineCommments(lines).Select(FilterSingleLineComment))
            {
                if (search == SearchStateEnum.Unit)
                {
                    search = SearchStateEnum.UnitName;
                }
                if (search == SearchStateEnum.UnitName)
                {
                    if (IsMatchForUnitName(line))
                    {
                        unit = CreateUnit(line, path);
                        search = SearchStateEnum.FirstUses;
                    }
                    continue;
                }
                if (search == SearchStateEnum.Uses)
                {
                    continue;
                }
            }
            return unit;
        }
    }
}
