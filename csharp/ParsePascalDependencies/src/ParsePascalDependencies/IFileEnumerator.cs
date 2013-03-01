using System.Linq;
using System.Collections.Generic;
using System;

namespace ParsePascalDependencies
{
    internal interface IFileEnumerator
    {
        IEnumerable<string> EnumerateFiles();
    }
}