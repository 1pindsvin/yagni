using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;

namespace Unittests.ActionScriptClasses
{
    public interface IEditActivityPresentationModel
    {
        string ForeignSystemID { get; set; }
        int ActivityType { get; set; }
        int ActivitySubType { get; set; }
        string Name { get; set; } //navngiv
        string Description { get; set; }
        DateTime Date { get; set; }
        string TotalTime { get; set; }
        string Distance { get; set; }
        int AverageHeartRate { get; set; }
        int MaximumHeartRate { get; set; }
        int Workload { get; set; }
        int Experience { get; set; }
        string Weather { get; set; }
        int Labels { get; set; }
        DateTime LastChanged { get; set; }
        string Intensity { get; set; }
        bool Done { get; set; }
        string Comments { get; set; }
        int ActivitySubTypeSelectedIndex { get; set; }
        int ActivityTypeSelectedIndex { get; set; }
        int ShoeSelectedIndex { get; set; }
        List<string> ActivitySubTypes { get; set; }
        List<Shoe> Shoes { get; set; }
        string State { get; set; }
        bool CanSave { get; set; }
        Activity EditActivity { get; set; }
        void Save();
        void SaveAndGotoLog();
    }


    public class EditActivityPresentationModel : IEditActivityPresentationModel
    {
        public string ForeignSystemID { get; set; }
        public int ActivityType { get; set; }
        public int ActivitySubType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string TotalTime { get; set; }
        public string Distance { get; set; }
        public int AverageHeartRate { get; set; }
        public int MaximumHeartRate { get; set; }
        public int Workload { get; set; }
        public int Experience { get; set; }
        public string Weather { get; set; }
        public int Labels { get; set; }
        public DateTime LastChanged { get; set; }
        public string Intensity { get; set; }
        public bool Done { get; set; }
        public string Comments { get; set; }
        public int ActivitySubTypeSelectedIndex { get; set; }
        public int ActivityTypeSelectedIndex { get; set; }
        public int ShoeSelectedIndex { get; set; }
        public List<string> ActivitySubTypes { get; set; }
        public List<Shoe> Shoes { get; set; }
        public string State { get; set; }
        public bool CanSave { get; set; }
        public Activity EditActivity { get; set; }
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SaveAndGotoLog()
        {
            throw new NotImplementedException();
        }
    }

    public interface IEditWorkoutPresentationModel
    {
        string Description { get; set; }
        int Type { get; set; }
        string Distance { get; set; }
        DateTime Start { get; set; }
        int WorkoutTypeSelectedIndex { get; set; }
        string State { get; set; }
        bool CanSave { get; set; }
        Workout EditWorkout { get; set; }
        void Save();
    }

    public class EditWorkoutPresentationModel : IEditWorkoutPresentationModel
    {
        public string Description { get; set; }
        public int Type { get; set; }
        public string Distance { get; set; }
        public DateTime Start { get; set; }
        public int WorkoutTypeSelectedIndex { get; set; }
        public string State { get; set; }
        public bool CanSave { get; set; }

        public Workout EditWorkout { get; set; }

        public void Save()
        {
             
        }
    }

    public interface IAthleteHealthHistoryPresentationModel
    {
        string State { get; set; }

        List<AthleteHealth> Healths { get; set; }
        AthleteHealth SelectedAthleteHealth { get; set; }

        bool ShowUndo { get; set; }
        void UndoDelete();
        void DeleteSelected();

        void SortBy(string name);

        bool ShowNavigatePage { get; set; }
        void Previous();
        void Next();
        void Last();
        void First();
        void NavigateTo(int page);
        
        void SetAthleteHealthQuery(AthleteHealthQuery query);
    }

    public class AthleteHealthHistoryPresentationModel : IAthleteHealthHistoryPresentationModel
    {
        public string State { get; set; }
        public List<AthleteHealth> Healths { get; set; }
        public AthleteHealth SelectedAthleteHealth { get; set; }
        public bool ShowUndo { get; set; }
        public void UndoDelete()
        {
            throw new NotImplementedException();
        }

        public void DeleteSelected()
        {
            throw new NotImplementedException();
        }

        public void SortBy(string name)
        {
            throw new NotImplementedException();
        }

