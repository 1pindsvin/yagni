package dk.runtrack.model
{

	
	[RemoteClass( alias="DataService.Model.Activity" )]
	public class Activity
	{
		public function Activity()
		{
			_iD = -1;
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

		private var _iD:int;

		public function get ID() : int
		{
			return _iD;
		}

		public function set ID(value:int) : void
		{
			_iD = value;
		}

		private var _activityType:int;

		public function get ActivityType() : int
		{
			return _activityType;
		}

		public function set ActivityType(value:int) : void
		{
			_activityType = value;
		}

		private var _activitySubtype:int;

		public function get ActivitySubtype() : int
		{
			return _activitySubtype;
		}

		public function set ActivitySubtype(value:int) : void
		{
			_activitySubtype = value;
		}

		private var _name:String;

		public function get Name() : String
		{
			return _name;
		}

		public function set Name(value:String) : void
		{
			_name = value;
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

		private var _start:Date;

		public function get Start() : Date
		{
			return _start;
		}

		public function set Start(value:Date) : void
		{
			_start = value;
		}

		private var _totalTimeSeconds:int;

		public function get TotalTimeSeconds() : int
		{
			return _totalTimeSeconds;
		}

		public function set TotalTimeSeconds(value:int) : void
		{
			_totalTimeSeconds = value;
		}

		private var _distanceMeters:int;

		public function get DistanceMeters() : int
		{
			return _distanceMeters;
		}

		public function set DistanceMeters(value:int) : void
		{
			_distanceMeters = value;
		}

		private var _maximumSpeed:int;

		public function get MaximumSpeed() : int
		{
			return _maximumSpeed;
		}

		public function set MaximumSpeed(value:int) : void
		{
			_maximumSpeed = value;
		}

		private var _averageHeartRateBpm:int;

		public function get AverageHeartRateBpm() : int
		{
			return _averageHeartRateBpm;
		}

		public function set AverageHeartRateBpm(value:int) : void
		{
			_averageHeartRateBpm = value;
		}

		private var _maximumHeartRateBpm:int;

		public function get MaximumHeartRateBpm() : int
		{
			return _maximumHeartRateBpm;
		}

		public function set MaximumHeartRateBpm(value:int) : void
		{
			_maximumHeartRateBpm = value;
		}

		private var _minimumHeartRateBpm:int;

		public function get MinimumHeartRateBpm() : int
		{
			return _minimumHeartRateBpm;
		}

		public function set MinimumHeartRateBpm(value:int) : void
		{
			_minimumHeartRateBpm = value;
		}

		private var _workload:int;

		public function get Workload() : int
		{
			return _workload;
		}

		public function set Workload(value:int) : void
		{
			_workload = value;
		}

		private var _experience:int;

		public function get Experience() : int
		{
			return _experience;
		}

		public function set Experience(value:int) : void
		{
			_experience = value;
		}

		private var _weather:String;

		public function get Weather() : String
		{
			return _weather;
		}

		public function set Weather(value:String) : void
		{
			_weather = value;
		}

		private var _labels:int;

		public function get Labels() : int
		{
			return _labels;
		}

		public function set Labels(value:int) : void
		{
			_labels = value;
		}

		private var _lastChanged:Date;

		public function get LastChanged() : Date
		{
			return _lastChanged;
		}

		public function set LastChanged(value:Date) : void
		{
			_lastChanged = value;
		}

		private var _intensity:String;

		public function get Intensity() : String
		{
			return _intensity;
		}

		public function set Intensity(value:String) : void
		{
			_intensity = value;
		}

		private var _done:Boolean;

		public function get Done() : Boolean
		{
			return _done;
		}

		public function set Done(value:Boolean) : void
		{
			_done = value;
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

	}
}
