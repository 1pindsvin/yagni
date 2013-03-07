package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeEnvironment;
	import dk.runtrack.model.DateTimeFormatter;
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	
	import mx.validators.ValidationResult;
	import mx.validators.Validator;

	public class TimeValidator extends Validator
	{

		public static var resolveDateTimeInvironment : Function =
			function() : IDateTimeEnvironment
			{
				return new DateTimeEnvironment();
			}


		private var _dateTimeEnvironment : IDateTimeEnvironment;
		
		
		private function getRequiredFieldError() :String
		{
			try
			{
				return resourceManager.getString('validators', 'requiredFieldError');
			}
			catch(error:Error)
			{
			}
			return "resourcemanager-not-available";	
		}
		
		public function TimeValidator()
		{
			super();
			subFields = [ "hour", "minute", "second" ];
			this.requiredFieldError = getRequiredFieldError();
			_dateTimeEnvironment = resolveDateTimeInvironment();
		}
		
		private var _inputFormat:String;
		public function get inputFormat():String
		{
			return _inputFormat;
		}

		public function set inputFormat(value:String):void
		{
			_inputFormat = value != null ?  value : _dateTimeEnvironment.timeFormat;
		}

		protected override function resourcesChanged():void
		{
			super.resourcesChanged();
			this.requiredFieldError = getRequiredFieldError();
		}
		
		protected override function doValidation(value:Object):Array
		{
			var results : Array = [];
			results = super.doValidation(value);
		
			var dateTimeFormatter : DateTimeFormatter = new DateTimeFormatter();
			
			if(dateTimeFormatter.isTimeValid(String(value)))
			{
				return results;
			}
			
			var isError : Boolean = true;
			var errorMessage : String = "validationerrors_timevalidator";
			var validationResult : ValidationResult = new ValidationResult(isError,"","", errorMessage);
			results.push(validationResult);
			return results; 
		}
	}
}