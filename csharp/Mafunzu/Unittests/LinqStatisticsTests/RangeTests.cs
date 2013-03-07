using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace LinqStatistics.UnitTests
{
    /// <summary>
    /// Summary description for RangeTests
    /// </summary>
    [TestFixture]
    public class RangeTests
    {
        public RangeTests()
        {
        }



        [Test]
        public void Range()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3, 4, 5 };

            int result = source.Range();

            Assert.IsTrue(result == 4);
        }
    }
}
