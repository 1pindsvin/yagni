package dk.runtrack.model
{
	
	
	[RemoteClass( alias="DataService.Model.BestRunsQuery" )]
	public class BestRunsQuery
	{
		public function BestRunsQuery()
		{
		}
		
		private var _athlete:dk.runtrack.model.Athlete;
		
		public function get Athlete() : dk.runtrack.model.Athlete
		{
			return _athlete;
		}
		
		public function set Athlete(value:dk.runtrack.model.Athlete) : void
		{
			_athlete = value;
		}
		
		private var _before:Date;
		
		public function get Before() : Date
		{
			return _before;
		}
		
		public function set Before(value:Date) : void
		{
			_before = value;
		}
		
		private var _after:Date;
		
		public function get After() : Date
		{
			return _after;
		}
		
		public function set After(value:Date) : void
		{
			_after = value;
		}
		
		private var _distanceMaximum:int;
		
		public function get DistanceMaximum() : int
		{
			return _distanceMaximum;
		}
		
		public function set DistanceMaximum(value:int) : void
		{
			_distanceMaximum = value;
		}
		
		private var _distanceMinimum:int;
		
		public function get DistanceMinimum() : int
		{
			return _distanceMinimum;
		}
		
		public function set DistanceMinimum(value:int) : void
		{
			_distanceMinimum = value;
		}
		
		private var _numberOfRunsToFetch:int;
		
		public function get NumberOfRunsToFetch() : int
		{
			return _numberOfRunsToFetch;
		}
		
		public function set NumberOfRunsToFetch(value:int) : void
		{
			_numberOfRunsToFetch = value;
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
		

		public function EnsureQueryValid() : void
		{
			if(!_athlete)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + " Athlete is not set");
			}
			if (Before && After)
			{
				if (After > Before)
				{
					throw new Error(Constants.INVALIDOPERATIONEXCEPTION + " After > Before");
				}
			}
			if (DistanceMinimum>DistanceMaximum)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + " DistanceMinimum>DistanceMaximum");
			}
			
		}

	}
}