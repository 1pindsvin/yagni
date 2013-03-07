package dk.runtrack.controller
{
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
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

	[Bindable]
	public class PresentationModelLocator implements IPresentationModelLocator
	{
		
		public static var resolveInnerViewModelLocator : Function =
			function() : IPresentationModelLocator
			{
				return new InnerPresentationModelLocator();
			}
		
		private static var _innerPresentationModel:IPresentationModelLocator=null;

		public function PresentationModelLocator()
		{
			if (_innerPresentationModel == null)
			{
				_innerPresentationModel = resolveInnerViewModelLocator();
			}
		}
		
		public function get monthViewPresentationModel() : IMonthViewPresentationModel
		{
			return _innerPresentationModel.monthViewPresentationModel;
		}
	
		public function get editRunViewModel() : IEditRunPresentationModel
		{
			return _innerPresentationModel.editRunViewModel;
		}

		public function get runActivityPresentationModel() : IRunActivityPresentationModel
		{
			return  _innerPresentationModel.runActivityPresentationModel;
		}
		
		public function set runActivityPresentationModel(value: IRunActivityPresentationModel):void
		{
			_innerPresentationModel.runActivityPresentationModel = value;
		}

		public function get downloadPresentationModel() : IDownloadPresentationModel
		{
			return _innerPresentationModel.downloadPresentationModel;
		}
		
		public function get editAthletePresentationModel(): IEditAthletePresentationModel
		{
			return _innerPresentationModel.editAthletePresentationModel;
		}
		
		public function get loginPresentationModel() : ILoginPresentationModel
		{
			return _innerPresentationModel.loginPresentationModel;
		}		
		
		public function get applicationPresentationModel(): ApplicationPresentationModel
		{
			return _innerPresentationModel.applicationPresentationModel;
		}
		
		public function get editShoePresentationModel() : IEditShoePresentationModel
		{
			return _innerPresentationModel.editShoePresentationModel;
		}
		
		public function get statusMessageViewModel():StatusMessageViewModel
		{
			return _innerPresentationModel.statusMessageViewModel;
		}

		public function get editGoalPresentationModel() : IEditGoalPresentationModel
		{
			return _innerPresentationModel.editGoalPresentationModel;
		}

		public function get editTrainingPlanPresentationModel() : IEditTrainingPlanPresentationModel
		{
			return _innerPresentationModel.editTrainingPlanPresentationModel;
		}
		
		public function get runChartPresentationModel() : IRunChartPresentationModel
		{
			return _innerPresentationModel.runChartPresentationModel;
		}

		public function get bestRunsPresentationModel() : IBestRunsPresentationModel
		{
			return _innerPresentationModel.bestRunsPresentationModel;
		}

		public function get athleteHealthHistoryPresentationModel() : IAthleteHealthHistoryPresentationModel
		{
			return _innerPresentationModel.athleteHealthHistoryPresentationModel;
		}
		
		public function get editWorkoutPresentationModel() : IEditWorkoutPresentationModel
		{
			return _innerPresentationModel.editWorkoutPresentationModel;
		}
		
		public function get editActivityPresentationModel() : IEditActivityPresentationModel
		{
			return _innerPresentationModel.editActivityPresentationModel;
		}


		public function set currentathlete(athlete:Athlete) : void
		{
			_innerPresentationModel.currentathlete = athlete;
		}
	}
}