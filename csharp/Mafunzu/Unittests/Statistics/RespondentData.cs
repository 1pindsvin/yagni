using System;
using System.Collections.Generic;
using System.Linq;

namespace Unittests.Statistics
{
    public class RespondentData
    {
        private readonly Dictionary<int, string> _ageDictionary;
        private readonly Dictionary<int, string> _goalDictionary;

        private readonly Func<Respondent, bool> _hasInterestCollectingTrainingData;
        private readonly Dictionary<int, string> _monthlyPaymentDictionary;
        private readonly Dictionary<int, string> _trainingToolDictionary;
        private readonly Dictionary<int, string> _trainingToolInterestDictionary;
        private readonly Func<Respondent, bool> _usesTrainingToolPredicate;
        private readonly Dictionary<int, string> _weightedAnswerDictionary;
        private Dictionary<int, string> _numberOfRunsPerWeekDictionary;
        private Dictionary<int, string> _numberOfYearsDictionary;

        public RespondentData(IEnumerable<Respondent> respondents)
        {
            _usesTrainingToolPredicate =
                (x =>
                 (
                     x.UsesDinFormDk ||
                     x.UsesIformDk ||
                     x.UsesToolFromPulseWatch ||
                     x.UsesTrainingpeaksCom ||
                     x.UsesOtherTrainingToolComment.Length > 0
                 ) &&
                 !x.UsesNoTrainingTool);

            _trainingToolDictionary = new Dictionary<int, string>
                                          {{0, "Does not use a trainingtool"}, {1, "Uses a trainingtool"}};


            const int important = 3;
            _hasInterestCollectingTrainingData =
                x =>
                (
                    x.CompareResultsWithOthersWeight >= important ||
                    x.FetchDataFromWatchWeight >= important ||
                    x.RegisterRunDataWeight >= important ||
                    x.RegisterShoeDataWeight >= important ||
                    x.RunCalendarWeight >= important ||
                    x.StatisticsBestRunsWeight >= important ||
                    x.TrainerWeight >= important ||
                    x.VisualWeightlossWeight >= important ||
                    x.TrainingProgramOtherWishesComment.Length > 0
                );

            _trainingToolInterestDictionary = new Dictionary<int, string> {{0, "Not interested"}, {1, "Interested"}};


            _weightedAnswerDictionary =
                new Dictionary<int, string>
                    {
                        {4, "Meget vigtig"},
                        {3, "Vigtig"},
                        {2, "Ikke vigtig"},
                        {1, "Unødvendig"},
                        {0, "Ved ikke (eller ikke besvaret)"}
                    };

            _goalDictionary =
                new Dictionary<int, string>
                    {
                        {0, "No goal"},
                        {1, "Specific race/event/distance"},
                        {2, "Ability to complete specific type of race"},
                        {3, "General fitness"},
                        {4, "Loose weight"},
                        {5, "Improve results in other sport"},
                        {6, "Improve running speed"}
                    };

            _ageDictionary =
                new Dictionary<int, string>
                    {
                        {1, "under 18"},
                        {2, "18-29"},
                        {3, "30-39"},
                        {4, "40-49"},
                        {5, "50-59"},
                        {6, "60 eller derover"}
                    };

            _monthlyPaymentDictionary =
                new Dictionary<int, string>
                    {
                        {0, "ingen betaling"},
                        {1, "1-30"},
                        {2, "31-50"},
                        {3, "> 50"}
                    };

            const int specificRaceEventDistanceDictionaryKey = 1;
            const int improveRunningSpeedKey = 6;


            AllRespondents = UpdateWeightedAnswers(respondents).ToArray();
            
            PayingRespondents = AllRespondents.Where(x => x.MonthlyPayment > 0);
            
            RespondentsWithAtLeastTwoRunsPerWeek = AllRespondents.Where(x => x.NumberOfRunsPerWeek >= 2);

            DeterminedAthletes =
                AllRespondents.Where(
                    x => x.Goal == specificRaceEventDistanceDictionaryKey || x.Goal == improveRunningSpeedKey);

            ResolveNumberOfYearsRunningDictionary();
            ResolveNumberOfRunsPerWeekDictionary();
        }
        public IEnumerable<Respondent> RespondentsWithAtLeastTwoRunsPerWeek
        {
            get; private set;
        }

        public IEnumerable<Respondent> AllRespondents { get; private set; }

        public IEnumerable<Respondent> PayingRespondents { get; private set; }

        public IEnumerable<Respondent> DeterminedAthletes { get; private set; }

        private void ResolveNumberOfRunsPerWeekDictionary()
        {
            var max = AllRespondents.Max(x => x.NumberOfRunsPerWeek);
            var min = AllRespondents.Min(x => x.NumberOfRunsPerWeek);
            _numberOfRunsPerWeekDictionary = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var description = string.Format("{0} runs per week", i);
                _numberOfRunsPerWeekDictionary.Add(i, description);
            }
        }

