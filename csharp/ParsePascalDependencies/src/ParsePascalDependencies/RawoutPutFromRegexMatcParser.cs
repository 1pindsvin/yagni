using System;
using System.Collections.Generic;
using System.Linq;

namespace ParsePascalDependencies
{
    internal class RawoutPutFromRegexMatcParser
    {
        private readonly string _data;

        public RawoutPutFromRegexMatcParser(string data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            _data = data;
        }

        public IEnumerable<string> AsIEnumerable()
        {
            foreach (string item in _data.Split(','))
            {
                yield return item.Trim();
            }
        }

        public override string ToString()
        {
            return "[" + string.Join("|", AsIEnumerable()) + "]";
        }
    }
}