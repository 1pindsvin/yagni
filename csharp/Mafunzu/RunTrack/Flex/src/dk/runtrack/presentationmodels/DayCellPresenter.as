package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.SetSelectedDateCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.DayActivity;
	import dk.runtrack.presentationmodels.interfaces.IDayCellPresenter;
	

	public class DayCellPresenter implements IDayCellPresenter
	{
		public function DayCellPresenter()
		{

		}

		[Bindable]
		public var day : String;

		[Bindable]
		public var activityCount:int
		
		[Bindable]
		private var _selected :Boolean;
		
		public function get selected():Boolean
		{
			return _selected;
		}

		public function set selected(value:Boolean):void
		{
			_selected = value;
			var command : SetSelectedDateCommand = new SetSelectedDateCommand(_dayActivity.Day);
			new RunTrackEvent(command).dispatch();
		}

		public function get isInCurrentMonth():Boolean
		{
			return false;
		}
		
		public function set isInCurrentMonth(value:Boolean):void
		{
		}
		
		
		private var _dayActivity : DayActivity;
		public function set dayActivity(v: DayActivity):void
		{
			_dayActivity = v;
			activityCount = _dayActivity.ActivityCount;
			day = _dayActivity.Day.date.toString();
		}
	}
}