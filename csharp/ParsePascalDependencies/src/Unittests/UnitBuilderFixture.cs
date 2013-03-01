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

        [Test]
        public void CanCreate()
        {
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
            foreach (var line in new[] { "unit //Unit1;", "{x} unit", " unit " })
            {
                Assert.AreEqual("unit", UnitBuilder.RemoveSingleLineCommentIfFound(line).Trim());
            }
        }
    }
}