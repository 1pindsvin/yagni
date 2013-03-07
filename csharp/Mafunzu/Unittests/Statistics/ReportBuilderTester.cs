using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Unittests.Statistics
{
    [TestFixture, Ignore]
    public class ReportBuilderTester
    {
        private Respondent[] _allRespondents;

        public ReportBuilderTester()
        {
            LoadRespondents();
        }

        private void LoadRespondents()
        {
            _allRespondents = SporgeskemaTester.LoadRespondentsFromFile();
        }


        [Test, Category("slow")]
        public void AssertBuildReportsReturns105Reports()
        {
            var expected = 105;
            var actual = new ReportBuilder(_allRespondents).BuildReports();
            Assert.AreEqual(expected, actual.Count());
        }

        [Test, Category("slow")]
        public void AssertBuildReportsReturnsCsvContent()
        {
            var r = new ReportBuilder(_allRespondents);
            r.SaveAsCsv("Respondent.csv");
        }

        [Test, Category("slow")]
        public void AssertBySpecificRaceEventDistanceCsvContent()
        {
            var r = new ReportBuilder(_allRespondents);
            ReportBuilder.SaveAsCsv(
                "BySpecificRaceEventDistance.csv",
                r.BuildBySpecificRaceEventDistanceReports());
        }

        [Test, Category("slow")]
        public void AssertByGoalCsvContent()
        {
            var r = new ReportBuilder(_allRespondents);
            ReportBuilder.SaveAsCsv(
                "BuildByGoalReports.csv",
                r.BuildByGoalReports());

        }

        [Test]
        public void AssertVestas()
        {
            var operand = 3 & 0x1f;
            var e = -1000 >> operand;
            Assert.AreEqual(-125, e);



            char[] input = "clevnrb ktjfiodolwg maoeaihsfe".ToCharArray();

            /*
                        for (int i = 0; i < input.Length; i++)
                        {
                            Debug.WriteLine(string.Format( "i {0}, right shift i {1}", i, i >> 1));
                        }
            */

            var me = input.Select((c, i) => new { Grp = i >> 1, Val = c });
            var print = string.Join(
                    ",",
                    me.ToList().
                    ConvertAll(x => string.Format("Grp {0}, Val {1}", x.Grp, x.Val)).
                    ToArray());

            Console.WriteLine(print);


            var grouped = me.GroupBy((p) => p.Grp, (k, v) => new { Rank = v.First().Val, Char = v.Last().Val });



            var alias = grouped.OrderBy(m => m.Rank)
                                         .Select(m => m.Char)
                                           .Aggregate(String.Empty, (acc, c) => acc + c)
                                             .ToUpper();

            Console.WriteLine(alias);
        }


        [Test, Category("slow")]
        public void AssertByGoalAndPaymentContent()
        {
            var r = new ReportBuilder(_allRespondents);
            ReportBuilder.SaveAsCsv(
                "BuildByGoalAndPaymentReports.csv",
                r.BuildByGoalAndPaymentReports());

        }

        [Test, Category("slow")]
        public void AssertBuildByMonthlyPaymentContent()
        {
            var r = new ReportBuilder(_allRespondents);
            ReportBuilder.SaveAsCsv(
                "BuildByMonthlyPaymentReports.csv",
                r.BuildByMonthlyPaymentReports());

        }

        [Test, Category("slow")]
        public void AssertByPaymentContent()
        {
            var r = new ReportBuilder(_allRespondents);
            ReportBuilder.SaveAsCsv(
                "BuildByPaymentReports.csv",
                r.BuildByPaymentReports());

        }

        [Test, Category("slow")]
        public void AssertBySpecificGoalAndNumberOfYearsRunningContent()
        {
            var r = new ReportBuilder(_allRespondents);
            ReportBuilder.SaveAsCsv(
                "BySpecificGoalAndNumberOfYearsRunningReports.csv",
                r.BuildBySpecificGoalAndNumberOfYearsRunningReports());

        }


        [Test, Category("slow")]
        public void AssertBuildBySpecificGoalContent()
        {
            var r = new ReportBuilder(_allRespondents);
            ReportBuilder.SaveAsCsv(
                "BySpecificGoalReports.csv",
                r.BuildBySpecificGoalReports());

        }

    }
}
