package dk.runtrack.presentationmodels
{
	
	import mx.validators.RegExpValidator;
	import mx.validators.ValidationResult;

	public class KilometerValidator extends RegExpValidator
	{
		
		
		public function KilometerValidator()
		{
			super();
			this.expression = "^\\d+(" + resourceManager.getString('validators', 'decimalSeparator') +  "\\d+)?$"
			this.requiredFieldError = resourceManager.getString('validators', 'requiredFieldError');

		}

		protected override function doValidation(value:Object):Array
		{
			var  results : Array = [];
			results = super.doValidation(value);

			if(results.length==0)
			{
				return results;
			}
			results = []; //Flex crap messages cleared
			var isError : Boolean = true;
			var errorMessage : String = resourceManager.getString('validationerror','kilometer');
			var validationResult : ValidationResult = new ValidationResult(isError,"","", errorMessage);
			results.push(validationResult);
			return results; 
		}

	}
}