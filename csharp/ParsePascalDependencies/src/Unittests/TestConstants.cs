using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParsePascalDependencies
{
    public class TestConstants
    {
        public static readonly string WindowsUnit = "Windows";
        public static readonly string MessagesUnit = "Messages";

        public static readonly string[] MyUnits = new[] { WindowsUnit, MessagesUnit, "SysUtils", "Variants", "Classes", "Graphics", "Controls", "Forms" };
        public static IEnumerable<string> Units
        {
            get { return MyUnits; }
        }

        public static readonly string Uses = string.Join(", ", MyUnits); // "Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms";
        public static readonly string UsesStatement = Environment.NewLine + "uses" + Environment.NewLine + "  " + Uses + ";";
    }
}
