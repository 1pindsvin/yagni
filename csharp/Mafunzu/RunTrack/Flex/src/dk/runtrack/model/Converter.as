package dk.runtrack.model
{
	import mx.resources.ResourceManager;

	public class Converter
	{
		public static const NULL_INT_VALUE : int = -1;

		public static var resolveDecimalSeparator : Function = 
			function() : String
			{
				return ResourceManager.getInstance().getString(Constants.VALIDATOR_BUNDLE_NAME, Constants.DECIMAL_SEPARATOR_NAME); 				 
			}
			
		public function Converter()
		{

		}
		
		public function bmi(heightInTenthOfmm : Number, weightInGram : Number) : String
		{
			if(heightInTenthOfmm == NULL_INT_VALUE || weightInGram ==NULL_INT_VALUE)
			{
				return "";
			}
			var result : Number = ( weightInGram/ Math.pow(heightInTenthOfmm/10000, 2) )/1000;
			return toLocaleText(result);
		}
		
		private function get decimalSeparator() : String
		{
			return resolveDecimalSeparator();
		}

		public function asString(value : int) : String
		{
			return value == NULL_INT_VALUE ? "" : toLocaleText(fromDatabase(value));
		}
		
		public function asInteger(value : String) : int
		{
			return value ? toDatabase(value) : NULL_INT_VALUE;
		}
		
		public function toLocaleText(number : Number) : String
		{
			var numberText : String = number.toFixed(2).replace("\.", decimalSeparator);
			return numberText;
		}	

		public function fromDatabase(value : int) : Number
		{
			var result : Number = value/100;
			return result; 
		}
		
		public function toDatabase(value : String) : int
		{
			var s : String = value.replace(decimalSeparator, "\.");
			var result : int = parseFloat(s) * 100;
			return result;
		}

		
		public function toDatabaseWeight(weight : String) : int
		{
			if(!weight)
			{
				return NULL_INT_VALUE;
			}
			var weightWithSeparator : String = weight.replace(decimalSeparator, "\.");
			var weightInGram : int = parseFloat(weightWithSeparator) * 1000;
			return weightInGram;
		}
		
		public function fromDatabaseWeight(weight : int) : Number
		{
			var weightInKiloGram : Number = weight/1000;
			return weightInKiloGram; 
		}
	}
}