﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    internal class PascalUnitFixture
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
        public void CreateWithBadParametersFails()
        {
            Assert.Throws<UnitNameNotFoundException>(() => new PascalUnit("",TestConstants.PathNotImportant));
            Assert.Throws<UnitNameNotFoundException>(() => new PascalUnit(null,TestConstants.PathNotImportant));
            Assert.Throws<InvalidOperationException>(() => new PascalUnit(TestConstants.PathNotImportant,""));
            Assert.Throws<InvalidOperationException>(() => new PascalUnit(TestConstants.PathNotImportant,null));
            Assert.Throws<ArgumentException>(() => new PascalUnit(TestConstants.WindowsUnit,""));
            Assert.Throws<ArgumentException>(() => new PascalUnit(TestConstants.WindowsUnit,null));
        }

        [Test]
        public void FindsDistinctNames()
        {
            var unit = new PascalUnit(TestConstants.WindowsUnit,TestConstants.PathNotImportant);
            unit.AddUnitNames(TestConstants.Units);
            unit.AddUnitNames(TestConstants.Units);
            CollectionAssert.AreEqual(TestConstants.Units,unit.DistinctUses);
        }
    }
}