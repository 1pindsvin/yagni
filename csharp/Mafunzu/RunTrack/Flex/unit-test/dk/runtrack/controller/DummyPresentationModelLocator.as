package dk.runtrack.controller
{
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.presentationmodels.ApplicationPresentationModel;
	import dk.runtrack.presentationmodels.DummyAthleteHealthHistoryPresentationModel;
	import dk.runtrack.presentationmodels.DummyAthleteRunsViewModel;
	import dk.runtrack.presentationmodels.DummyAthleteViewModel;
	import dk.runtrack.presentationmodels.DummyBestRunsPresentationModel;
	import dk.runtrack.presentationmodels.DummyEditActivityPresentationModel;
	import dk.runtrack.presentationmodels.DummyEditShoeViewModel;
	import dk.runtrack.presentationmodels.DummyEditTrainingPlanPresentationModel;
	import dk.runtrack.presentationmodels.DummyMonthPresentationModel;
	import dk.runtrack.presentationmodels.DummyRegisterRunViewModel;
	import dk.runtrack.presentationmodels.DummyRunChartPresentationModel;
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

	public class DummyPresentationModelLocator implements IPresentationModelLocator
	{
		public  var setCalls : Object= {};
		
		public function DummyPresentationModelLocator()
		{
			_registerRunViewModel = new DummyRegisterRunViewModel();
			_athleteviewmodel= new DummyAthleteViewModel();
			_dummyEditShoeViewModel = new DummyEditShoeViewModel;
			_monthViewPresentationModel = new DummyMonthPresentationModel();
			_bestRunsPresentationModel = new DummyBestRunsPresentationModel();		
			_athleteHealthHistoryPresentationModel = new DummyAthleteHealthHistoryPresentationModel();
			_editActivityPresentationModel = new DummyEditActivityPresentationModel();
		}

		private var _monthViewPresentationModel : DummyMonthPresentationModel;
		public function get monthViewPresentationModel() : IMonthViewPresentationModel
		{
			return _monthViewPresentationModel;
		}
		private var _registerRunViewModel : IEditRunPresentationModel; 
		public function get editRunViewModel() : IEditRunPresentationModel
		{
			return _registerRunViewModel;
		}

		private var _athleteviewmodel : DummyAthleteViewModel;
		public function get editAthletePresentationModel(): IEditAthletePresentationModel
		{
			return _athleteviewmodel;
		}
		

		public function get applicationPresentationModel(): ApplicationPresentationModel
		{
			return null;
		}

		private var _athleteRunsViewModel : IRunActivityPresentationModel = new DummyAthleteRunsViewModel();
		public	function get runActivityPresentationModel() : IRunActivityPresentationModel
		{
			return _athleteRunsViewModel;
		}
		
		public function set runActivityPresentationModel(value: IRunActivityPresentationModel):void
		{
			_athleteRunsViewModel = value;
		}

		public function get loginPresentationModel(): ILoginPresentationModel
		{
			return null;
		}

		private var _dummyEditShoeViewModel	: DummyEditShoeViewModel;
		public function get editShoePresentationModel() : IEditShoePresentationModel
		{
			return _dummyEditShoeViewModel;
		}

		
		public function get statusMessageViewModel():StatusMessageViewModel
		{
			throw new Error(Constants.NOTIMPLEMENTEDEXCEPTION);
			return null;
		}

		public function set currentathlete(athlete:Athlete) : void
		{
			setCalls.currentathlete = 1;
		}

		public function get editGoalPresentationModel() : IEditGoalPresentationModel
		{
			throw new Error(Constants.NOTIMPLEMENTEDEXCEPTION);
			return null;
		}

		public function get editTrainingPlanPresentationModel(): IEditTrainingPlanPresentationModel
		{
			return new DummyEditTrainingPlanPresentationModel();
		}

		public function get downloadPresentationModel() : IDownloadPresentationModel
		{
			throw new Error(Constants.NOTIMPLEMENTEDEXCEPTION);
			return null;			
		}

		public function get runChartPresentationModel() : IRunChartPresentationModel
		{
			return new DummyRunChartPresentationModel();
		}

		private var _bestRunsPresentationModel : DummyBestRunsPresentationModel;
		public function get bestRunsPresentationModel() : IBestRunsPresentationModel
		{
			return _bestRunsPresentationModel;
		}

		private var _athleteHealthHistoryPresentationModel : DummyAthleteHealthHistoryPresentationModel;
		public function get athleteHealthHistoryPresentationModel() : IAthleteHealthHistoryPresentationModel
		{
			return _athleteHealthHistoryPresentationModel;
		}

		public function get editWorkoutPresentationModel() : IEditWorkoutPresentationModel
		{
			throw new Error(Constants.NOTIMPLEMENTEDEXCEPTION);
			return null;			
		}
		
		private var  _editActivityPresentationModel : DummyEditActivityPresentationModel;
		public function get editActivityPresentationModel() : IEditActivityPresentationModel
		{
			return _editActivityPresentationModel;
		}
	}
}