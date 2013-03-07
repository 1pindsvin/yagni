using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace dk.magnus.VifManager
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

        private IEnumerable<string> EnumerateByDirectoryWithLinq(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*.pas", SearchOption.TopDirectoryOnly);
            var recursiveFiles = Directory.EnumerateDirectories(directory, "*", SearchOption.TopDirectoryOnly).SelectMany(EnumerateByDirectory);
            return files.Concat(recursiveFiles);
        }

        //show power of resharper here!
        private IEnumerable<string> EnumerateByDirectory(string directory)
        {
            foreach (var file in Directory.EnumerateFiles(directory, "*.pas", SearchOption.TopDirectoryOnly))
            {
                yield return file;
            }
            foreach (var dir in Directory.EnumerateDirectories(directory, "*", SearchOption.TopDirectoryOnly))
            {
                foreach (var file in EnumerateByDirectory(dir))
                {
                    yield return file;
                }
            }
        }

        public IEnumerable<string> EnumerateFiles()
        {
            return Directory.EnumerateFiles(_path, _fileExtension, SearchOption.AllDirectories);
        }
    }
}