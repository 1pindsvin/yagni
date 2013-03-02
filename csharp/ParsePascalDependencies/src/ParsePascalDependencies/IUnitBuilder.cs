using System.Collections.Generic;

namespace ParsePascalDependencies
{
    internal interface IUnitBuilder
    {
        PascalUnit Build(string path, IEnumerable<string> lines);
    }
}