package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.RunsPage;
	import dk.runtrack.presentationmodels.interfaces.IRunActivityPresentationModel;
	
	import mx.collections.IList;

	[Bindable]
	public class DummyAthleteRunsViewModel implements IRunActivityPresentationModel
	{
		public static var runsPageWasSet : Boolean;
		
		
		
		private var _runs : IList;
		
		public function DummyAthleteRunsViewModel()
		{
		}


		public var showUndo : Boolean;

		public function get runs():IList
		{
			return _runs;
		}

		public function set runs(value:IList):void
		{
			_runs = value;
		}

		public function undoDelete() : void
		{
			throw new Error(Constants.NOTIMPLEMENTEDEXCEPTION);
		}

		public function addRun() : void
		{
			
		}
		
		public function get showNavigatePageDialog() : Boolean
		{
			return true;
		}
		
		public function set showNavigatePageDialog(value : Boolean) : void
		{
			//dummy		
		}


		public function set runsPage(value:RunsPage) : void
		{
			runsPageWasSet = true;
		}

		public function deleteSelectedRun() : void
		{
		}

		private var _selectedRun:Run;
		public function get selectedRun() : Run
		{
			return _selectedRun;
		} 

		public function set selectedRun(value:Run) : void
		{
			_selectedRun = value;
		}

		public function getPreviousItems():void
		{
		}
		
		public function getNextItems():void
		{
		}
		
		
		public function loadFirstRuns() : void
		{
		}
		
		public function loadLastRuns() : void
		{
		}

		                                                                                                                                    
		public function sortRuns(orderByColumnName: String) : void
		{
				
		}		
		
		private var _state:String;
		public function get state():String
		{
			return _state;
		}

		public function updateState(suggestedState: String) :void
		{
			_state = suggestedState;
		} 
		private var _status : String = "unknownstatus";
		public function get status() : String
		{
			return _status;
		}

		public function setRuns(runsFromServer : Array) : void
		{
			
		}

	}
}