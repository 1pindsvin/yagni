using System.Collections.Generic;

namespace dk.magnus.VifManager
{
    internal interface IFileEnumerator
    {
        IEnumerable<string> EnumerateFiles();
    }
}