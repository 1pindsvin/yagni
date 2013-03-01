using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    internal class DeepReferenceResolverFixture
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCreate()
        {
            var e = new DeepReferenceResolver(new List<PascalUnit>());
        }


        private static IEnumerable<PascalUnit> BuildUnits()
        {
            var unit = new PascalUnit(TestConstants.WindowsUnit);
            unit.AddUses(
                new[]
                    {
                        TestConstants.MessagesUnit
                    }
                );
            yield return unit;

            unit = new PascalUnit(TestConstants.MessagesUnit);
            unit.AddUses(
                new[]
                    {
                        TestConstants.ClassesUnit
                    }
                );

            yield return unit;
        }

        [Test]
        public void CanResolveEmptySetDependencies()
        {
            //var nums = Enumerable.Range(0, 2).Select(x=>x.ToString());
            var unit = new PascalUnit(TestConstants.WindowsUnit);

            var e = new DeepReferenceResolver(new List<PascalUnit>());
            e.ResolveDependencies();


        }

        [Test]
        public void CanResolveSimpleSetOfDependencies()
        {
            var units = BuildUnits().ToList();
            var e = new DeepReferenceResolver(units);
            e.ResolveDependencies();

            var unit = units.Single(x=>x.UnitName==TestConstants.WindowsUnit);
            Assert.AreEqual(1, unit.Units.Count);

            var depends = unit.DeepReferences;
            Assert.AreEqual(2,depends.Count());
        }

    }
}