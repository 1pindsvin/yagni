using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class SimpleGoaledSequenceTester
    {
        [Test]
        public void AssertSequencePattern()
        {
            var dummy = new DummySequencer();
            var goalDistance = 3;
            var lastTrainingDistance = 2;
            var lastRestituteDistance = 0; 
            var repeat = 1;
            var e = new SimpleGoaledSequencer<int>(goalDistance, lastTrainingDistance, lastRestituteDistance, repeat, Comparer<int>.Default, dummy);
            var distances = new List<int>();
            while (e.MoveNext())
            {
                var next = e.Current;
                distances.Add(next);
            }

            var expected = "1,2,3";
            var actual = string.Join(",", distances.ConvertAll(x => x.ToString()).ToArray());
            Assert.AreEqual(expected, actual);

            goalDistance = 5;
            repeat = 3;
            lastTrainingDistance = 4;
            expected = "1,2,3,4,4,4,5";
            distances.Clear();
            e = new SimpleGoaledSequencer<int>(goalDistance, lastTrainingDistance, lastRestituteDistance, repeat, Comparer<int>.Default, dummy);
            while (e.MoveNext())
            {
                var next = Convert.ToInt32(e.Current);
                distances.Add(next);
            }
            actual = string.Join(",", distances.ConvertAll(x => x.ToString()).ToArray());
            Assert.AreEqual(expected, actual);
        }
    }
}