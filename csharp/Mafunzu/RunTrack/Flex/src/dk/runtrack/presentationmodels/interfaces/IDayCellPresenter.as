package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.DayActivity;
	
	[Bindable]
	public interface IDayCellPresenter
	{
		function get day() : String;
		function set day(value:String) : void;
		
		function get activityCount() : int;
		function set activityCount(value:int) : void;
		
		function get selected() : Boolean;
		function set selected(value:Boolean) : void;
		
		function get isInCurrentMonth() : Boolean;
		function set isInCurrentMonth(value:Boolean) : void;
		
		function set dayActivity(v: DayActivity) : void;
		
	}
	
	
}