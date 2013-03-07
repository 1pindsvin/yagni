package dk.runtrack.presentationmodels
{
	import mx.resources.ResourceManager;
	
	
	public class MyKilometerValidator implements IValidator
	{
		private var _pattern :String;
		
		private function getDecimalSeparator() : String
		{
			return ResourceManager.getInstance().getString('validators', 'decimalSeparator');
		}
		
		public function MyKilometerValidator()
		{
			
			_pattern = "^\\d+(" + getDecimalSeparator() +  "\\d+)?$";
		}

		public function isValid(data:String):Boolean
		{
			var isValidStr : Boolean = data && data.match(_pattern);
			return isValidStr;
		}
		
	}
}