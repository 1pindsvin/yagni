using System.Linq;
using System.Collections.Generic;
using System;

namespace ParsePascalDependencies
{
    internal interface IUnitBuilder
    {
        PascalUnit Build(string path,IEnumerable<string> lines);
    }
}