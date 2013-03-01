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
            Assert.Throws<ArgumentException>(() => new PascalUnit("", TestConstants.PathNotImportant));
            Assert.Throws<ArgumentException>(() => new PascalUnit(null, TestConstants.PathNotImportant));
        }

        [Test]
        public void FindsDistinctNames()
        {
            var unit = new PascalUnit(TestConstants.WindowsUnit, TestConstants.PathNotImportant);
            unit.AddUnitNames(TestConstants.Units);
            unit.AddUnitNames(TestConstants.Units);
            CollectionAssert.AreEqual(TestConstants.Units,unit.DistinctUses);
        }

    }
}
