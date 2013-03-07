package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;

	public class NullDateTimeEnvironment implements IDateTimeEnvironment
	{
		public function NullDateTimeEnvironment()
		{
		}

		public function get dateIndex():uint
		{
			return 0;
		}
		
		public function get monthIndex():uint
		{
			return 1;
		}
		
		public function get yearIndex():uint
		{
			return 2;
		}
		
		public function get dateSeparator():String
		{
			return "null";
		}
		
		public function get timeSeparator():String
		{
			return "null";
		}
		
		public function get dateFormat():String
		{
			return "dateFormat";
		}
		
		public function get timeFormat():String
		{
			return "timeFormat";
		}
		
	}
}