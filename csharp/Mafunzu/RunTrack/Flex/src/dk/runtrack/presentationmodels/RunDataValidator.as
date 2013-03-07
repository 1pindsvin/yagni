package dk.runtrack.presentationmodels
{
	import mx.events.ValidationResultEvent;
	import mx.validators.Validator;
	
	public class RunDataValidator
	{
		
		
		public function isDataValid() : Boolean
		{
		  	var dataIsvalid : Boolean =	 
		  			dateValidator.isValid(startDate) && 
					timeValidator.isValid(time) && 
					kilometerValidator.isValid(kilometers);
			return dataIsvalid;
		}
		
		private var _kilometers:String;

		public function get kilometers() : String
		{
			return _kilometers;
		} 

		public function set kilometers(value:String) : void
		{
			_kilometers = value;
		}

		private var _time:String;

		public function get time() : String
		{
			return _time;
		} 

		public function set time(value:String) : void
		{
			_time = value;
		}

		private var _startDate:String;

		public function get startDate() : String
		{
			return _startDate;
		} 

		public function set startDate(value:String) : void
		{
			_startDate = value;
		}

		private var _startTime:String;

		public function get startTime() : String
		{
			return _startTime;
		} 

		public function set startTime(value:String) : void
		{
			_startTime = value;
		}

		private var _kilometerValidator:IValidator;

		public function get kilometerValidator() : IValidator
		{
			return _kilometerValidator;
		} 

		public function set kilometerValidator(value:IValidator) : void
		{
			_kilometerValidator = value;
		}

		private var _timeValidator:IValidator;

		public function get timeValidator() : IValidator
		{
			return _timeValidator;
		} 

		public function set timeValidator(value:IValidator) : void
		{
			_timeValidator = value;
		}

		private var _dateValidator:IValidator;

		public function get dateValidator() : IValidator
		{
			return _dateValidator;
		} 

		public function set dateValidator(value:IValidator) : void
		{
			_dateValidator = value;
		}
 		
	}
}