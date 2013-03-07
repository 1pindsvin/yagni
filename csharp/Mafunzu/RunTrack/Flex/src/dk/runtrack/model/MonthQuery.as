package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.MonthQuery" )]
	public class MonthQuery
	{
		private function clearTimePart(date : Date) : Date
		{
			return new Date(date.fullYear, date.month, date.date, 0,0,0,0);
		}
		
		private function compareDates(x: Date, y:Date) : int
		{
			return x > y ? 1 : x < y ? -1 : 0;
		}

		public function updateActivity(date: Date, activityCount : int) : void
		{
			var dateWithOutTimePart : Date = clearTimePart(date);
			for each( var dayActivity : dk.runtrack.model.DayActivity in DayActivities)
			{
				if(compareDates(clearTimePart(dayActivity.Day), dateWithOutTimePart)==0)
				{
					dayActivity.ActivityCount = activityCount;
					return;
				}
			}
			throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", date is not in this  months range?");
		}
		
		public function contains(date : Date) : Boolean
		{
			if(date==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION);
			}
			return date >= Start && date <= End;
		}
		
		public function MonthQuery()
		{
			Start = new Date();
			End = Start;
			End.date -=1;
		}
		
		private var _athlete: dk.runtrack.model.Athlete;
		
		public function get Athlete() : dk.runtrack.model.Athlete
		{
			return _athlete;
		} 
		
		public function set Athlete(value:dk.runtrack.model.Athlete) : void
		{
			_athlete = value;
		}
		
		private var _year:int;
		
		public function get Year() : int
		{
			return _year;
		} 
		
		public function set Year(value:int) : void
		{
			_year = value;
		}
		
		private var _month:int;
		
		public function get Month() : int
		{
			return _month;
		} 
		
		public function set Month(value:int) : void
		{
			_month = value;
		}
		
		private var _weekStartsOnMonday:Boolean;
		
		public function get WeekStartsOnMonday() : Boolean
		{
			return _weekStartsOnMonday;
		} 
		
		public function set WeekStartsOnMonday(value:Boolean) : void
		{
			_weekStartsOnMonday = value;
		}
		
		private var _dayActivities:Array;
		
		public function get DayActivities() : Array
		{
			return _dayActivities;
		} 
		
		public function set DayActivities(value:Array) : void
		{
			_dayActivities = value;
		}
		
		private var _start:Date;
		
		public function get Start() : Date
		{
			return _start;
		} 
		
		public function set Start(value:Date) : void
		{
			_start = value;
		}
		
		private var _end:Date;
		
		public function get End() : Date
		{
			return _end;
		} 
		
		public function set End(value:Date) : void
		{
			_end = value;
		}
		
	} 
}