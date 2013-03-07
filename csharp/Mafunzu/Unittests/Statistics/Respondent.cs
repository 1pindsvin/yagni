using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace Unittests.Statistics
{
    [DelimitedRecord("\t")]
    public class Respondent
    {
        public int RespondentID;
        public int CollectorID;
        public string StartDate;
        public string EndDate;
        public string IpAddress;
        [FieldConverter(typeof(MyIntConverter))]
        public int Postnummer;
        public string Email;
        [FieldConverter(typeof(MyIntConverter))]
        public int Age;
        [FieldConverter(typeof(MyIntConverter))]
        public int NumberOfRunsPerWeek;
        public string NumberOfRunsPerWeekComment;
        [FieldConverter(typeof(MyIntConverter))]
        public int NumberOfYearsRunning;
        public string NumberOfYearsRunningComment;
        public string GoalText;
        [FieldConverter(typeof(MyIntConverter))]
        public int Goal;
        [FieldConverter(typeof(MyIntConverter))]
        public int NumberOfShoes;
        [FieldConverter(typeof(MyBoolConverter))]
        public bool UsesTrainingpeaksCom;
        [FieldConverter(typeof(MyBoolConverter))]
        public bool UsesIformDk;
        [FieldConverter(typeof(MyBoolConverter))]
        public bool UsesDinFormDk;
        [FieldConverter(typeof(MyBoolConverter))]
        public bool UsesToolFromPulseWatch;
        [FieldConverter(typeof(MyBoolConverter))]
        public bool UsesNoTrainingTool;
        public string UsesOtherTrainingToolComment;
        [FieldConverter(typeof(MyIntConverter))]
        public int RegisterRunDataWeight;
        [FieldConverter(typeof(MyIntConverter))]
        public int RegisterShoeDataWeight;
        [FieldConverter(typeof(MyIntConverter))]
        public int FetchDataFromWatchWeight;
        [FieldConverter(typeof(MyIntConverter))]
        public int TrainerWeight;
        [FieldConverter(typeof(MyIntConverter))]
        public int StatisticsBestRunsWeight;
        [FieldConverter(typeof(MyIntConverter))]
        public int VisualWeightlossWeight;
        [FieldConverter(typeof(MyIntConverter))]
        public int CompareResultsWithOthersWeight;
        [FieldConverter(typeof(MyIntConverter))]
        public int RunCalendarWeight;
        public string TrainingProgramOtherWishesComment;
        [FieldConverter(typeof(MyIntConverter))]
        public int MonthlyPayment;
        public string MonthlyPaymentText;
        [FieldConverter(typeof(MyBoolConverter))]
        public bool WantsTrialProgramEdition;

        private class MyIntConverter : ConverterBase
        {
            protected override bool CustomNullHandling
            {
                get
                {
                    return true;
                }
            }

            public override object StringToField(string from)
            {
                return string.IsNullOrEmpty(from) ? 0 : int.Parse(from);
            }
        }

        private class MyBoolConverter : ConverterBase
        {
            protected override bool CustomNullHandling
            {
                get
                {
                    return true;
                }
            }
            public override object StringToField(string from)
            {
                return !string.IsNullOrEmpty(from);
            }
        }

    }
}