        public bool ShowNavigatePage { get; set; }
        public void Previous()
        {
            throw new NotImplementedException();
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public void Last()
        {
            throw new NotImplementedException();
        }

        public void First()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(int page)
        {
            throw new NotImplementedException();
        }

        public void SetAthleteHealthQuery(AthleteHealthQuery query)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEditAthletePresentationModel
    {
        bool CanSave { get; set; }
        string State { get; set; }
        Athlete Currentathlete { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        string Weight { get; set; }
        string Height { get; set; }
        string Bmi { get; set; }
        string Waist { get; set; }
        string Thigh { get; set; }
        string Arm { get; set; }
        string RestingHeartRate { get; set; }
        string MaximumHeartRate { get; set; }
        string ThresholdHeartRate { get; set; }
        void Save();
    }

    public class EditAthletePresentationModel : IEditAthletePresentationModel
     {
        public bool CanSave { get; set; }
        public string State { get; set; }
        public Athlete Currentathlete { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Bmi { get; set; }
        public string Waist { get; set; }
        public string Thigh { get; set; }
        public string Arm { get; set; }
        public string RestingHeartRate { get; set; }
        public string MaximumHeartRate { get; set; }
        public string ThresholdHeartRate { get; set; }
        public void Save()
        {
            throw new NotImplementedException();
        }
     }


    public interface IEditShoeViewModel
    {
        string status { get; }
    }

    internal class EditShoeViewModel : IEditShoeViewModel
    {
        public string status
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Array athleteShoes { get; set; }
        public Array loadedShoes { get; set; }

        public bool showActiveShoes { get; set; }
    }

    internal class ShoeDataGridViewItem
    {
        public string name { get; set; }
        public int durability { get; set; }
        public int otherUsage { get; set; }
        public int distanceTravelled { get; set; }
        public int restDurability { get; set; }
        public bool active { get; set; }
        public Object rowColumnIndex { get; set; }
    }

    public interface IWeekdaysPresentationModel
    {
        int SelectedDays { get; set; }
        void Save();
    }

    public class WeekdaysPresentationModel : IWeekdaysPresentationModel
    {
        public int SelectedDays
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }


    public interface IEditTrainingPlanPresentationModel
    {
        int Intensity { get; set; }
        int Skill { get; set; }
        string GoalKilometers { get; set; }
        int PreferredWeekdays { get; set; }
        DateTime Start { get; set; }
        int Workload { get; set; }
        string StartDistance { get; set; }
        int SelectedIndex { get; set; }
        bool CanSave { get; set; }
        TrainingPlan TrainingPlan { get; set; }
        List<TrainingPlan> TrainingPlans { get; set; }
        List<Run> PlannedRuns { get; set; }
        void SetTrainingPlans(List<TrainingPlan> plans);

        void ResolveSelectedIndex();
        void Save();
    }

    public class EditTrainingPlanPresentationModel : IEditTrainingPlanPresentationModel
    {
        public int Intensity { get; set; }

        public int Skill { get; set; }

        public string GoalKilometers { get; set; }

        public int PreferredWeekdays { get; set; }

        public DateTime Start { get; set; }

        public int Workload { get; set; }

        public string StartDistance { get; set; }

        public int SelectedIndex
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool CanSave
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TrainingPlan TrainingPlan
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public List<TrainingPlan> TrainingPlans
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public List<Run> PlannedRuns
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public void SetTrainingPlans(List<TrainingPlan> plans)
        {

        }



        public void ResolveSelectedIndex() { }

        public void Save()
        {
        }
    }

    public interface IRunChartPresentationModel
    {
        List<Run> Runs { get; set; }
        void SetRuns(List<Run> runs);
    }

    public class RunChartPresentationModel : IRunChartPresentationModel
    {
        public List<Run> Runs { get; set; }
        public void SetRuns(List<Run> runs)
        {
        }
    }


    public interface IBestRunsPresentationModel
    {
        string Distance { get; set; }
        List<string> Ranges { get; set; }
        void SearchBestRuns();
    }

    public class BestRunsPresentationModel : IBestRunsPresentationModel
    {
        public string Distance { get; set; }
        public List<string> Ranges { get; set; }
        public BestRunsQuery BestRunsQuery { get; set; }
        public void SearchBestRuns()
        {

        }
    }

}
