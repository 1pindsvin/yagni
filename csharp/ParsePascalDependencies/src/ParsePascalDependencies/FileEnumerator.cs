using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ParsePascalDependencies
{
    internal class FileEnumerator : IFileEnumerator
    {
        private readonly string _path;
        private readonly string _fileExtension;

        public FileEnumerator(string path, string fileExtension)
        {
            _path = path;
            _fileExtension = fileExtension;
        }

        public IEnumerable<string> EnumerateFiles()
        {
            return Directory.EnumerateFiles(_path, _fileExtension, SearchOption.AllDirectories);
        }
    }
}