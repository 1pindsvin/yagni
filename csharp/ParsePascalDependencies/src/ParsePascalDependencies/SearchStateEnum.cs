using System.Linq;
using System.Collections.Generic;
using System;

namespace ParsePascalDependencies
{
    enum SearchStateEnum
    {
        Unit, UnitName, UsesStatementFound, Uses
    }
}