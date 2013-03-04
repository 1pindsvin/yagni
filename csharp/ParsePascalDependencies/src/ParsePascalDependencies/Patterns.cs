namespace ParsePascalDependencies
{
    internal class Patterns
    {
        //will eat anything matching { whatever } or (* whatever *) 
        //side effect: will remove conditionals also! {IFDEF..}
        //should be used only when the searchtext is seen as one large lump of text
        public const string MultiLineCommentInOneLinePattern = @"(\(\*.*?\*\)|\{.*?})";

        // eats "// until end of line"
        //text should be one line at a time
        public const string SingleLineCommentPattern = @"\/\/.*$";

        //should only run with comments removed
        //finds the reserved word uses surrounded by word boundaries
        //eats anything up to the nearest ;
        //should be used only when the searchtext is seen as one large lump of text
        //not a single-line pattern
        public const string UsesUnitsPattern = @"\buses\b(.+?)\b\s*\;";

        //should only run with comments removed
        //finds the reserved word unit surrounded by word boundaries
        //eats anything up to the nearest ;
        //not a single-line pattern
        public const string UnitNamePattern = @"\bunit\b\s*(\w+)\b\s*\;";
    }
}