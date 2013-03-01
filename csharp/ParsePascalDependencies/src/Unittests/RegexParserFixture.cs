using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    class RegexParserFixture
    {
        private Regex _usesUnitsRegEx;
        private Regex _unitNameRegEx;

        [SetUp]
        public void Setup()
        {
            _usesUnitsRegEx = new Regex(Patterns.UsesUnitsPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            _unitNameRegEx = new Regex(Patterns.UnitNamePattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }

        [Test]
        public void CanFindUses()
        {
            var text = TestConstants.UsesStatement.Replace(Environment.NewLine, " ");
            Assert.True(_usesUnitsRegEx.IsMatch(text));
            var matches = _usesUnitsRegEx.Matches(text).Cast<Match>();
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

        [Test]
        public void CanResolveUnitName()
        {
            var text = TestConstants.UnitHeaderWithUnitName.Replace(Environment.NewLine, " ");
            Debug.Print("[" + text + "]");
            Assert.True(_unitNameRegEx.IsMatch(text));
        }

    }
}
