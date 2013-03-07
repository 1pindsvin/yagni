using System;
using System.Collections.Generic;
using System.Linq;

namespace DataService.Model
{
    public partial class Trainer
    {
        private static readonly Dictionary<System.DayOfWeek, WeekdaySelectionEnumeration> DanishWeekDays;
        private static readonly Dictionary<System.DayOfWeek, WeekdaySelectionEnumeration> EnglishWeekDays;

        static Trainer()
        {
            DanishWeekDays = new Dictionary<System.DayOfWeek, WeekdaySelectionEnumeration>(7)
                                 {
                                     {DayOfWeek.Monday, WeekdaySelectionEnumeration.FirstDayOfWeek},
                                     {DayOfWeek.Tuesday, WeekdaySelectionEnumeration.SecondDayOfWeek},
                                     {DayOfWeek.Wednesday, WeekdaySelectionEnumeration.ThirdDayOfWeek},
                                     {DayOfWeek.Thursday, WeekdaySelectionEnumeration.FourthDayOfWeek},
                                     {DayOfWeek.Friday, WeekdaySelectionEnumeration.FifthDayOfWeek},
                                     {DayOfWeek.Saturday, WeekdaySelectionEnumeration.SixthDayOfWeek},
                                     {DayOfWeek.Sunday, WeekdaySelectionEnumeration.SeventhDayOfWeek}
                                 };
            EnglishWeekDays = new Dictionary<System.DayOfWeek, WeekdaySelectionEnumeration>(7)
                                  {
                                      {DayOfWeek.Sunday, WeekdaySelectionEnumeration.FirstDayOfWeek},
                                      {DayOfWeek.Monday, WeekdaySelectionEnumeration.SecondDayOfWeek},
                                      {DayOfWeek.Tuesday, WeekdaySelectionEnumeration.ThirdDayOfWeek},
                                      {DayOfWeek.Wednesday, WeekdaySelectionEnumeration.FourthDayOfWeek},
                                      {DayOfWeek.Thursday, WeekdaySelectionEnumeration.FifthDayOfWeek},
                                      {DayOfWeek.Friday, WeekdaySelectionEnumeration.SixthDayOfWeek},
                                      {DayOfWeek.Saturday, WeekdaySelectionEnumeration.SeventhDayOfWeek}
                                  };
        }

        //public static Func<Trainer, ISequencer<double>> ResolveSequence = BuildSequencer;

        protected virtual ISequencer<Double> BuildSequencer()
        {
            
            var plan = TrainingPlan;
            var goalDistance = plan.Goal.Distance;
            var lastTrainingDistance = ResolveLastTrainingDistance(plan.Goal);
            var lastRestituteDistance = ResolveLastRestituteDistance(plan.Goal);

            var growingSequencer = new Sequencer<double>
                (
                plan.StartDistance, 
                plan.NumberOfTrainingDaysPerWeek, 
                RestitutionWeek - 1, 
                CreateCalculator()
                );

            var goaledSequencer = new GoaledSequencer<double>
                (
                goalDistance,
                lastTrainingDistance,
                lastRestituteDistance,
                plan.NumberOfTrainingDaysPerWeek,
                Comparer<double>.Default,
                growingSequencer
                );
            return goaledSequencer;            
        }

        private Func<double, double> CreateCalculator()
        {
            return distance => distance + distance * WeeklyProgression;
        }

        private double ResolveLastRestituteDistance(Goal goal)
        {
            var fractionOfGoalForlastRestitution = Convert.ToDouble(PercentageOfGoalForLastRestitution) / 100;
            var lastRestituteDistance = Convert.ToInt32(goal.Distance * fractionOfGoalForlastRestitution);
            return lastRestituteDistance;
        }

        private double ResolveLastTrainingDistance(Goal goal)
        {
            var fractionOfGoalForlastTraining = Convert.ToDouble(PercentageOfGoalForLastTraining) / 100;
            var lastTrainingDistance = Convert.ToInt32(goal.Distance * fractionOfGoalForlastTraining);
            return lastTrainingDistance;
        }

        public int PercentageOfGoalForLastTraining { get; set; }

        public int PercentageOfGoalForLastRestitution { get; set; }

        public bool WeekStartsOnMonday { get; set; }

        public ulong RtVersion
        {
            get { return System.BitConverter.ToUInt64(Version.ToArray(), 0); }
            set { Version = System.BitConverter.GetBytes(value); }
        }

        public int RestitutionWeek { get; set; }

        public double WeeklyProgression { get; set; }

        public Athlete Athlete { get; set; }

        public TrainingPlan TrainingPlan { get; set; }

        partial void OnCreated()
        {
            RestitutionWeek = 4;
            WeeklyProgression = .2;
            PercentageOfGoalForLastTraining = 85;
            PercentageOfGoalForLastRestitution = 70;
        }

        public IEnumerable<Run> CreateRuns(Athlete athlete, TrainingPlan plan)
        {
            TrainingPlan = plan;
            Athlete = athlete;

            plan.EnsureIsValid();

            var workload = Convert.ToDouble(plan.Workload) / 100;
            WeeklyProgression *= workload;

            var goaledSequencer = BuildSequencer();
            return CreateRuns(plan.DaysAsWeekdaySelectionEnumeration(), goaledSequencer);
        }

        private IEnumerable<Run> CreateRuns(WeekdaySelectionEnumeration trainingDays, IEnumerator<double> sequencer)
        {
            var isTrainingDay = ResolveTrainingWeekdays(trainingDays);

            sequencer.Reset();
            for (var currentDate = TrainingPlan.Start; ; currentDate = currentDate.AddDays(1))
            {
                if (!isTrainingDay[currentDate.DayOfWeek])
                {
                    continue;
                }
                if (!sequencer.MoveNext())
                {
                    yield break;
                }
                var distance = sequencer.Current;
                var run = CreateRun(distance, currentDate);
                yield return run;
            }
        }


        private Run CreateRun(double distance, DateTime date)
        {
            var run = new Run
                          {
                              TrainingPlan = TrainingPlan,
                              Athlete = Athlete,
                              Distance = Convert.ToInt32(distance),
                              Start = date
                          };
            return run;
        }


        public double CalculateNumberOfProgressions(int start, int end, double progressionFactor)
        {
            var progressIsValid = progressionFactor < 1 && progressionFactor > 0;
            if (!progressIsValid)
            {
                throw new InvalidOperationException("double progressionFactor");
            }
            //formula:                  y  = x * ( 1 + r) ^ n where y: end , x: start, r: progress fraction, n: number of progression times
            //ie. when n is unknown:    10 = 6 * (1 + 0.1) ^ n => 10 = 6 * 1.1^n => log(10)=log(6) + log(1.1^n) => log(10)=log(6) + n * log(1.1) =>
            //                          n = (log(10) - log(6))/log(1.1) => n = log(10/6)/log(1.1)
            var numberOfProgressions = Math.Log(Convert.ToDouble(end) / Convert.ToDouble(start)) /
                                       Math.Log(1 + progressionFactor);
            return numberOfProgressions;
        }

        private Dictionary<DayOfWeek, bool> ResolveTrainingWeekdays(WeekdaySelectionEnumeration trainingDays)
        {
            var weekDays = WeekStartsOnMonday ? DanishWeekDays : EnglishWeekDays;

            var trainingWeekdays = new Dictionary<DayOfWeek, bool>(7);
            foreach (var day in weekDays)
            {
                var canTrainToday = (day.Value & trainingDays) == day.Value;
                trainingWeekdays.Add(day.Key, canTrainToday);
            }
            return trainingWeekdays;
        }
    }
}