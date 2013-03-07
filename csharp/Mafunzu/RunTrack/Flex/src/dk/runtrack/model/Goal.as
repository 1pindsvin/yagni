package dk.runtrack.model
{
	
	
	[RemoteClass( alias="DataService.Model.Goal" )]
	public class Goal
	{
		public function Goal()
		{
			_iD = -1;
		}
		
		private var _iD:int;
		
		public function get ID() : int
		{
			return _iD;
		} 
		
		public function set ID(value:int) : void
		{
			_iD = value;
		}
		
		private var _time:int;
		
		public function get Time() : int
		{
			return _time;
		} 
		
		public function set Time(value:int) : void
		{
			_time = value;
		}
		
		private var _distance:int;
		
		public function get Distance() : int
		{
			return _distance;
		} 
		
		public function set Distance(value:int) : void
		{
			_distance = value;
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

		private var _trainingPlans:TrainingPlan;
		
		public function get TrainingPlans() : TrainingPlan
		{
			return _trainingPlans;
		} 
		
		public function set TrainingPlans(value:TrainingPlan) : void
		{
			_trainingPlans = value;
		} 
		
		private var _rtVersion:Number;
		
		public function get RtVersion() : Number
		{
			return _rtVersion;
		} 
		
		public function set RtVersion(value:Number) : void
		{
			_rtVersion = value;
		} 
	} 
}