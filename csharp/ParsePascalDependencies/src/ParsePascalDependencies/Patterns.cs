namespace ParsePascalDependencies
{
    internal class Patterns
    {
        public const string MultiLineCommentInOneLinePattern = @"(\(\*.*?\*\)|\{.*?})";
        public const string SingleLinePattern = @"\/\/.*$";
        public const string UnitNameInLinePattern = @"\b(\w+)\s*\;";
        public const string StartUnitNamePattern = @"^\s*\bunit\b";
        public const string UsesUnitsPattern = @"\buses\b(.+?)\b\s*\;";
        public const string UnitNamePattern = @"\bunit\b\s*(\w+)\b\s*\;";
    }
}