package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.athlete.GetHealthHistoryCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.AthleteHealthQuery;
	import dk.runtrack.model.Constants;
	import dk.runtrack.presentationmodels.interfaces.IAthleteHealthHistoryPresentationModel;
	
	public class AthleteHealthHistoryPresentationModel implements IAthleteHealthHistoryPresentationModel
	{
		
		private var _query:AthleteHealthQuery;
		private var _pager:Pager;
		
		public function AthleteHealthHistoryPresentationModel()
		{
			_pager = new Pager(20);
			_query=new AthleteHealthQuery(); 
		}

		private function update() : void
		{
			_state = _state =="On" ? "Off" : "On";
		}
		
		private var _state:String;
		
		public function get state() : String
		{
			return _state;
		}
		
		public function set state(value:String) : void
		{
			_state = value;
		}
		
		
		public function get healths() : Array
		{
			return _query.AthleteHealthHistory;
		}
		
		public function set healths(value:Array) : void
		{
			//dummy, is set through query
		}
		
		private var _selectedAthleteHealth:dk.runtrack.model.AthleteHealth;
		
		public function get selectedAthleteHealth() : dk.runtrack.model.AthleteHealth
		{
			return _selectedAthleteHealth;
		}
		
		public function set selectedAthleteHealth(value:dk.runtrack.model.AthleteHealth) : void
		{
			_selectedAthleteHealth = value;
		}
		
		private var _showUndo:Boolean;
		
		public function get showUndo() : Boolean
		{
			return _showUndo;
		}
		
		public function set showUndo(value:Boolean) : void
		{
			_showUndo = value;
		}
		
		private var _showNavigatePage:Boolean;
		
		public function get showNavigatePage() : Boolean
		{
			return _showNavigatePage;
		}
		
		public function set showNavigatePage(value:Boolean) : void
		{
			_showNavigatePage = value;
		}
		
		public function undoDelete() : void
		{
		}
		
		public function deleteSelected() : void
		{
		}
		
		public function sortBy(name:String) : void
		{
		}
		
		public function previous() : void
		{
		}
		
		public function next() : void
		{
		}
		
		public function last() : void
		{
		}
		
		public function first() : void
		{
			_pager.moveFirst();
			dispatchGetHealthHistoryCommand();
		}
		
		private function dispatchGetHealthHistoryCommand() : void
		{
			_query.PagingData.PageOffset = _pager.start;
			_query.PagingData.TotalCount = Constants.ITEM_COUNT_NOT_RESOLVED;
			_query.AthleteHealthHistory = [];
			var command : GetHealthHistoryCommand = new GetHealthHistoryCommand(_query);
			new RunTrackEvent(command).dispatch();
		}
		
		public function navigateTo(page:int) : void
		{

		}
		
		public function setAthleteHealthQuery(query:AthleteHealthQuery) : void
		{
			_query = query;
			if(!_query.hasLoadedServerData())
			{
				first();
			}
			else
			{
				update();
			}
		}
		
	}
}