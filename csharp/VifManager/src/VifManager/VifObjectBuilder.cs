using System.Linq;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace dk.magnus.VifManager
{
    internal class VifObjectBuilder
    {
        private static readonly Regex ObjectInlineRegex = new Regex(@"^\s*object\b", RegexOptions.IgnoreCase);
        private static readonly Regex EndOfObjectRegex = new Regex(@"^\s*end\b", RegexOptions.IgnoreCase);

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