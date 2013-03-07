package dk.runtrack.model
{
	
	[RemoteClass( alias="DataService.Model.Workout" )]
	public class Workout
	{
		public function Workout()
		{
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

		private var _start:Date;

		public function get Start() : Date
		{
			return _start;
		}

		public function set Start(value:Date) : void
		{
			_start = value;
		}

		private var _description:String;

		public function get Description() : String
		{
			return _description;
		}

		public function set Description(value:String) : void
		{
			_description = value;
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

		private var _workoutType:int;

		public function get WorkoutType() : int
		{
			return _workoutType;
		}

		public function set WorkoutType(value:int) : void
		{
			_workoutType = value;
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