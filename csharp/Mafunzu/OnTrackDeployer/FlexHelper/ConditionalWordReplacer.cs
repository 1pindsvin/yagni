using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FlexHelper
{
    public class ConditionalWordReplacer : IWordReplacer
    {
        private bool _success;
        private readonly Regex _conditionalRegex;
        private readonly WordReplacer _wordReplacer;
        public string ReplacedText { get; private set; }

        public ConditionalWordReplacer(string word, string wordReplacement, string conditionalTextThatMustBeFound)
        {
            if(string.IsNullOrEmpty(conditionalTextThatMustBeFound))
            {
                throw new InvalidOperationException("string.IsNullOrEmpty(conditionalTextThatMustBeFound)");
            }
            _wordReplacer = new WordReplacer(word, wordReplacement);
            _conditionalRegex = new Regex(conditionalTextThatMustBeFound, RegexOptions.Multiline);
        }

        public string Replace(string text)
        {
            _success = false;
            if (_conditionalRegex.Match(text).Success)
            {
                ReplacedText =_wordReplacer.Replace(text);
                _success = _wordReplacer.Success();
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