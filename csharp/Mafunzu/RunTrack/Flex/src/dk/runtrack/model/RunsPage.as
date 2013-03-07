package dk.runtrack.model
{
	import dk.runtrack.presentationmodels.Pager;
	
	 
	[RemoteClass(alias="DataService.Model.RunsPage" )]
	public class RunsPage
	{
		public static const RUN_COUNT_NOT_RESOLVED_ON_SERVER : int = -1;
		
		public static const ORDER_BY_ID_EXPRESSION : String = "ID";

		
		public function RunsPage()
		{
			_runs = new Array();
			_athlete=null;
			_requestsLastPage=false;
			_ascending=true;
			_page=Pager.PAGE_SIZE_DEFAULT;
			_runCount=RUN_COUNT_NOT_RESOLVED_ON_SERVER;
			_start=0;
			_orderByExpression = ORDER_BY_ID_EXPRESSION;
			_ByDateTime=null;	
		}


		private var _ByDateTime:Date;

		public function get ByDateTime() : Date
		{
			return _ByDateTime;
		} 

		public function set ByDateTime(value:Date) : void
		{
			_ByDateTime = value;
		}


		private var _requestsLastPage:Boolean;

		public function get RequestsLastPage() : Boolean
		{
			return _requestsLastPage;
		} 

		public function set RequestsLastPage(value:Boolean) : void
		{
			_requestsLastPage = value;
		}

		private var _ascending:Boolean;

		public function get Ascending() : Boolean
		{
			return _ascending;
		} 

		public function set Ascending(value:Boolean) : void
		{
			_ascending = value;
		}

		private var _start:Number;

		public function get Start() : Number
		{
			return _start;
		} 

		public function set Start(value:Number) : void
		{
			_start = value;
		}

		private var _page:Number;

		public function get Page() : Number
		{
			return _page;
		} 

		public function set Page(value:Number) : void
		{
			_page = value;
		}

		private var _runCount:int;

		public function get RunCount() : int
		{
			return _runCount;
		} 

		public function set RunCount(value:int) : void
		{
			_runCount = value;
		}

		private var _orderByExpression:String;

		public function get OrderByExpression() : String
		{
			return _orderByExpression;
		} 

		public function set OrderByExpression(value:String) : void
		{
			_orderByExpression = value;
		}

		private var _athlete:dk.runtrack.model.Athlete;

		public function get Athlete() : dk.runtrack.model.Athlete
		{
			return _athlete;
		} 

		public function set Athlete(value:dk.runtrack.model.Athlete) : void
		{
			if(value.ID < 1)
			{
				throw new Error("athlete not saved"); 
			}
			_athlete = value;
		}

		private var _runs:Array;

		public function get Runs() : Array
		{
			return _runs;
		} 

		public function set Runs(value:Array) : void
		{
			_runs = value;
		}

    } 
   }