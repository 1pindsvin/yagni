package dk.runtrack.model
{
	public class Format
	{
		public function Format()
		{
		}

		public static function formatTwoDigit(number:int) : String
		{
			var numberToString : String = number.toString(); 
			return numberToString.length ==1 ? "0" + numberToString : numberToString; 
		}
		
		public static function formatError(error:Object) : String
		{
			if(error==null)
			{
				return "Could not formatError. error was null?";
			}
			var message : String;
			try
			{
				message = error.toString();
			}
			catch(error:Error)
			{
				message = "Could not invoke toString on error object. [" + error.message + "]" ;
			}
			return message;

		}
	}
}