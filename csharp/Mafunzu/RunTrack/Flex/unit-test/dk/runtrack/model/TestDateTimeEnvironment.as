package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;

	public class TestDateTimeEnvironment extends DateTimeEnvironment
	{
		private var _dateFormat :String = "DD-MM-YYYY";
		public override function get dateFormat() : String
		{
			return _dateFormat;
		}

		public function setUSLocale() : void
		{
			_dateFormat = "MM/DD/YYYY";
			resolveDateParts();
		}

	}
}