using System.Linq;
using NUnit.Framework;

namespace Unittests.Statistics
{
    [TestFixture]
    public class ReportTester
    {
        [Test]
        public void AssertCsvHeaderString()
        {
            var e = new Report {ReportHeader = "Gryffe"};
            var expected = "Gryffe\t\t\t\t\t";
            var actual = string.Join(ReportBuilder.CrLf, e.ToCsvReport().ToArray());
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AssertCsvString()
        {
            var percentageReport =
                new SubReport
                    {
                        Header = "Groffe",
                        GroupedData = new[] {new GroupData {Description = "1", AllGroupsCount = 100, GroupCount = 1}}
                        //KeyValuePair<double, string>(1, "1")}
                    };
            var e = new Report {ReportHeader = "Gryffe"};
            e.Add(percentageReport);
            var expected = "Gryffe\t\t\t\t\t\r\n\tGroffe\t100\t\t\t\r\n\t\t\t1\t1\tINF"; //Infinity
            var actual = string.Join(ReportBuilder.CrLf, e.ToCsvReport().ToArray());
            Assert.AreEqual(expected, actual);
        }
    }
}