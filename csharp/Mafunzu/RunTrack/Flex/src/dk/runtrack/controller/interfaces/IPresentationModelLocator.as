package dk.runtrack.controller.interfaces
{
	import com.adobe.cairngorm.model.IModelLocator;
	
	import dk.runtrack.model.Athlete;
	import dk.runtrack.presentationmodels.ApplicationPresentationModel;
	import dk.runtrack.presentationmodels.StatusMessageViewModel;
	import dk.runtrack.presentationmodels.interfaces.IAthleteHealthHistoryPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IBestRunsPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IDownloadPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IEditActivityPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IEditAthletePresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IEditGoalPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IEditRunPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IEditShoePresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IEditTrainingPlanPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IEditWorkoutPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.ILoginPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IMonthViewPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IRunActivityPresentationModel;
	import dk.runtrack.presentationmodels.interfaces.IRunChartPresentationModel;
	
	public interface IPresentationModelLocator extends IModelLocator
	{
		function get editAthletePresentationModel(): IEditAthletePresentationModel;
		function get editRunViewModel() : IEditRunPresentationModel;
		function get loginPresentationModel() : ILoginPresentationModel;
		function get editShoePresentationModel() : IEditShoePresentationModel;
		function get runActivityPresentationModel() : IRunActivityPresentationModel;
		function get applicationPresentationModel(): ApplicationPresentationModel;
		function set runActivityPresentationModel(value: IRunActivityPresentationModel):void; 
		function set currentathlete(value:Athlete) : void;
		function get monthViewPresentationModel() : IMonthViewPresentationModel;
		function get statusMessageViewModel():StatusMessageViewModel;
		function get downloadPresentationModel() : IDownloadPresentationModel;
		function get editGoalPresentationModel() : IEditGoalPresentationModel;
		function get editTrainingPlanPresentationModel() : IEditTrainingPlanPresentationModel;
		function get runChartPresentationModel() : IRunChartPresentationModel;
		function get bestRunsPresentationModel() : IBestRunsPresentationModel;
		function get athleteHealthHistoryPresentationModel() : IAthleteHealthHistoryPresentationModel;
		function get editWorkoutPresentationModel() : IEditWorkoutPresentationModel;
		function get editActivityPresentationModel() : IEditActivityPresentationModel;
	}
}