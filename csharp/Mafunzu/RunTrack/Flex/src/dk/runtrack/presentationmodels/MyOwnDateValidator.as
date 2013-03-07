package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeFormatter;
	
	public class MyOwnDateValidator implements IValidator
	{
		private var _dateTimeFormatter : DateTimeFormatter;

		public function MyOwnDateValidator()
		{
			_dateTimeFormatter = new DateTimeFormatter();
		}

		public function isValid(data:String):Boolean
		{
			return data && _dateTimeFormatter.isDateTimeValid(data);
		}
		
	}
}