package dk.runtrack.model
{
	import mx.resources.IResourceManager;
	import mx.resources.ResourceManager;
	
	
	public class DistanceFormatter
	{
		public static const VALIDATOR_BUNDLE_NAME : String = "validators"; 
		public static const DECIMAL_SEPARATOR_NAME : String = "decimalSeparator";

		public static const COMMONWORDS_BUNDLE_NAME : String = "commonWords"; 
		public static const KILOMETERS_NAME : String = "KILOMETERS";
		public static const MINUTES_NAME : String = "MINUTES";
		public static const SECONDS_NAME : String = "SECONDS";
		
		
		
		
		public static var resolveDecimalSeparator : Function = 
			function() : String
			{
				return ResourceManager.getInstance().getString(VALIDATOR_BUNDLE_NAME,DECIMAL_SEPARATOR_NAME); 				 
			}
		
		private static function get resourceManager() : IResourceManager
		{
			return ResourceManager.getInstance();
		}
		
		
		public function get decimalSeparator() : String
		{
			return resolveDecimalSeparator();
		}
		
		private function get kilometerLocaleName() : String
		{
			return resourceManager.getString(COMMONWORDS_BUNDLE_NAME, KILOMETERS_NAME);
		}

		private function get minutesLocaleName() : String
		{
			return resourceManager.getString(COMMONWORDS_BUNDLE_NAME, MINUTES_NAME);
		}

		private function get secondsLocaleName() : String
		{
			return resourceManager.getString(COMMONWORDS_BUNDLE_NAME, SECONDS_NAME);
		}

		
		public function DistanceFormatter()
		{

		}
		
		public function toMinutesPrKilometer(wholeMinuttes : int , fractionSeconds : int) : String
		{
			if(wholeMinuttes==0 && fractionSeconds==0)
			{
				return "";
			}
			return ([wholeMinuttes, Format.formatTwoDigit(fractionSeconds)]).join(":");
		}
		
		public function localeFormat(numberString : String) : String
		{
			return numberString.replace("\.", decimalSeparator);
		}
		
		public function toLocaleText(distance : Number) : String
		{
			var kilometerText : String =  String(distance).replace("\.", decimalSeparator);
			return kilometerText;
		}	
			
		public function fromDatabaseDistance(distance:int) : Number
		{
			var kilometers : Number = distance/1000;
			return kilometers; 
		}

		public function toDatabaseDistance(distance : String) : uint
		{
			var distanceWithSeparator : String = distance.replace(decimalSeparator, "\.");
			var distanceMeters : uint = parseFloat(distanceWithSeparator) * 1000;
			return distanceMeters;
		}

	}
}