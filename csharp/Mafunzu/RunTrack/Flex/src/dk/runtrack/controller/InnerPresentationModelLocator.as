package dk.runtrack.controller
{
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.AthleteHealthQuery;
	import dk.runtrack.presentationmodels.ApplicationPresentationModel;
	import dk.runtrack.presentationmodels.AthleteHealthHistoryPresentationModel;
	import dk.runtrack.presentationmodels.BestRunsPresentationModel;
	import dk.runtrack.presentationmodels.DownloadPresentationModel;
	import dk.runtrack.presentationmodels.EditActivityPresentationModel;
	import dk.runtrack.presentationmodels.EditAthletePresentationModel;
	import dk.runtrack.presentationmodels.EditGoalPresentationModel;
	import dk.runtrack.presentationmodels.EditRunPresentationModel;
	import dk.runtrack.presentationmodels.EditShoePresentationModel;
	import dk.runtrack.presentationmodels.EditTrainingPlanPresentationModel;
	import dk.runtrack.presentationmodels.EditWorkoutPresentationModel;
	import dk.runtrack.presentationmodels.LoginPresentationModel;
	import dk.runtrack.presentationmodels.MonthViewPresentationModel;
	import dk.runtrack.presentationmodels.RunActivityPresentationModel;
	import dk.runtrack.presentationmodels.RunChartPresentationModel;
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

	[Bindable]
	public class InnerPresentationModelLocator implements IPresentationModelLocator
	{

		private var _athleteViewModel:EditAthletePresentationModel;
		private var _loginViewModel : LoginPresentationModel;
		private var _editRunViewModel : IEditRunPresentationModel;
		private var _athleteRunsViewModel : IRunActivityPresentationModel;
		private var _applicationViewModel:ApplicationPresentationModel;
		private var _editShoeViewModel : IEditShoePresentationModel;
		private var _monthViewViewModel : IMonthViewPresentationModel;
		private var _statusMessageViewModel:StatusMessageViewModel;
		private var _editGoalPresentationModel : IEditGoalPresentationModel;
		private var _editTrainingPlanPresentationModel : IEditTrainingPlanPresentationModel;
		private var _runChartPresentationModel : IRunChartPresentationModel;
		private var _bestRunsPresentationModel : IBestRunsPresentationModel;
		private var _athleteHealthHistoryPresentationModel : IAthleteHealthHistoryPresentationModel;
		private var _editWorkoutPresentationModel : IEditWorkoutPresentationModel;
		private var _editActivityPresentationModel : IEditActivityPresentationModel;
		
		public function InnerPresentationModelLocator()
		{
			initialize();
		}
		
		private function initialize() : void
		{
			_statusMessageViewModel = new StatusMessageViewModel;
			_athleteViewModel = new EditAthletePresentationModel();
			_loginViewModel = new LoginPresentationModel();	
			_editRunViewModel = new EditRunPresentationModel();
			_athleteRunsViewModel = new RunActivityPresentationModel();
			_applicationViewModel = new ApplicationPresentationModel();
			_editShoeViewModel = new EditShoePresentationModel();
			_monthViewViewModel = new MonthViewPresentationModel();
			_editShoeViewModel = new EditShoePresentationModel();
			_editGoalPresentationModel = new EditGoalPresentationModel();
			_editTrainingPlanPresentationModel = new EditTrainingPlanPresentationModel();
			_runChartPresentationModel = new RunChartPresentationModel();
			_bestRunsPresentationModel = new BestRunsPresentationModel();
			_athleteHealthHistoryPresentationModel = new AthleteHealthHistoryPresentationModel();
			_editWorkoutPresentationModel = new EditWorkoutPresentationModel();
			_editActivityPresentationModel = new EditActivityPresentationModel();
			
			downloadPresentationModel = new DownloadPresentationModel();
			
		}

		public var downloadPresentationModel : IDownloadPresentationModel;
		
		public function get monthViewPresentationModel() : IMonthViewPresentationModel
		{
			return _monthViewViewModel;
		}
		
		public function get editRunViewModel() : IEditRunPresentationModel
		{
			return _editRunViewModel;
		}
		
		public function get runActivityPresentationModel() : IRunActivityPresentationModel
		{
			return _athleteRunsViewModel;
		}
		
		public function set runActivityPresentationModel(value: IRunActivityPresentationModel):void
		{
			_athleteRunsViewModel = value;
		}
		
		public function get editAthletePresentationModel(): IEditAthletePresentationModel
		{
			return _athleteViewModel;
		}
		
		public function get loginPresentationModel() : ILoginPresentationModel
		{
			return _loginViewModel;
		}		
		
		
		public function get applicationPresentationModel(): ApplicationPresentationModel
		{
			return _applicationViewModel;
		}
		
		public function get editShoePresentationModel() : IEditShoePresentationModel
		{
			return _editShoeViewModel;
		}
		
		public function get statusMessageViewModel():StatusMessageViewModel
		{
			return _statusMessageViewModel;
		}

		public function get editGoalPresentationModel() : IEditGoalPresentationModel
		{
			return _editGoalPresentationModel;
		}

		public function get editTrainingPlanPresentationModel() : IEditTrainingPlanPresentationModel
		{
			return _editTrainingPlanPresentationModel;
		}

		public function get runChartPresentationModel() : IRunChartPresentationModel
		{
			return _runChartPresentationModel;
		}

		public function get bestRunsPresentationModel() : IBestRunsPresentationModel
		{
			return _bestRunsPresentationModel;
		}
		
		public function get athleteHealthHistoryPresentationModel() : IAthleteHealthHistoryPresentationModel
		{
			return _athleteHealthHistoryPresentationModel;
		}

		public function get editWorkoutPresentationModel() : IEditWorkoutPresentationModel
		{
			return _editWorkoutPresentationModel;
		}

		public function get editActivityPresentationModel() : IEditActivityPresentationModel
		{
			return _editActivityPresentationModel;	
		}
		
		public function set currentathlete(athlete:Athlete) : void
		{
			
			editAthletePresentationModel.currentathlete = athlete;
			editRunViewModel.currentathlete = athlete;
			editShoePresentationModel.currentathlete = athlete;
			var query : AthleteHealthQuery = new AthleteHealthQuery();
			query.Athlete = athlete;
			athleteHealthHistoryPresentationModel.setAthleteHealthQuery(query);
		}
	}
}