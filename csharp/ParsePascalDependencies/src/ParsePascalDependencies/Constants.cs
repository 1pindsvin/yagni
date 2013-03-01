using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParsePascalDependencies
{
    class Constants
    {
        public const string InlineCommentPattern = @"\{.*?\}";
        public const string ForslashPattern = @"\/\/.*$";
        public const string UnitNameInLinePattern = @"\b(\w+)\s*\;";
        public const string StartUnitNamePattern = @"^\s*\bunit\b";
        public const string UsesUnitsPattern = @"\buses\b(.+?)\b\s*\;";
        public const string UnitNamePattern = @"\bunit\b\s*(\w+)\b\s*\;";
    }
}
