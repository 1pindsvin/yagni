using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    class PascalUnitFixture
    {

        public static IEnumerable<T> FromSingleItem<T>(T item)
        {
            yield return item;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateWithEmptyNameFails()
        {
            Assert.Throws<ArgumentException>(() => new PascalUnit(""));
            Assert.Throws<ArgumentException>(() => new PascalUnit(null));
        }

        [Test]
        public void FindsDistinctNames()
        {
            const string windows = "Windows";
            var unit = new PascalUnit(windows);
            unit.AddUses(TestConstants.Units);
            unit.AddUses(TestConstants.Units);
            CollectionAssert.AreEqual(TestConstants.Units,unit.DistinctUses);
        }

        [Test]
        public void References()
        {
            
            var unit = new PascalUnit(TestConstants.WindowsUnit);
            unit.AddUses(TestConstants.Units.Except(FromSingleItem(TestConstants.WindowsUnit)));

            var other = new PascalUnit(TestConstants.MessagesUnit);
            other.AddUses(TestConstants.Units.Except(FromSingleItem(TestConstants.MessagesUnit)));

            Assert.True(other.References(unit));
            Assert.True(unit.References(other));                

            Assert.True(unit.IsReferencedByUnitName(other));
            Assert.True(other.IsReferencedByUnitName(unit));

            Assert.False(other.References(other));
            Assert.False(unit.References(unit));
            Assert.False(other.IsReferencedByUnitName(other));
            Assert.False(unit.IsReferencedByUnitName(unit));


        }

        [Test]
        public void DeepReferences()
        {

        }
    }
}
