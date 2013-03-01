using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParsePascalDependencies
{
    public class TestConstants
    {
        public const string VariantsUnit = "Variants";
        public const string WindowsUnit = "Windows";
        public const string MessagesUnit = "Messages";
        public const string Sysutils = "SysUtils";
        public const string ClassesUnit = "Classes";
        public const string GraphicsUnit = "Graphics";
        public const string ControlsUnit = "Controls";
        public const string FormsUnit = "Forms";

        private static readonly string[] MyUnits = new[] { WindowsUnit, MessagesUnit, Sysutils, VariantsUnit, ClassesUnit, GraphicsUnit, ControlsUnit, FormsUnit };
        public static IEnumerable<string> Units
        {
            get { return MyUnits; }
        }

        public static readonly string AllUnits = string.Join(", ", Units); // "Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms";
        public static readonly string UsesStatement = Environment.NewLine + "uses" + Environment.NewLine + "  " + AllUnits + ";";
    }
}
