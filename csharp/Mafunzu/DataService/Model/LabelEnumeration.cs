using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    [Flags]
    public enum LabelEnumeration
    {
        None = 0, Competition = 1, Trash = 1073741824
    }
}
