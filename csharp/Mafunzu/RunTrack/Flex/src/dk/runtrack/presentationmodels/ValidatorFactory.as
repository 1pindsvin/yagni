package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeEnvironment;
	import dk.runtrack.model.DateTimeFormatter;
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	
	import mx.resources.ResourceManager;
	import mx.validators.Validator;
	
	public class ValidatorFactory
	{

		private var _dateTimeFormatter : DateTimeFormatter; 
		private var _dateTimeEnvironment : IDateTimeEnvironment;


		public function ValidatorFactory()
		{
			_dateTimeFormatter  = new DateTimeFormatter();
			_dateTimeEnvironment  = new DateTimeEnvironment();
		}
		
		
		
		public function get dateTimeFormatter() : DateTimeFormatter
		{
			return _dateTimeFormatter;
		}

		public function createRunDataValidator() : RunDataValidator
		{
			var r : RunDataValidator = new RunDataValidator();
			r.dateValidator = new MyOwnDateValidator();
			r.kilometerValidator = new MyKilometerValidator();
			r.timeValidator = new MyTimeValidator();
			return r;	
		}

		public function createDateValidator() : Validator
		{
			var dateValidator : MyDateValidator = new MyDateValidator();
			dateValidator.property = "text";
			dateValidator.inputFormat = _dateTimeEnvironment.dateFormat; 
			return dateValidator;
		}
		
		public function createKilometerValidator() : Validator
		{
			var	kilometerValidator : KilometerValidator = new KilometerValidator();
			kilometerValidator.property = "text";
			return kilometerValidator;
		}
		
		public function createTimeValidator() : Validator
		{
			var timeValidator : TimeValidator = new TimeValidator();
			timeValidator.property = "text";
			timeValidator.inputFormat = _dateTimeEnvironment.timeFormat;
			return timeValidator;
		}
		
		public function createRegexDateRestriction() : RegExp
		{
			var dateSeparator : String = _dateTimeEnvironment.dateSeparator;
			var regexpParts : Array = ["^\\d{1,2}", "\\d{1,2}", "\\d{2,4}$"];
			var e : RegExp = new RegExp(regexpParts.join(dateSeparator));
			return e;
		}

		public function createDateRestriction() : String
		{
			var restrict : String = ([ "\\" + _dateTimeEnvironment.dateSeparator, "0-9"]).join("");
			return restrict;
		}
		
		public function createTimeRestriction() : String
		{
			var restrict : String = ([_dateTimeEnvironment.timeSeparator, "0-9"]).join("");
			return restrict;
		}

		public function createKilometerRestriction() : String
		{
			var restrict : String = (["\\" + ResourceManager.getInstance().getString('validators', 'decimalSeparator') , "0-9"]).join("");
			return restrict;
		}
		
		
	}
}