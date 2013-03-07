using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace dk.magnus.VifManager
{
    internal class Patterns
    {
        public const string ObjectInline = @"^\s*object\b";
        public const string EndOfObject = @"^\s*end\b";
        public const string ObjectTypeAndName = @"^\s*object\s+(\w+)\b\:\s*(\w+)\b";
    }

    internal class VifObjectBuilder
    {
        public static readonly Regex ObjectInlineRegex = new Regex(Patterns.ObjectInline, RegexOptions.IgnoreCase);
        public static readonly Regex EndOfObjectRegex = new Regex(Patterns.EndOfObject, RegexOptions.IgnoreCase);
        public static readonly Regex FindObjectTypeAndNameRegex = new Regex(Patterns.ObjectTypeAndName, RegexOptions.IgnoreCase);

        internal VifObject Build(IEnumerable<string> lines)
        {
            var root = DoBuild(lines);
            return root.Children.First();
        }

        private static VifObject DoBuild(IEnumerable<string> lines)
        {
            var current = new VifObject {IsRoot = true};
            foreach (var line in lines)
            {
                if (ObjectInlineRegex.IsMatch(line))
                {
                    var vif = new VifObject();
                    vif.AddBeginObjectLine(line);
                    vif.Parent = current;
                    current = vif;
                    continue;
                }
                if (EndOfObjectRegex.IsMatch(line))
                {
                    current.AddEndOfObjectLine(line);
                    current = current.Parent;
                    continue;
                }
                current.AddLine(line);
            }
            return current;
        }
    }
}