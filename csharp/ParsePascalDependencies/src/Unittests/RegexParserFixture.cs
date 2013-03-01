using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    class RegexParserFixture
    {
        private Regex _regEx;

        [SetUp]
        public void Setup()
        {
            //const string pattern = @"\s+uses\b(.+?)\;";
            const string pattern = @"\buses\b(.+?)\;";
            _regEx = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }

        [Test]
        public void CanFindUses()
        {
            var text = TestConstants.UsesStatement.Replace(Environment.NewLine, " ");
            Assert.True(_regEx.IsMatch(text));
            var matches = _regEx.Matches(text).Cast<Match>();
            var match = matches.First();
            var matchInParanthetis = match.Groups[1].Value;
            Assert.AreEqual(TestConstants.AllUnits,matchInParanthetis.TrimStart());
        }

        [Test]
        public void CanConvertToEnumerable()
        {
            var parser = new RawoutPutFromRegexMatcParser(TestConstants.AllUnits);
            var res = parser.AsIEnumerable().ToList();
            Assert.AreEqual(8, res.Count);
        }




    }
}
