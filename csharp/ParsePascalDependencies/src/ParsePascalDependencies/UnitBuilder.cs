using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParsePascalDependencies
{
    internal interface IUnitBuilder
    {
        PascalUnit Build(string path,IEnumerable<string> lines);
    }

    class UnitBuilder : IUnitBuilder
    {
        private static readonly Regex RegExUnit = new Regex(Patterns.StartUnitNamePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex RegExUnitName = new Regex(Patterns.UnitNameInLinePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex SingleLineCommentRegex = new Regex(Patterns.SingleLinePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex InLineCommentRegex = new Regex(Patterns.InlineCommentPattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex BeginMultiLineCommentRegex = new Regex(Patterns.BeginMultilineCommentPattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly Regex EndMultiLineCommentRegex = new Regex(Patterns.EndMultilineCommentPattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static bool IsMatchForUnitDeclaration(string line)
        {
            return RegExUnit.IsMatch(line);
        }

        public static bool IsMatchForUnitName(string line)
        {
            return RegExUnitName.IsMatch(line);
        }

        private static string RemoveBeginMultiLineComment(string line)
        {
            return BeginMultiLineCommentRegex.Replace(line, "");
        }

        private static bool IsBeginMultiLineComment(string line)
        {
            return BeginMultiLineCommentRegex.IsMatch(line);
        }

        private static string RemoveMultiLineEndComment(string line)
        {
            return EndMultiLineCommentRegex.Replace(line, "");
        }

        private static bool IsEndMultiLineComment(string line)
        {
            return EndMultiLineCommentRegex.IsMatch(line);
        }

        public static string RemoveSingleLineCommentIfFound(string line)
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
                        var cleanLine = RemoveMultiLineEndComment(line);
                        yield return cleanLine;
                        continue;
                    }
                }
                if (IsBeginMultiLineComment(line))
                {
                    var cleanLine = RemoveBeginMultiLineComment(line);
                    if (!IsEndMultiLineComment(line))
                    {
                        inMultiLineCommentSearch = true;
                    }
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
            foreach (var line in FilterMultiLineCommments(lines.Select(RemoveSingleLineCommentIfFound)))
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
