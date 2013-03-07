package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.athlete.SaveAthleteCommand;
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Converter;
	import dk.runtrack.presentationmodels.interfaces.IEditAthletePresentationModel;
	
	[Bindable]	
	public class EditAthletePresentationModel implements IEditAthletePresentationModel
	{
		
		
		private static const STATE_ATHLETE_SAVED : String = "profile.saved";      
		private static const STATE_READY_JUST_SHOW_TITLE : String = "title";      
		
		
		private var _state:String;
		private var _isSaving : Boolean;
		
		public function get height():String
		{
			return _height;
		}
		
		public function set height(value:String):void
		{
			_height = value;
			update();
		}
		
		public function get weight():String
		{
			return _weight;
		}
		
		public function set weight(value:String):void
		{
			_weight = value;
			update();
		}
		
		public function get state():String
		{
			return _state;
		}
		
		public function set state(value: String) : void
		{
			_state=value;
		}
		
		public var canSave : Boolean;
		
		private var _currentAthlete:Athlete;		
		
		public function EditAthletePresentationModel()
		{
			canSave = false;
			_isSaving = false;
			dateOfBirth = new Date();
			_currentAthlete = null;
		}
		
		public function get currentathlete() : Athlete
		{
			return _currentAthlete;
		}
		
		public function set currentathlete(value:Athlete) : void
		{
			setCurrentAthlete(value);
		}
		
		private var _firstName : String;
		
		public function get firstName():String
		{
			return _firstName;
		}
		
		public function set firstName(value:String):void
		{
			_firstName = value;
			update()
		}
		
		private var _lastName : String;
		
		public function get lastName():String
		{
			return _lastName;
		}
		
		public function set lastName(value:String):void
		{
			_lastName = value;
			update()
		}
		
		private var _dateOfBirth : Date;
		
		public function get dateOfBirth():Date
		{
			return _dateOfBirth;
		}
		
		public function set dateOfBirth(value:Date):void
		{
			_dateOfBirth = value;
			update()
		}
		
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
		
		
		
		
		private function update() : void
		{
			var converter : Converter = new Converter();
			this.state =STATE_READY_JUST_SHOW_TITLE;
			
			bmi = converter.bmi(converter.asInteger(height), converter.toDatabaseWeight(weight));
		}
		
		private var _weight : String;
		private var _height : String;
		
		public function save() : void
		{
			canSave = false;
			_isSaving = true;
			
			var converter : Converter = new Converter();
			
			_currentAthlete.FirstName =  _firstName;
			_currentAthlete.LastName = _lastName;
			
			
			_currentAthlete.Height = converter.asInteger(height);
			_currentAthlete.Weight = weight ? converter.toDatabaseWeight(weight) : Converter.NULL_INT_VALUE;
			_currentAthlete.MaximumHeartRate = converter.asInteger(maximumHeartRate);
			_currentAthlete.RestingHeartRate = converter.asInteger(restingHeartRate);
			_currentAthlete.Thigh = converter.asInteger(thigh);
			_currentAthlete.ThresholdHeartRate = converter.asInteger(thresholdHeartRate);
			_currentAthlete.Waist = converter.asInteger(waist);
			_currentAthlete.Arm = converter.asInteger(arm);
			
			
			_currentAthlete.DateOfBirth = dateOfBirth;

			var command : IRtCommand = new SaveAthleteCommand(_currentAthlete);
			new RunTrackEvent(command).dispatch();
		} 
		
		private function setCurrentAthlete(v: Athlete) : void
		{
			_currentAthlete = v;			
			
			var converter : Converter = new Converter();
			
			_firstName = _currentAthlete.FirstName;
			_lastName = _currentAthlete.LastName;
			_height = converter.asString( _currentAthlete.Height);
			_weight = _currentAthlete.Weight != Converter.NULL_INT_VALUE ?  converter.toLocaleText( converter.fromDatabaseWeight(_currentAthlete.Weight)) : "" ;
			_arm=converter.asString(_currentAthlete.Arm);			
			_bmi = converter.bmi( _currentAthlete.Height, _currentAthlete.Weight);
			_dateOfBirth = _currentAthlete.DateOfBirth;
			_maximumHeartRate = converter.asString( _currentAthlete.MaximumHeartRate);
			_restingHeartRate = converter.asString(_currentAthlete.RestingHeartRate);
			_thigh = converter.asString(_currentAthlete.Thigh);
			_thresholdHeartRate = converter.asString(_currentAthlete.ThresholdHeartRate);
			_waist = converter.asString(_currentAthlete.Waist);
			
			if(_isSaving)
			{
				_isSaving = false;
				this.state = STATE_ATHLETE_SAVED;
			}
			canSave=true;
			
		}
		
	}
}