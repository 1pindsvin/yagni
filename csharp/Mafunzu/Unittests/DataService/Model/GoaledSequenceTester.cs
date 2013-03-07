using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class GoaledSequenceTester
    {
        [Test]
        public void AssertSequence()
        {
            var dummy = new DummySequencer();
            var e = new GoaledSequencer<int>(10, 8, 7, 3, Comparer<int>.Default, dummy);
            var numbers = new List<int>();
            e.Reset();
            while (e.MoveNext())
            {
                numbers.Add(e.Current);
            }

            const string expected = "1,2,3,4,5,6,7,8,8,8,7,7,7,10";
            var actual = string.Join(",", numbers.ConvertAll(x => x.ToString()).ToArray());
            Assert.AreEqual(expected,actual);
        }
    }
}
