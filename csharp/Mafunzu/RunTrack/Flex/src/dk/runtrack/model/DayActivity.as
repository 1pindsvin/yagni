package dk.runtrack.model
{
	
	[RemoteClass( alias="DataService.Model.DayActivity" )]
	public class DayActivity
	{
		public function DayActivity()
		{
		}
		
		private var _day:Date;
		
		public function get Day() : Date
		{
			return _day;
		} 
		
		public function set Day(value:Date) : void
		{
			_day = value;
		}
		
		private var _activityCount:int;
		
		public function get ActivityCount() : int
		{
			return _activityCount;
		} 
		
		public function set ActivityCount(value:int) : void
		{
			_activityCount = value;
		}
		
	} 
}