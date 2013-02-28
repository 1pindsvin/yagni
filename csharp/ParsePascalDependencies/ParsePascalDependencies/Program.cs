using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

        IEnumerable<string> ToIEnumerable()
        {
            foreach (string item in _data.Split(','))
            {
                yield return item.Trim();
            }
        }

        public override string ToString()
        {
            return "[" + string.Join("|", ToIEnumerable()) + "]";
        }
    }

    internal class PascalUnit
    {

        class UnitNameComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return System.String.Compare(x, y, System.StringComparison.OrdinalIgnoreCase) == 0;
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }

        private readonly List<string> _uses;
        private static readonly UnitNameComparer _unitNameComparer = new UnitNameComparer();

        public PascalUnit(IEnumerable<String> uses)
        {
            if (uses == null)
            {
                throw new ArgumentNullException("uses");
            }
            _uses = uses.ToList();
        }
        public string Name { get; set; }

        public IEnumerable<string> DistinctUses {
            get
            {
                return _uses.Distinct(_unitNameComparer);
            }
        }
        
    }

    internal class Program
    {
        internal const String FILE_PATH = "b:/op/AdHoc/Excel/AdoExcel/Unit1.pas";

        private static void Main(string[] args)
        {
            var text = File.ReadAllText(FILE_PATH).Replace(Environment.NewLine, " ");
            const string pattern = @"\suses\b(.+?)\;";
            var regEx = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (var match in regEx.Matches(text).Cast<Match>())
            {
                var parser = new RawoutPutFromRegexMatcParser(match.Groups[1].Value);

                var print = parser.ToString();
                Console.WriteLine(print);
                Console.ReadKey();
            }
        }
    }
}