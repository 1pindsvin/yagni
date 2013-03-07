using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unittests.Statistics
{
    public class Report
    {
        public const string FieldSeparator = "\t";
        public Report()
        {
            _percentageReports = new List<SubReport>();
        }
        public string ReportHeader;

        private readonly List<SubReport> _percentageReports;

        public IEnumerable<SubReport> PercentageReports
        {
            get { return _percentageReports; }
        }

        public void Add(SubReport subReport)
        {
            _percentageReports.Add(subReport);
        }

        public static IEnumerable<string> FieldNames
        {
            get
            {
                return CsvLine.FieldNames;
            }
        }

        private struct CsvLine
        {
            public static string[] FieldNames
            {
                get
                {
                    return
                        new[]
                               {
"ReportHeader",
"Group",
"GroupCount",
"Description",
"Percentage",
"PercentageOfAll"
                               };
                }

            }
            public string ReportHeader { get; set; }
            public string SubReportHeader { get; set; }
            public string Description { get; set; }
            public string Percentage { get; set; }
            public string PercentageOfAll { get; set; }
            public string GroupCount { get; set; }

            public string ToCsvString()
            {
                return string.Join(FieldSeparator, new[] { ReportHeader, SubReportHeader, GroupCount, Description, Percentage, PercentageOfAll });
            }
        }

        public IEnumerable<string> ToCsvReport()
        {
            yield return new CsvLine { ReportHeader = ReportHeader }.ToCsvString();
            foreach (var report in PercentageReports)
            {
                
                var headerResolved = false;
                foreach (var groupData in report.GroupedData)
                {
                    if (!headerResolved)
                    {
                        headerResolved = true;
                        yield return new CsvLine { SubReportHeader = report.Header, GroupCount = groupData.AllGroupsCount.ToString()}.ToCsvString();        
                    }
                    var description = groupData.Description;
                    var percentage = Math.Round(groupData.PercentageOf, 2).ToString().Replace(",", ".");
                    var percentageOfAll = Math.Round(groupData.PercentageOfAll, 2).ToString().Replace(",", ".");
                    yield return
                        new CsvLine
                            {
                                
                                PercentageOfAll = percentageOfAll,
                                Description = description,
                                Percentage = percentage
                                
                            }.ToCsvString();
                }
            }
        }

    }
}
