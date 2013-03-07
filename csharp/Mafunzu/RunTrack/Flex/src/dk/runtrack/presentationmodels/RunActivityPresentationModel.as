package dk.runtrack.presentationmodels
{
	import dk.runtrack.Factory;
	import dk.runtrack.commands.SimpleTimeoutCommand;
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.commands.run.DeleteRunCommand;
	import dk.runtrack.commands.run.GetAthleteRunsCommand;
	import dk.runtrack.commands.run.SetSelectedRunCommand;
	import dk.runtrack.commands.run.UndoDeleteRunCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.io.PersistentObjectEvent;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.RunsPage;
	import dk.runtrack.model.interfaces.IClientModel;
	import dk.runtrack.presentationmodels.interfaces.IRunActivityPresentationModel;
	
	import mx.collections.ArrayList;
	import mx.collections.IList;
	
	
	
	[Bindable]
	public class RunActivityPresentationModel implements IRunActivityPresentationModel
	{
		public static const STATE_DELETING_RUN : String = "deleting.run.state";
		public static const STATE_RUN_SAVED : String = "run.saved.state";
		public static const STATE_RUN_DELETED : String = "run.deleted.state";
		public static const STATE_RUNS_UPDATED : String = "runs.updated.state";
		public static const STATE_UPDATING_RUNS : String = "updating.runs.state";
		public static const STATE_ATHLETE_CHANGED : String = "athlete.changed.state";


		public static var resolveCurrentAthlete : Function = 
			function() : Athlete
			{
				return new PresentationModelLocator().editAthletePresentationModel.currentathlete;
			}

		public static var resolveClient : Function = Factory.getClient;

		
		private var _undoDeleteTimer : UndoTimer;
		private var _undoDeleteCommand : IRtCommand;

		private var _uiSortColumnNames : 
			Array = ["id", "distance", "time", "averageSpeed", "start"];
		private var _runSortColumnNames : 
			Array = ["id", "distance", "time", Constants.RUN_AVERAGE_EXPRESSION, "start"];
	
		private var _pager : Pager;
		private var _sortColumns : SortColumns;

		private var _state : String;

		
		
		public function RunActivityPresentationModel()
		{
			_state = "";
			_pager = new Pager(Pager.PAGE_SIZE_DEFAULT);
			_sortColumns = new SortColumns(_runSortColumnNames)
			setRuns(new Array());
			_runsPage = new RunsPage();
			showUndo = false;
			_deletedRunID = -1;

			_undoDeleteTimer = new UndoTimer(new SimpleTimeoutCommand(this), 10000);			

			client.addEventListener(PersistentObjectEvent.EVENT_RUN_DELETED, runDeletedHandler)

			clear();
		}

		private var _deletedRunID : int;
		private function runDeletedHandler(event: PersistentObjectEvent) : void
		{
			this.state = STATE_RUN_DELETED;
			_deletedRunID = event.runID;
			showUndo = true;
			_undoDeleteTimer.start();
			dispatchGetRunsEvent();						
		}
		
		private function get client() : IClientModel
		{
			return resolveClient();
		}
		
		public var showUndo : Boolean;
		public var showNavigatePageDialog : Boolean;

		public function undoDelete() : void
		{
			_undoDeleteTimer.stop();
			showUndo = false;
			new RunTrackEvent(_undoDeleteCommand).dispatch();
		}
		
		
		private function clear() : void
		{
			_selectedRun = null;
		}
		
		public function get state():String
		{
			return _state;
		}
			
		private function set state(value: String) : void
		{
			_state = value;
		}

		public function updateState(suggestedState: String) :void
		{
			var currentState : String = _state;
			if(currentState==suggestedState)
			{
				return;
			}
			if(suggestedState==STATE_RUN_SAVED)
			{
				dispatchGetRunsEvent();
			}
			state = suggestedState;
		} 

		private var _runsPage : RunsPage;
		public function set runsPage(value:RunsPage) : void
		{
			state = STATE_UPDATING_RUNS;

			_runsPage =  value;
			_pager.setStartFromServer(_runsPage.Start);
			setRuns(_runsPage.Runs);
			showNavigatePageDialog = _runsPage.RunCount > _runsPage.Page;
			state = STATE_RUNS_UPDATED;
		}
		
		public function getPreviousItems() : void
		{
			_pager.movePrevious();
			clear();
			dispatchGetRunsEvent();
		}
		
		public function getNextItems() : void
		{
			_pager.moveNext();
			clear();
			dispatchGetRunsEvent();
		}
		
		public function loadFirstRuns() : void
		{
			_pager.moveFirst();	
			clear();
			dispatchGetRunsEvent();
		}
		
		public function loadLastRuns() : void
		{
			_pager.moveLast();
			clear()
			dispatchGetRunsEvent();			
		}

		
		public function setRuns(runsFromServer : Array) : void
		{
			var map : Function = 
				function(item:Run, index:int, array : Array) : RunDataGridViewItem 
				{	
					return new RunDataGridViewItem(item);
				};
			runs = new ArrayList(runsFromServer.map(map));
		}

		
		private var _runs : IList;
		public function get runs() : IList
		{
			return _runs;
		}
		
		public function set runs(value:IList) : void
		{
			_runs = value;
		}
		
		public function deleteSelectedRun() : void
		{
			if(_selectedRun==null)
			{
				return;
			}
			if(_selectedRun.ID<=0)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
			}
			state = STATE_DELETING_RUN;

			var deleteRunCommand : IRtCommand = new DeleteRunCommand(_selectedRun);
			_undoDeleteCommand  = new UndoDeleteRunCommand(_selectedRun);
			_selectedRun=null;
			new RunTrackEvent(deleteRunCommand).dispatch();
		}

		private var _selectedRun:Run;
		public function get selectedRun() : Run
		{
			return _selectedRun;
		} 

		public function set selectedRun(value:Run) : void
		{
			_selectedRun = value;
			if(_selectedRun==null)
			{
				return;
			}
			var command : SetSelectedRunCommand = new SetSelectedRunCommand(_selectedRun);
			new RunTrackEvent(command).dispatch(); 
		}
				
		private function dispatchGetRunsEvent() : void
		{
			state= STATE_UPDATING_RUNS;
			_runsPage.Athlete = resolveCurrentAthlete();
			_runsPage.Ascending = _sortColumns.sortColumn.sortOrder==1;
			_runsPage.OrderByExpression = _sortColumns.sortColumn.columnName;
			_runsPage.Page = _pager.numberOfItems;
			_runsPage.RequestsLastPage = _pager.start == Pager.MAGIC_LAST_PAGE;
			_runsPage.Start = _pager.start;
			_runsPage.Runs = new Array();

			var command : IRtCommand = new GetAthleteRunsCommand(_runsPage);
			new RunTrackEvent(command).dispatch();
		}

		public function sortRuns(orderByColumnName: String) : void
		{
			var uiColumnIndex : int = _uiSortColumnNames.indexOf(orderByColumnName);
			_sortColumns.setSortColumn(	_runSortColumnNames[uiColumnIndex]);
			dispatchGetRunsEvent();
		}		
		
		private var _status : String = "Resources.unknownStatus";
		public function get status() : String
		{
			return state + ", current runs [" +  _runsPage.Runs.length + "], total count [" + _runsPage.RunCount + "]";
		}
	}
}