package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeFormatter;
	
	import mx.validators.ValidationResult;
	import mx.validators.Validator;

	public class MyDateValidator extends Validator
	{
		private function resolveRequiredFieldError() : String
		{
			return resourceManager.getString('validators', 'requiredFieldError');
		}

		public function MyDateValidator()
		{
			super();
			this.requiredFieldError = resolveRequiredFieldError();
		}

		private var _inputFormat:String;
		public function get inputFormat():String
		{
			return _inputFormat;
		}
	 	 
		public function set inputFormat(value:String):void
		{
			_inputFormat = value != null ?  value : resourceManager.getString('SharedResources', 'dateFormat');
		}
		
		protected override function doValidation(value:Object):Array
		{
			var results : Array = [];
			results = super.doValidation(value);
		
			var dateTimeFormatter : DateTimeFormatter = new DateTimeFormatter();
			if(dateTimeFormatter.isDateValid(String(value)))
			{
				return results;
			}
			
			var isError : Boolean = true;
			var errorMessage : String = resourceManager.getString('validationerror', 'date');
			var validationResult : ValidationResult = new ValidationResult(isError,"","", errorMessage);
			results.push(validationResult);
			return results; 
		}
		
	}
}