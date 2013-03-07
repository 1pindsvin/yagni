using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlexHelper
{
    public class RecursiveFileWordReplacer
    {
        private readonly string _startDirectory;
        private readonly FlexHelper.IWordReplacer _replacer;
        private readonly string[] _fileExtensions;

        public RecursiveFileWordReplacer(
            string startDirectory,
            FlexHelper.IWordReplacer replacer,
            string[] fileExtension)
        {
            _startDirectory = startDirectory;
            _replacer = replacer;
            _fileExtensions = fileExtension;
        }

        private void DoReplaceInFiles(string directory)
        {
            Func<string, bool> directoryPathIsValid = directoryPath => Path.GetFileName(directoryPath).ToLower() != ".svn";
            foreach (var subDirectory in Directory.GetDirectories(directory).Where(directoryPathIsValid))
            {
                DoReplaceInFiles(subDirectory);
            }
            foreach (var fileExtension in _fileExtensions)
            {
                var currentFileExtension = fileExtension;
                Func<string, bool> fileExtensionMatches = filename => Path.GetExtension(filename) == currentFileExtension;
                foreach (var file in Directory.GetFiles(directory).Where(fileExtensionMatches))
                {
                    var text = File.ReadAllText(file);
                    if(text.Length==0)
                    {
                        continue;
                    }
                    _replacer.Replace(text);
                    if (_replacer.Success())
                    {
                        File.WriteAllText(file, _replacer.ReplacedText);
                    }
                }
            }
        }

        public void ReplaceAll()
        {
            DoReplaceInFiles(_startDirectory);
        }
    }
}