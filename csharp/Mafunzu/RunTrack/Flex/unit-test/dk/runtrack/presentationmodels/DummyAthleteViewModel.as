package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Athlete;
	import dk.runtrack.presentationmodels.interfaces.IEditAthletePresentationModel;

	[Bindable]
	public class DummyAthleteViewModel implements IEditAthletePresentationModel
	{
		public function DummyAthleteViewModel()
		{
		}

		private var _canSave : Boolean;
		
		private var _state:String;

		public function get canSave():Boolean
		{
			return _canSave;
		}

		public function set canSave(value:Boolean):void
		{
			_canSave = value;
		}

		public function get state():String
		{
			return _state;
		}
		public function set state(value: String) : void
		{
			_state=value;
		}

		private var _currentathlete : Athlete;
		public function set currentathlete(value:Athlete):void
		{
			_currentathlete = value;
		}
		
		public function get currentathlete():Athlete
		{
			return _currentathlete;
		}
		
		public function save():void
		{
		}
		
		public function load():void
		{
		}
		
		public function get firstName():String
		{
			return null;
		}
		
		public function set firstName(value:String):void
		{
		}
		
		public function get lastName():String
		{
			return null;
		}
		
		public function set lastName(value:String):void
		{
		}
		
		public function get dateOfBirth():Date
		{
			return null;
		}
		
		public function set dateOfBirth(value:Date):void
		{
		}
		
		public var weight : String;
		public var height : String;
		
		private var _bmi:String;
		
		public function get bmi() : String
		{
			return _bmi;
		}
		
		public function set bmi(value:String) : void
		{
			_bmi = value;
		}
		
		private var _waist:String;
		
		public function get waist() : String
		{
			return _waist;
		}
		
		public function set waist(value:String) : void
		{
			_waist = value;
		}
		
		private var _thigh:String;
		
		public function get thigh() : String
		{
			return _thigh;
		}
		
		public function set thigh(value:String) : void
		{
			_thigh = value;
		}
		
		private var _arm:String;
		
		public function get arm() : String
		{
			return _arm;
		}
		
		public function set arm(value:String) : void
		{
			_arm = value;
		}
		
		private var _restingHeartRate:String;
		
		public function get restingHeartRate() : String
		{
			return _restingHeartRate;
		}
		
		public function set restingHeartRate(value:String) : void
		{
			_restingHeartRate = value;
		}
		
		private var _maximumHeartRate:String;
		
		public function get maximumHeartRate() : String
		{
			return _maximumHeartRate;
		}
		
		public function set maximumHeartRate(value:String) : void
		{
			_maximumHeartRate = value;
		}
		
		private var _thresholdHeartRate:String;
		
		public function get thresholdHeartRate() : String
		{
			return _thresholdHeartRate;
		}
		
		public function set thresholdHeartRate(value:String) : void
		{
			_thresholdHeartRate = value;
		}
		
	}
}