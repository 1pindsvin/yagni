using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.Io
{
    [TestFixture]
    public class CsvDataTester
    {
        [Test]
        public void AssertCanConvertRunToCsv()
        {
            var date = new DateTime(2010, 1, 30, 12, 25, 7);
            
            var shoe = new Shoe {Brand = "Nike"};
            
            var run = new Run
                          {
                              Distance = 10000,
                              Labels = (int) LabelEnumeration.None,
                              LastChanged = date,
                              Start = date,
                              Shoe = shoe,
                              Time = 10000
                          };

            var e = new CsvData();
            var content = e.AsFileContent(new[] {run});
            var expected = "Time\tDistance\tShoe\tRegisteredAt\tLastChanged\tLabels\r\n10000\t10000\tNike\t30-1-2010 12:25:07\t30-1-2010 12:25:07\t\r\n";
            Assert.AreEqual(expected,content);
        }
    }
}
