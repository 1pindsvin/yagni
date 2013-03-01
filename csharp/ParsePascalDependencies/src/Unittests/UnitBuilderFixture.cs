using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    internal class UnitBuilderFixture
    {

        [SetUp]
        public void Setup()
        {

        }

        static IEnumerable<IEnumerable<string>> BuildLinesWithMultiLineComments()
        {
            yield return TestConstants.LinesWithMultiLineComments;
            yield return TestConstants.LinesWithMultiLineCommentInOneLine;
        }
            
            [Test]
        public void IsMatchForUnitDeclaration()
        {
            foreach (var line in new[] { "unit Unit1;", "unit", " unit ","unit "})
            {
                Assert.True(UnitBuilder.IsMatchForUnitDeclaration(line));
            }
        }


        [Test]
        public void IsMatchForUnitNameCanGetUnitName()
        {
            foreach (var line in new [] { "unit Unit1;", " Unit1 ; ", "Unit1 ; " })
            {
                Assert.True(UnitBuilder.IsMatchForUnitName(line));
                Assert.True(UnitBuilder.GetUnitName(line).Equals("Unit1"));
            }
        }

        [Test]
        public void RemovesSingleLineCommentIfFound()
        {
            foreach (var line in new[] { "unit //Unit1;", "{x} unit", " unit ","{dsgdsgdfgdfg} unit ///another " })
            {
                Assert.AreEqual("unit", UnitBuilder.FilterSingleLineComment(line).Trim());
            }
        }

        [Test]
        public void RemovesBeginMultilineComment()
        {
            foreach (var line in new[] { "unit (*Unit1;", " unit(*", " unit(*whatever;x " })
            {
                Assert.True(UnitBuilder.IsBeginMultiLineComment(line));
                Assert.AreEqual("unit", UnitBuilder.RemoveBeginMultiLineComment(line).Trim());
            }
        }


        [Test]
        public void RemovesEndMultilineComment()
        {
            foreach (var line in new[] { " Unit1; *) unit ", "*) unit", " whatever;x *)unit " })
            {
                Assert.True(UnitBuilder.IsEndMultiLineComment(line));
                Assert.AreEqual("unit", UnitBuilder.RemoveEndMultiLineComment(line).Trim());
            }
        }

        [Test]
        public void RemovesMultilineCommentFromLines()
        {
            foreach (var lines in BuildLinesWithMultiLineComments())
            {
                var expected = new string[] { "unit foo ", " uses bar;" }; 
                var filtered = UnitBuilder.FilterMultiLineCommments(lines).ToArray();
                CollectionAssert.AreEqual(expected,filtered);
            }
        }


    }
}