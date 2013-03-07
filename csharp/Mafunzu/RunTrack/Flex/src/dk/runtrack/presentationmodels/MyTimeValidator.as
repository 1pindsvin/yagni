package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeFormatter;
	
	public class MyTimeValidator implements IValidator
	{
		private var _dateTimeFormatter : DateTimeFormatter;

		public function MyTimeValidator()
		{
			_dateTimeFormatter =  new DateTimeFormatter();	
		}

		public function isValid(data:String):Boolean
		{
			return data && _dateTimeFormatter.isTimeValid(data);
		}
		
	}
}