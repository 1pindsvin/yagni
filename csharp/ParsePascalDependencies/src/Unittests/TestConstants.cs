using System;
using System.Collections.Generic;

namespace ParsePascalDependencies
{
    public class TestConstants
    {
        public const string PathNotImportant = "some/file/path/name.not.important";

        public const string VariantsUnit = "Variants";
        public const string WindowsUnit = "Windows";
        public const string MessagesUnit = "Messages";
        public const string Sysutils = "SysUtils";
        public const string ClassesUnit = "Classes";
        public const string GraphicsUnit = "Graphics";
        public const string ControlsUnit = "Controls";
        public const string FormsUnit = "Forms";

        private static readonly string[] MyUnits = new[]
            {WindowsUnit, MessagesUnit, Sysutils, VariantsUnit, ClassesUnit, GraphicsUnit, ControlsUnit, FormsUnit};

        public static IEnumerable<string> Units
        {
            get { return MyUnits; }
        }

        // "Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms";
        public static readonly string AllUnits = string.Join(", ", Units);

        public static readonly string UsesStatement = Environment.NewLine + "uses" + Environment.NewLine + "  " +
                                                      AllUnits + ";";

        public static readonly string UnitHeaderWithUnitName = Environment.NewLine + "unit" + "  " + "  " + WindowsUnit +
                                                               " ;";


        public static readonly IEnumerable<string> LinesWithMultiLineComments = new[]
            {"unit foo (*", "xx", "efsdgsg*) uses bar;"};

        public static readonly IEnumerable<string> LinesWithMultiLineCommentInOneLine = new[]
            {"unit foo ", "(*xxefsdgsg*) uses bar;"};
    }
}