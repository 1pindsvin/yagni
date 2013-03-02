using System.Collections.Generic;

namespace ParsePascalDependencies
{
    internal interface IFileEnumerator
    {
        IEnumerable<string> EnumerateFiles();
    }
}