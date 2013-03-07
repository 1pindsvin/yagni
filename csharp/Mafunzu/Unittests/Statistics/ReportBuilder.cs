using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Unittests.Statistics
{
    public class ReportBuilder
    {
        public const string CrLf = "\r\n";

        private readonly RespondentData _respondentData;
        private readonly Func<IEnumerable<Respondent>, IEnumerable<GroupData>>[] _respondentFieldFunctions;
        private Dictionary<string, IEnumerable<Respondent>> _respondentByPaymentDictionary;

        public ReportBuilder(IEnumerable<Respondent> allRespondents)
        {
            _respondentData = new RespondentData(allRespondents);
            _respondentFieldFunctions = new Func<IEnumerable<Respondent>, IEnumerable<GroupData>>[]
                                            {
                                                _respondentData.ByAge,
                                                _respondentData.ByCompareResultsWithOthersWeight,
                                                _respondentData.ByFetchDataFromWatchWeight,
                                                _respondentData.ByGoal,
                                                _respondentData.ByInterestInAnyTrainingTool,
                                                _respondentData.ByMonthlyPayment,
                                                _respondentData.ByNumberOfRunsPerWeek,
                                                _respondentData.ByNumberOfYearsRunning,
                                                _respondentData.ByRegisterRunDataWeight,
                                                _respondentData.ByRegisterShoeDataWeight,
                                                _respondentData.ByRunCalendarWeight,
                                                _respondentData.ByStatisticsBestRunsWeight,
                                                _respondentData.ByTrainerWeight,
                                                _respondentData.ByUseOfAnyTrainingTool,
                                                _respondentData.ByVisualWeightlossWeight
                                            };

            ResolvePaymentSegments();
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<Respondent>>> RespondentByPaymentSegments
        {
            get
            {
                foreach (var pair in _respondentByPaymentDictionary)
                {
                    yield return new KeyValuePair<string, IEnumerable<Respondent>>(pair.Key, pair.Value);
                }
            }
        }

        private void ResolvePaymentSegments()
        {
            var notPaying = _respondentData.AllRespondents.Except(_respondentData.PayingRespondents);
            _respondentByPaymentDictionary =
                new Dictionary<string, IEnumerable<Respondent>>
                    {
                        {"Paying", _respondentData.PayingRespondents},
                        {"All", _respondentData.AllRespondents},
                        {"Not paying", notPaying}
                    };
        }

        private IEnumerable<Report> DoBuildReports()
        {
            var reportBuilders =
                new[]
                    {
                        BuildByPaymentReports(),
                        BuildByMonthlyPaymentReports(),
                        BuildByGoalReports(),
                        BuildByGoalAndPaymentReports(),
                        BuildBySpecificRaceEventDistanceReports(),
                        BuildBySpecificGoalAndNumberOfYearsRunningReports(),
                        BuildBySpecificGoalReports(),
                    };

            foreach (var reportBuilder in reportBuilders)
            {
                foreach (var report in reportBuilder)
                {
                    yield return report;
                }
            }
        }

        public IEnumerable<Report> BuildReports()
        {
            return DoBuildReports();
        }

        public IEnumerable<Report> BuildBySpecificRaceEventDistanceReports()
        {
            const int specificRaceEventDistanceDictionaryKey = 1;
            var groups =
                RespondentByPaymentSegments.
                    Select(
                    x =>
                    new KeyValuePair<string, IEnumerable<Respondent>>(x.Key,
                                                                      x.Value.Where(
                                                                          k =>
                                                                          k.Goal ==
                                                                          specificRaceEventDistanceDictionaryKey)));

            foreach (var f in _respondentFieldFunctions)
            {
                yield return BuildMyReport(f.Method.Name, groups, f);
            }
        }

        public IEnumerable<Report> BuildByGoalAndPaymentReports()
        {
            var groupPayingByGoal = _respondentData.
                GroupByGoal(_respondentData.AllRespondents.Where(x => x.MonthlyPayment > 0)).
                Select(
                x => new KeyValuePair<string, IEnumerable<Respondent>>(x.Description, x.Items));

            foreach (var f in _respondentFieldFunctions)
            {
                yield return BuildMyReport(f.Method.Name, groupPayingByGoal, f);
            }
        }

        public IEnumerable<Report> BuildByGoalReports()
        {
            var groups = _respondentData.GroupByGoal(_respondentData.AllRespondents).Select(
                x => new KeyValuePair<string, IEnumerable<Respondent>>(x.Description, x.Items));

            foreach (var f in _respondentFieldFunctions)
            {
                yield return BuildMyReport(f.Method.Name, groups, f);
            }
        }

        public IEnumerable<Report> BuildBySpecificGoalAndNumberOfYearsRunningReports()
        {
            const int specificRaceEventDistanceDictionaryKey = 1;
            const int improveRunningSpeedKey = 6;

            var determinedAthletes =
                _respondentData.AllRespondents.
                    Where(
                    x => x.Goal == specificRaceEventDistanceDictionaryKey || x.Goal == improveRunningSpeedKey);
            var groups = _respondentData.GroupByNumberOfYearsRunning(determinedAthletes).
                Select(x => new KeyValuePair<string, IEnumerable<Respondent>>(x.Description, x.Items));

            foreach (var f in _respondentFieldFunctions)
            {
                yield return BuildMyReport(f.Method.Name, groups, f);
            }
        }

        public IEnumerable<Report> BuildBySpecificGoalReports()
        {
            var determinedAthletes = _respondentData.DeterminedAthletes;
            var groups =
                new[]
                    {
                        new KeyValuePair<string, IEnumerable<Respondent>>("Determinerede atleter", determinedAthletes),
                        new KeyValuePair<string, IEnumerable<Respondent>>("Øvrige (resten)", _respondentData.AllRespondents.Except( determinedAthletes)), 
                    };


            foreach (var f in _respondentFieldFunctions)
            {
                yield return BuildMyReport(f.Method.Name, groups, f);
            }
        }


        public IEnumerable<Report> BuildByMonthlyPaymentReports()
        {
            var groups =
                _respondentData.GroupByMonthlyPayment(_respondentData.AllRespondents).Select(
                    x => new KeyValuePair<string, IEnumerable<Respondent>>(x.Description, x.Items));

            foreach (var f in _respondentFieldFunctions)
            {
                yield return BuildMyReport(f.Method.Name, groups, f);
            }
        }

        public IEnumerable<Report> BuildByPaymentReports()
        {
            foreach (var f in _respondentFieldFunctions)
            {
                yield return BuildMyReport(f.Method.Name, f);
            }
        }

        public static void SaveAsCsv(string path, IEnumerable<Report> reports)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join("\t", Report.FieldNames.ToArray()));
            foreach (var report in reports)
            {
                foreach (var line in report.ToCsvReport())
                {
                    sb.AppendLine(line);
                }
            }
            var contents = sb.ToString();
            File.WriteAllText(path, contents);
        }


        public void SaveAsCsv(string path)
        {
            SaveAsCsv(path, BuildReports());
        }

        private static Report BuildMyReport(string header,
                                            IEnumerable<KeyValuePair<string, IEnumerable<Respondent>>>
                                                groupedRespondents,
                                            Func<IEnumerable<Respondent>, IEnumerable<GroupData>>
                                                grouper)
        {
            var report =
                new Report {ReportHeader = header};
            foreach (var respondents in groupedRespondents)
            {
                var percentageReport =
                    new SubReport
                        {
                            Header = respondents.Key,
                            GroupedData = grouper(respondents.Value)
                        };
                report.Add(percentageReport);
            }
            return report;
        }


        private Report BuildMyReport(string header,
                                     Func<IEnumerable<Respondent>, IEnumerable<GroupData>> grouper)
        {
            return BuildMyReport(header, RespondentByPaymentSegments, grouper);
        }
    }
}