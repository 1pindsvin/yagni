package dk.runtrack.model
{
	
	[RemoteClass( alias="DataService.Model.Athlete" )]
	public class Athlete
	{
		public static var createAthlete : Function = 
			function (user: User) : Athlete
			{
				var athlete : Athlete = new Athlete();
				athlete.RtVersion = 0;
				athlete.User = user;
				return athlete; 
			}
		
		public function Athlete()
		{
			_iD = -1;
		}
		
		private var _iD:Number;
		
		public function get ID() : Number
		{
			return _iD;
		} 
		
		public function set ID(value:Number) : void
		{
			_iD = value;
		}
		
		private var _firstName:String;
		
		public function get FirstName() : String
		{
			return _firstName;
		} 
		
		public function set FirstName(value:String) : void
		{
			_firstName = value;
		}
		
		private var _lastName:String;
		
		public function get LastName() : String
		{
			return _lastName;
		} 
		
		public function set LastName(value:String) : void
		{
			_lastName = value;
		}
		
		private var _dateOfBirth:Date;
		
		public function get DateOfBirth() : Date
		{
			return _dateOfBirth;
		} 
		
		public function set DateOfBirth(value:Date) : void
		{
			_dateOfBirth = value;
		}
		
		
		private var _user:dk.runtrack.model.User;
		
		public function get User() : dk.runtrack.model.User
		{
			return _user;
		} 
		
		public function set User(value:dk.runtrack.model.User) : void
		{
			_user = value;
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
		
		private var _name:String;
		
		public function get Name() : String
		{
			return _name;
		} 
		
		public function set Name(value:String) : void
		{
			_name = value;
		}
		
		private var _preference:dk.runtrack.model.Preference;
		
		public function get Preference() : dk.runtrack.model.Preference
		{
			return _preference;
		} 
		
		public function set Preference(value:dk.runtrack.model.Preference) : void
		{
			_preference = value;
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
		
		private var _height:int;
		
		public function get Height() : int
		{
			return _height;
		} 
		
		public function set Height(value:int) : void
		{
			_height = value;
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
		
	} 
}