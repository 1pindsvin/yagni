using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataService.Io
{
    [TestFixture]
    public class CsvLineTester
    {
        [Test]
        public void AssertAsCsvLine()
        {
            const char separator = '\t';
            var e = 
                new CsvLine
                    {
                        Distance = "Distance",
                        Labels = "Labels",
                        LastChanged = "LastChanged",
                        RegisteredAt = "RegisteredAt",
                        Shoe = "Shoe",
                        Time = "Time"
                    };

            Assert.AreEqual("Time\tDistance\tShoe\tRegisteredAt\tLastChanged\tLabels", e.AsCsvLine(separator));

        }

        [Test]
        public void AssertHeader()
        {
            const char separator = '\t';
            var e =new CsvLine();

            const string expected = "Time\tDistance\tShoe\tRegisteredAt\tLastChanged\tLabels";
            Assert.AreEqual(expected , e.BuildHeaderCsv(separator));

        }

    }
}
