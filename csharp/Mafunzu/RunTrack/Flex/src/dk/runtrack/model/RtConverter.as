package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IRtConverter;
	
	import mx.resources.ResourceManager;
	
	public class RtConverter implements IRtConverter
	{

		public static const NULL_INT_VALUE : int = -1;
		
		public static var resolveDecimalSeparator : Function = 
			function() : String
			{
				return ResourceManager.getInstance().getString(Constants.VALIDATOR_BUNDLE_NAME, Constants.DECIMAL_SEPARATOR_NAME); 				 
			}

			
		protected var _numberOfDecimals :int;
		public function RtConverter(numberOfDecimals : int)
		{
			_numberOfDecimals = numberOfDecimals;
		}
		
		protected function get decimalSeparator() : String
		{
			return resolveDecimalSeparator();
		}

		
		private function fromDatabase(value : int) : Number
		{
			var result : Number = value/Math.pow(10,_numberOfDecimals);
			return result; 
		}

		private function toLocaleText(number : Number) : String
		{
			var numberText : String = number.toFixed(_numberOfDecimals).replace("\.", decimalSeparator);
			return numberText;
		}	

		public function toPresentationValue(dbValue:int):String
		{
			return toLocaleText(fromDatabase(dbValue));
		}
		
		public function toDbValue(presentationValue:String):int
		{
			var s : String = presentationValue.replace(decimalSeparator, "\.");
			var result : int = parseFloat(s) * Math.pow(10, _numberOfDecimals);
			return result;
		}
	}
}