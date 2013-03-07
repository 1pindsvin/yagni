using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FlexHelper
{
    public class WordReplacer : IWordReplacer
    {
        private readonly string _wordReplacement;
        private readonly Regex _wholeWordRegex;
        private bool _success;
        public string ReplacedText { get; private set; }

        public WordReplacer(string word, string wordReplacement)
        {
            var wordBounderyPattern = @"\b" + word + @"\b";
            _wholeWordRegex = new Regex(wordBounderyPattern, RegexOptions.Multiline);
            _wordReplacement = wordReplacement;
        }

        public string Replace(string text)
        {
            _success = false;
            if (_wholeWordRegex.Match(text).Success)
            {
                ReplacedText = _wholeWordRegex.Replace(text, _wordReplacement);
                _success = true;
            }
            else
            {
                ReplacedText = null;
            }
            return ReplacedText;
        }

        public bool Success()
        {
            return _success;
        }
    }
}