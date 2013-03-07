using System.Collections.Generic;
using System.Linq;
using LinqStatistics;

namespace Unittests.Statistics
{
    public class RespondentAnswer
    {
        private readonly IEnumerable<Respondent> _respondents;

        public double CompareResultsWithOthersWeight;
        public double FetchDataFromWatchWeight;
        public double RegisterRunDataWeight;
        public double RegisterShoeDataWeight;
        public double RunCalendarWeight;
        public double StatisticsBestRunsWeight;
        public double TrainerWeight;
        public double VisualWeightlossWeight;

        private RespondentAnswer()
        {
        }

        public RespondentAnswer(IEnumerable<Respondent> respondents)
        {
            _respondents = respondents;
        }

        public IEnumerable<KeyValuePair<string, double>> KeyValuePairs
        {
            get
            {
                yield return
                    new KeyValuePair<string, double>("CompareResultsWithOthersWeight", CompareResultsWithOthersWeight);
                yield return new KeyValuePair<string, double>("FetchDataFromWatchWeight", FetchDataFromWatchWeight);
                yield return new KeyValuePair<string, double>("RegisterRunDataWeight", RegisterRunDataWeight);
                yield return new KeyValuePair<string, double>("RegisterShoeDataWeight", RegisterShoeDataWeight);
                yield return new KeyValuePair<string, double>("RunCalendarWeight", RunCalendarWeight);
                yield return new KeyValuePair<string, double>("StatisticsBestRunsWeight", StatisticsBestRunsWeight);
                yield return new KeyValuePair<string, double>("TrainerWeight", TrainerWeight);
                yield return new KeyValuePair<string, double>("VisualWeightlossWeight", VisualWeightlossWeight);
            }
        }


        public RespondentAnswer Average()
        {
            var answer =
                new RespondentAnswer(_respondents)
                    {
                        CompareResultsWithOthersWeight = _respondents.Average(x => x.CompareResultsWithOthersWeight),
                        FetchDataFromWatchWeight = _respondents.Average(x => x.FetchDataFromWatchWeight),
                        RegisterRunDataWeight = _respondents.Average(x => x.RegisterRunDataWeight),
                        RegisterShoeDataWeight = _respondents.Average(x => x.RegisterShoeDataWeight),
                        RunCalendarWeight = _respondents.Average(x => x.RunCalendarWeight),
                        StatisticsBestRunsWeight = _respondents.Average(x => x.StatisticsBestRunsWeight),
                        TrainerWeight = _respondents.Average(x => x.TrainerWeight),
                        VisualWeightlossWeight = _respondents.Average(x => x.VisualWeightlossWeight)
                    };
            return answer;
        }

        public RespondentAnswer Sum()
        {
            var answer =
                new RespondentAnswer(_respondents)
                    {
                        CompareResultsWithOthersWeight = _respondents.Sum(x => x.CompareResultsWithOthersWeight),
                        FetchDataFromWatchWeight = _respondents.Sum(x => x.FetchDataFromWatchWeight),
                        RegisterRunDataWeight = _respondents.Sum(x => x.RegisterRunDataWeight),
                        RegisterShoeDataWeight = _respondents.Sum(x => x.RegisterShoeDataWeight),
                        RunCalendarWeight = _respondents.Sum(x => x.RunCalendarWeight),
                        StatisticsBestRunsWeight = _respondents.Sum(x => x.StatisticsBestRunsWeight),
                        TrainerWeight = _respondents.Sum(x => x.TrainerWeight),
                        VisualWeightlossWeight = _respondents.Sum(x => x.VisualWeightlossWeight)
                    };
            return answer;
        }

        public RespondentAnswer Max()
        {
            var answer =
                new RespondentAnswer(_respondents)
                    {
                        CompareResultsWithOthersWeight = _respondents.Max(x => x.CompareResultsWithOthersWeight),
                        FetchDataFromWatchWeight = _respondents.Max(x => x.FetchDataFromWatchWeight),
                        RegisterRunDataWeight = _respondents.Max(x => x.RegisterRunDataWeight),
                        RegisterShoeDataWeight = _respondents.Max(x => x.RegisterShoeDataWeight),
                        RunCalendarWeight = _respondents.Max(x => x.RunCalendarWeight),
                        StatisticsBestRunsWeight = _respondents.Max(x => x.StatisticsBestRunsWeight),
                        TrainerWeight = _respondents.Max(x => x.TrainerWeight),
                        VisualWeightlossWeight = _respondents.Max(x => x.VisualWeightlossWeight)
                    };
            return answer;
        }