        private void ResolveNumberOfYearsRunningDictionary()
        {
            var max = AllRespondents.Max(x => x.NumberOfYearsRunning);
            var min = AllRespondents.Min(x => x.NumberOfYearsRunning);
            _numberOfYearsDictionary = new Dictionary<int, string>();
            for (var i = min; i <= max; i++)
            {
                var description = string.Format("{0} years", i);
                _numberOfYearsDictionary.Add(i, description);
            }
        }

        private static IEnumerable<Respondent> UpdateWeightedAnswers(IEnumerable<Respondent> respondents)
        {
            foreach (var respondent in respondents)
            {
                const int dontKnow = 5;
                if (respondent.CompareResultsWithOthersWeight == dontKnow)
                {
                    respondent.CompareResultsWithOthersWeight = 0;
                }
                if (respondent.FetchDataFromWatchWeight == dontKnow)
                {
                    respondent.FetchDataFromWatchWeight = 0;
                }
                if (respondent.RegisterRunDataWeight == dontKnow)
                {
                    respondent.RegisterRunDataWeight = 0;
                }
                if (respondent.RegisterShoeDataWeight == dontKnow)
                {
                    respondent.RegisterShoeDataWeight = 0;
                }
                if (respondent.RunCalendarWeight == dontKnow)
                {
                    respondent.RunCalendarWeight = 0;
                }
                if (respondent.StatisticsBestRunsWeight == dontKnow)
                {
                    respondent.StatisticsBestRunsWeight = 0;
                }
                if (respondent.TrainerWeight == dontKnow)
                {
                    respondent.TrainerWeight = 0;
                }
                if (respondent.VisualWeightlossWeight == dontKnow)
                {
                    respondent.VisualWeightlossWeight = 0;
                }
                if (respondent.Age == 0)
                {
                    throw new InvalidOperationException("respondent.Age==0");
                }
                yield return respondent;
            }
        }

        public IEnumerable<GroupData> ByAge(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _ageDictionary, x => x.Age);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByGoal(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _goalDictionary, x => x.Goal);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByUseOfAnyTrainingTool(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _trainingToolDictionary,
                                                            x => _usesTrainingToolPredicate(x) ? 1 : 0);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByMonthlyPayment(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _monthlyPaymentDictionary,
                                                            x => x.MonthlyPayment);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByNumberOfYearsRunning(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _numberOfYearsDictionary,
                                                            x => x.NumberOfYearsRunning);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByNumberOfRunsPerWeek(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _numberOfRunsPerWeekDictionary,
                                                            x => x.NumberOfRunsPerWeek);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByInterestInAnyTrainingTool(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _trainingToolInterestDictionary,
                                                            x => _hasInterestCollectingTrainingData(x) ? 1 : 0);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByCompareResultsWithOthersWeight(
            IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary,
                                                            x => x.CompareResultsWithOthersWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByFetchDataFromWatchWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary,
                                                            x => x.FetchDataFromWatchWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByRegisterRunDataWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary,
                                                            x => x.RegisterRunDataWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByRegisterShoeDataWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary,
                                                            x => x.RegisterShoeDataWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByRunCalendarWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary,
                                                            x => x.RunCalendarWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByStatisticsBestRunsWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary,
                                                            x => x.StatisticsBestRunsWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByTrainerWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary, x => x.TrainerWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<GroupData> ByVisualWeightlossWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary,
                                                            x => x.VisualWeightlossWeight);
            return grouper.ResolveGroupedData(AllRespondents);
        }

        public IEnumerable<Group<Respondent>> GroupByTrainerWeight(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _weightedAnswerDictionary, x => x.TrainerWeight);
            return grouper.GetGroups().OrderBy(x=>x.ID);
        }

        public IEnumerable<Group<Respondent>> GroupByMonthlyPayment(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _monthlyPaymentDictionary,
                                                            x => x.MonthlyPayment);
            return grouper.GetGroups().OrderBy(x => x.ID);
        }

        public IEnumerable<Group<Respondent>> GroupByGoal(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _goalDictionary,
                                                            x => x.Goal);
            return grouper.GetGroups().OrderBy(x => x.ID);
        }

        public IEnumerable<Group<Respondent>> GroupByNumberOfYearsRunning(IEnumerable<Respondent> respondents)
        {
            var grouper = new Grouper<Respondent>(respondents, _numberOfYearsDictionary,
                                                            x => x.NumberOfYearsRunning);
            return grouper.GetGroups().OrderBy(x => x.ID);
        }


    }
}