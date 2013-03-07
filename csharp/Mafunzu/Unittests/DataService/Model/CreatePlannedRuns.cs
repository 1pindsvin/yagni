using System;
using System.Collections.Generic;
using System.Linq;
using DataService.DataAccess;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class CreatePlannedRunsTester
    {
        private static Goal CreateGoal()
        {
            var goal = new Goal {Distance = 10000};
            return goal;
        }

        private static TrainingPlan CreatePlan(Athlete athlete, WeekdaySelectionEnumeration trainingDays)
        {
            var trainingPlan = new TrainingPlan
                                   {
                                       Workload = 50,
                                       Goal = CreateGoal(),
                                       Athlete = athlete,
                                       Start = new DateTime(2009, 1, 1),
                                       StartDistance = 2000,
                                       PreferredWeekdays = (int) trainingDays
                                   };
            return trainingPlan;
        }

        public class Foo
        {
            public string Name { get; set; }
        }

        private class Trouble
        {
            public int Count { get; private set; }

            public int GetNext()
            {
                return Count++;
            }
        }

        private IEnumerable<Foo> InnerCreateWithYield(Trouble trouble)
        {
            const int limit = 100;
            var count = 0;
            while (count < limit)
            {
                count++;
                if (trouble.GetNext() > limit)
                {
                    yield break;
                }
                yield return new Foo {Name = "Foo" + count};
            }
        }


        private IEnumerable<Foo> CreateWithYield()
        {
            var trouble = new Trouble();
            Assert.AreEqual(0, trouble.Count);
            return InnerCreateWithYield(trouble);
        }

        [Test]
        public void AssertAllRunsOccursOnMonday()
        {
            var builder = new AthleteBuilder();

            var athlete = builder.Build();

            const WeekdaySelectionEnumeration mondaySelected = WeekdaySelectionEnumeration.FirstDayOfWeek;

            var trainingPlan = CreatePlan(athlete, mondaySelected);

            var trainer = new Trainer {WeekStartsOnMonday = true};

            var runs = trainer.CreateRuns(athlete, trainingPlan);

            var mondays = runs.ToList().ConvertAll(x => (x.Start).DayOfWeek);

            Assert.IsTrue(mondays.All(day => day == DayOfWeek.Monday));
        }

        [Test]
        public void AssertCreatePlannedRunsWhenOneDaysIsSelected()
        {
            var builder = new AthleteBuilder();

            var athlete = builder.Build();

            const WeekdaySelectionEnumeration oneSelectedDayForTraining = WeekdaySelectionEnumeration.FirstDayOfWeek;

            var trainingPlan = CreatePlan(athlete, oneSelectedDayForTraining);

            var trainer = new Trainer();

            var runs = trainer.CreateRuns(athlete, trainingPlan);

            var distances = runs.ToList().ConvertAll(x => (x.Distance).ToString());

            const string expected =
                "2000,2200,2420,2000,2662,2928,3221,2662,3543,3897,4287,3543,4716,5187,5706,4716,6277,6905,7595,6277,8354,9190,7000,10000";
            var actual = string.Join(",", distances.ToArray());

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AssertCreatePlannedRunsWhenThreeDaysSelected()
        {
            var builder = new AthleteBuilder();

            var athlete = builder.Build();

            const WeekdaySelectionEnumeration threeDays =
                WeekdaySelectionEnumeration.FirstDayOfWeek | WeekdaySelectionEnumeration.ThirdDayOfWeek |
                WeekdaySelectionEnumeration.FifthDayOfWeek;

            var trainingPlan = CreatePlan(athlete, threeDays);

            var trainer = new Trainer();

            var runs = trainer.CreateRuns(athlete, trainingPlan);

            var distances = runs.ToList().ConvertAll(x => (x.Distance).ToString());

            const string expected =
                "2000,2000,2000,2200,2200,2200,2420,2420,2420,2000,2000,2000,2662,2662,2662,2928,2928,2928,3221,3221,3221,2662,2662,2662,3543,3543,3543,3897,3897,3897,4287,4287,4287,3543,3543,3543,4716,4716,4716,5187,5187,5187,5706,5706,5706,4716,4716,4716,6277,6277,6277,6905,6905,6905,7595,7595,7595,6277,6277,6277,8354,8354,8354,9190,9190,9190,7000,7000,7000,10000";
            var actual = string.Join(",", distances.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AssertRunsOccursOnSelectedWeekdays()
        {
            var builder = new AthleteBuilder();

            var athlete = builder.Build();

            const int expectedRunCount = 70;

            const WeekdaySelectionEnumeration threeDays =
                WeekdaySelectionEnumeration.FirstDayOfWeek | WeekdaySelectionEnumeration.ThirdDayOfWeek |
                WeekdaySelectionEnumeration.FifthDayOfWeek;

            var trainingPlan = CreatePlan(athlete, threeDays);

            var trainer = new Trainer {WeekStartsOnMonday = true};


            var runs = trainer.CreateRuns(athlete, trainingPlan);

            Assert.AreEqual(expectedRunCount, runs.Count());

            var days = runs.ToList().ConvertAll(x => x.Start.DayOfWeek);

            Assert.AreEqual(expectedRunCount, days.Count());

            Func<DayOfWeek, bool> isValidDaySelection =
                day => day == DayOfWeek.Monday || day == DayOfWeek.Wednesday || day == DayOfWeek.Friday;

            Assert.IsTrue(days.All(isValidDaySelection));

            trainer = new Trainer {WeekStartsOnMonday = false};
            runs = trainer.CreateRuns(athlete, trainingPlan).ToList();

            days = runs.ToList().ConvertAll(x => (x.Start).DayOfWeek);

            Assert.AreEqual(expectedRunCount, days.Count());

            isValidDaySelection =
                day => day == DayOfWeek.Sunday || day == DayOfWeek.Tuesday || day == DayOfWeek.Thursday;

            Assert.IsTrue(days.All(isValidDaySelection));
        }

        [Test]
        public void IEnumerableFails()
        {
            const int expectedCount = 100;
            var foos = CreateWithYield();

            Assert.AreEqual(expectedCount, foos.Count());

            var names = foos.ToList().ConvertAll(x => x.Name);

            //Assert.AreEqual(expectedCount, names.Count());
            const int unexpected = 1;
            Assert.AreEqual(unexpected, names.Count());
        }
    }
}