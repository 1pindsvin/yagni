using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class LabelEnumerationTester
    {
        static int AddIntValues(LabelEnumeration e1, LabelEnumeration e2)
        {
            return (int) e1 + (int) e2;
        }

        static bool AreIntvaluesEqual(LabelEnumeration e1, int intValue)
        {
            return (int) e1 == intValue;
        }

        [Test]
        public void AddLabel()
        {
            var e = LabelEnumeration.Competition;

            e |= LabelEnumeration.Trash;

            var sum = AddIntValues(LabelEnumeration.Competition, LabelEnumeration.Trash);

            Assert.True(AreIntvaluesEqual(e, sum));
        }

        [Test]
        public void CompareLabels()
        {
            var e = LabelEnumeration.Competition;
            e |= LabelEnumeration.Trash;

            Assert.AreEqual(LabelEnumeration.Competition, e & LabelEnumeration.Competition);
            Assert.AreEqual(LabelEnumeration.Trash, e & LabelEnumeration.Trash);
        }

        [Test]
        public void RemoveLabel()
        {
            var e = LabelEnumeration.Competition;

            e |= LabelEnumeration.Trash;

            e ^= LabelEnumeration.Trash;

            Assert.AreEqual(LabelEnumeration.Competition, e);
        }

        [Test]
        public void FindLabelNotInSet()
        {
            const LabelEnumeration label = LabelEnumeration.Competition;
            const LabelEnumeration otherLabel = LabelEnumeration.Trash;
            var labels = new []{ label, otherLabel};

            var findLabel = labels.Single(x => (x & LabelEnumeration.Trash) != LabelEnumeration.Trash);

            Assert.AreEqual(findLabel, label);
        }


    }
}
