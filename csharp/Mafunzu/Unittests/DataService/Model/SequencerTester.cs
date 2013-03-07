using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class SequencerTester
    {
        [Test]
        public void AssertComplexRepetitionProgressionPatternWithPause()
        {
            const int pauseAfter = 3;
            const int start = 1;

            const int noOfElements = 24;

            Func<int, int> progression = x => x + 1;

            var repetitionExpectedResultPair =
                new Dictionary<int, string>
                    {
                        {1, "1,2,3,1,4,5,6,4,7,8,9,7,10,11,12,10,13,14,15,13,16,17,18,16"},
                        {2, "1,1,2,2,3,3,1,1,4,4,5,5,6,6,4,4,7,7,8,8,9,9,7,7"},
                        {4, "1,1,1,1,2,2,2,2,3,3,3,3,1,1,1,1,4,4,4,4,5,5,5,5"}
                    };

            foreach (var pair in repetitionExpectedResultPair)
            {
                var repititions = pair.Key;
                var expected = pair.Value;

                var e = new Sequencer<int>(start, repititions, pauseAfter, progression);
                var results = new List<int>();

                for (var i = 0; i < noOfElements; i++)
                {
                    e.MoveNext();
                    var next = e.Current;
                    results.Add(next);
                }
                var distances = string.Join(",", results.ConvertAll(x => x.ToString()).ToArray());
                Assert.AreEqual(expected, distances);
            }
        }

        [Test]
        public void AssertRepetitionProgressionPattern()
        {
            const int pauseAfter = 20;
            const int start = 1;

            Func<int, int> progression = x => x + 1;

            var repetitionExpectedResultPair = new Dictionary<int, string>
                                                   {
                                                       {1, "1,2,3,4,5,6,7,8,9,10,11,12"},
                                                       {2, "1,1,2,2,3,3,4,4,5,5,6,6"},
                                                       {4, "1,1,1,1,2,2,2,2,3,3,3,3"}
                                                   };

            foreach (var pair in repetitionExpectedResultPair)
            {
                var repititions = pair.Key;
                var expected = pair.Value;

                var e = new Sequencer<int>(start, repititions, pauseAfter, progression);
                var results = new List<int>();
                const int noOfElements = 12;

                for (var i = 0; i < noOfElements; i++)
                {
                    e.MoveNext();
                    var next = e.Current;
                    results.Add(next);
                }
                var distances = string.Join(",", results.ConvertAll(x => x.ToString()).ToArray());
                Assert.AreEqual(expected, distances);
            }
        }

        [Test]
        public void AssertRepetitionProgressionPatternWithPause()
        {
            const int pauseAfter = 2;
            const int start = 1;

            const int noOfElements = 12;

            Func<int, int> progression = x => x + 1;

            var repetitionExpectedResultPair = new Dictionary<int, string>
                                                   {
                                                       {1, "1,2,1,3,4,3,5,6,5,7,8,7"},
                                                       {2, "1,1,2,2,1,1,3,3,4,4,3,3"},
                                                       {4, "1,1,1,1,2,2,2,2,1,1,1,1"}
                                                   };

            foreach (var pair in repetitionExpectedResultPair)
            {
                var repititions = pair.Key;
                var expected = pair.Value;

                var e = new Sequencer<int>(start, repititions, pauseAfter, progression);
                var results = new List<int>();

                for (var i = 0; i < noOfElements; i++)
                {
                    e.MoveNext();
                    var next = e.Current;
                    results.Add(next);
                }
                var distances = string.Join(",", results.ConvertAll(x => x.ToString()).ToArray());
                Assert.AreEqual(expected, distances);
            }
        }
    }
}