        public RespondentAnswer Min()
        {
            var answer =
                new RespondentAnswer(_respondents)
                    {
                        CompareResultsWithOthersWeight = _respondents.Min(x => x.CompareResultsWithOthersWeight),
                        FetchDataFromWatchWeight = _respondents.Min(x => x.FetchDataFromWatchWeight),
                        RegisterRunDataWeight = _respondents.Min(x => x.RegisterRunDataWeight),
                        RegisterShoeDataWeight = _respondents.Min(x => x.RegisterShoeDataWeight),
                        RunCalendarWeight = _respondents.Min(x => x.RunCalendarWeight),
                        StatisticsBestRunsWeight = _respondents.Min(x => x.StatisticsBestRunsWeight),
                        TrainerWeight = _respondents.Min(x => x.TrainerWeight),
                        VisualWeightlossWeight = _respondents.Min(x => x.VisualWeightlossWeight)
                    };
            return answer;
        }

        public RespondentAnswer Variance()
        {
            var answer =
                new RespondentAnswer(_respondents)
                    {
                        CompareResultsWithOthersWeight = _respondents.Variance(x => x.CompareResultsWithOthersWeight),
                        FetchDataFromWatchWeight = _respondents.Variance(x => x.FetchDataFromWatchWeight),
                        RegisterRunDataWeight = _respondents.Variance(x => x.RegisterRunDataWeight),
                        RegisterShoeDataWeight = _respondents.Variance(x => x.RegisterShoeDataWeight),
                        RunCalendarWeight = _respondents.Variance(x => x.RunCalendarWeight),
                        StatisticsBestRunsWeight = _respondents.Variance(x => x.StatisticsBestRunsWeight),
                        TrainerWeight = _respondents.Variance(x => x.TrainerWeight),
                        VisualWeightlossWeight = _respondents.Variance(x => x.VisualWeightlossWeight)
                    };
            return answer;
        }

        public RespondentAnswer Median()
        {
            var answer =
                new RespondentAnswer(_respondents)
                {
                    CompareResultsWithOthersWeight = _respondents.Median(x => x.CompareResultsWithOthersWeight),
                    FetchDataFromWatchWeight = _respondents.Median(x => x.FetchDataFromWatchWeight),
                    RegisterRunDataWeight = _respondents.Median(x => x.RegisterRunDataWeight),
                    RegisterShoeDataWeight = _respondents.Median(x => x.RegisterShoeDataWeight),
                    RunCalendarWeight = _respondents.Median(x => x.RunCalendarWeight),
                    StatisticsBestRunsWeight = _respondents.Median(x => x.StatisticsBestRunsWeight),
                    TrainerWeight = _respondents.Median(x => x.TrainerWeight),
                    VisualWeightlossWeight = _respondents.Median(x => x.VisualWeightlossWeight)
                };
            return answer;
        }


        public RespondentAnswer StandardDeviation()
        {
            var answer =
                new RespondentAnswer(_respondents)
                    {
                        CompareResultsWithOthersWeight =
                            _respondents.StandardDeviation(x => x.CompareResultsWithOthersWeight),
                        FetchDataFromWatchWeight = _respondents.StandardDeviation(x => x.FetchDataFromWatchWeight),
                        RegisterRunDataWeight = _respondents.StandardDeviation(x => x.RegisterRunDataWeight),
                        RegisterShoeDataWeight = _respondents.StandardDeviation(x => x.RegisterShoeDataWeight),
                        RunCalendarWeight = _respondents.StandardDeviation(x => x.RunCalendarWeight),
                        StatisticsBestRunsWeight = _respondents.StandardDeviation(x => x.StatisticsBestRunsWeight),
                        TrainerWeight = _respondents.StandardDeviation(x => x.TrainerWeight),
                        VisualWeightlossWeight = _respondents.StandardDeviation(x => x.VisualWeightlossWeight)
                    };
            return answer;
        }

        public RespondentAnswer Difference(RespondentAnswer other)
        {
            var diff =
                new RespondentAnswer
                    {
                        CompareResultsWithOthersWeight =
                            CompareResultsWithOthersWeight - other.CompareResultsWithOthersWeight,
                        FetchDataFromWatchWeight = FetchDataFromWatchWeight - other.FetchDataFromWatchWeight,
                        RegisterRunDataWeight = RegisterRunDataWeight - other.RegisterRunDataWeight,
                        RegisterShoeDataWeight = RegisterShoeDataWeight - other.RegisterShoeDataWeight,
                        RunCalendarWeight = RunCalendarWeight - other.RunCalendarWeight,
                        StatisticsBestRunsWeight = StatisticsBestRunsWeight - other.StatisticsBestRunsWeight,
                        TrainerWeight = TrainerWeight - other.TrainerWeight,
                        VisualWeightlossWeight = VisualWeightlossWeight - other.VisualWeightlossWeight
                    };
            return diff;
        }
    }
}