package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.SetSelectedDateCommand;
	import dk.runtrack.commands.SetSelectedMonthCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.presentationmodels.interfaces.IMonthViewPresentationModel;

	[Bindable]
	public class MonthViewPresentationModel implements IMonthViewPresentationModel
	{

		public function MonthViewPresentationModel()
		{
			_date = new Date();
			_monthViewData = new MonthViewData(update);
			activities = new Array();
		}

		private function update() : void
		{
			var runspageDate : Date = _monthViewData.runsPage.ByDateTime;
			var activityCount : int = _monthViewData.runsPage.Runs.length;
			_monthViewData.monthQuery.updateActivity(runspageDate, activityCount);
			activities =  _monthViewData.monthQuery.DayActivities;
		}
		
		private var _date:Date;
		public function get date():Date
		{
			return _date;
		}

		public function set date(value: Date) : void
		{
			if(value==null)
			{
				return;
			}
			if(_date==value)
			{
				return;
			}
			_date=value;

			selectedMonthIndex = _date.month;
			selectedYear = _date.fullYear;
			
			if(!monthViewData.monthQuery.contains(_date))
			{
				var monthCommand : SetSelectedMonthCommand = new SetSelectedMonthCommand(_date);
				new RunTrackEvent(monthCommand).dispatch();	
			}
			var command : SetSelectedDateCommand = new SetSelectedDateCommand(_date);
			new RunTrackEvent(command).dispatch();
		}

		private var _state:String;
		public function get state():String
		{
			return _state;
		}

		private function set state(value: String) : void
		{
			_state=value;
		}

		private var _monthViewData : MonthViewData;
		public function get monthViewData() : MonthViewData
		{
			return _monthViewData;	
		}

		private function buildDateForMonth(monthDiff: int) : Date
		{
			var date : Date = 
				new Date(_date.fullYear, _date.month + monthDiff, _date.date, _date.hours, _date.minutes, _date.seconds, _date.milliseconds);
			return date;
					
		}
		
		public function previousMonth() : void
		{
			this.date = buildDateForMonth(-1);	
		}
		
		public function nextMonth() : void
		{
			this.date = buildDateForMonth(1);
		}
		
		public var activities : Array;
		
		public var selectedMonthIndex : int;

		public var selectedYear : int;
	}
}