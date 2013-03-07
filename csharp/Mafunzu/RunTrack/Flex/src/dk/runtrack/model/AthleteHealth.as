package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.AthleteHealth" )]
	public class AthleteHealth
	{
		public function AthleteHealth()
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
		
		private var _registeredAt:Date;
		
		public function get RegisteredAt() : Date
		{
			return _registeredAt;
		} 
		
		public function set RegisteredAt(value:Date) : void
		{
			_registeredAt = value;
		}
		
		private var _weight:int;
		
		public function get Weight() : int
		{
			return _weight;
		} 
		
		public function set Weight(value:int) : void
		{
			_weight = value;
		}
		
		private var _waist:int;
		
		public function get Waist() : int
		{
			return _waist;
		}
		
		public function set Waist(value:int) : void
		{
			_waist = value;
		}
		
		private var _thigh:int;
		
		public function get Thigh() : int
		{
			return _thigh;
		}
		
		public function set Thigh(value:int) : void
		{
			_thigh = value;
		}
		
		private var _arm:int;
		
		public function get Arm() : int
		{
			return _arm;
		}
		
		public function set Arm(value:int) : void
		{
			_arm = value;
		}
		
		private var _restingHeartRate:int;
		
		public function get RestingHeartRate() : int
		{
			return _restingHeartRate;
		}
		
		public function set RestingHeartRate(value:int) : void
		{
			_restingHeartRate = value;
		}
		
		private var _maximumHeartRate:int;
		
		public function get MaximumHeartRate() : int
		{
			return _maximumHeartRate;
		}
		
		public function set MaximumHeartRate(value:int) : void
		{
			_maximumHeartRate = value;
		}
		
		private var _thresholdHeartRate:int;
		
		public function get ThresholdHeartRate() : int
		{
			return _thresholdHeartRate;
		}
		
		public function set ThresholdHeartRate(value:int) : void
		{
			_thresholdHeartRate = value;
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