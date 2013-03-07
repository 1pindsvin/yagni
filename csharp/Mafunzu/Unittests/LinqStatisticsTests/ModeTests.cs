using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace LinqStatistics.UnitTests
{
    [TestFixture]
    public class ModeTests
    {
        public ModeTests()
        {
         
        }

        [Test]
        public void ModeUniform()
        {
            IEnumerable<int> source = new int[] { 1, 1, 1 };

            int? result = source.Mode();
            Assert.IsTrue(result == 1);
        }

        [Test]
        public void ModeNone()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3 };

            int? result = source.Mode();
            Assert.IsFalse(result.HasValue);
        }


        [Test]
        public void ModeOne()
        {
            IEnumerable<int> source = new int[] { 1, 2, 2, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 2);
        }


        [Test]
        public void ModeTwo()
        {
            IEnumerable<int> source = new int[] { 1, 2, 2, 3, 3, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 3);
        }

        [Test]
        public void ModeThree()
        {
            IEnumerable<int> source = new int[] { 1, 2, 2, 3, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 2);
        }


        [Test]
        public void ModeNullable()
        {
            IEnumerable<int?> source = new int?[] { 1, 3, 2, 3, null, 2, 3 };

            int? result = source.Mode();
            Assert.IsTrue(result == 3);
        }

        [Test]
        public void ModeMultiple()
        {
            IEnumerable<int> source = new int[] { 1, 3, 2, 2, 3 };

            IEnumerable<int> result = source.Modes();
            Assert.IsTrue(result.SequenceEqual(new int[] { 2, 3 }));
        }

        [Test]
        public void ModesMultiple2()
        {
            IEnumerable<int> source = new int[] { 1, 3, 2, 2, 3, 3 };

            IEnumerable<int> result = source.Modes();
            Assert.IsTrue(result.SequenceEqual(new int[] { 3, 2 }));
        }

        [Test]
        public void ModesMultipleNullable()
        {
            IEnumerable<int?> source = new int?[] { 1, 2, null, 2, 3, 3, 3 };

            IEnumerable<int> result = source.Modes();
            Assert.IsTrue(result.SequenceEqual(new int[] { 3, 2 }));
        }

        [Test]
        public void ModesSingleValue()
        {
            IEnumerable<int> source = new int[] { 1 };

            int? result = source.Mode();
            Assert.IsTrue(result == null);
        }
    }
}
