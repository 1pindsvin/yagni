package dk.runtrack.presentationmodels.interfaces
{
	[Bindable]
	public interface IWeekdaysPresentationModel
	{
		function get selectedDays() : int;
		function set selectedDays(value:int) : void; 
		
		function get firstDayOfWeekSelected():Boolean;
		function set firstDayOfWeekSelected(value:Boolean):void;
		
		function get secondDayOfWeekSelected():Boolean;
		function set secondDayOfWeekSelected(value:Boolean):void;
		
		function get thirdDayOfWeekSelected():Boolean;
		function set thirdDayOfWeekSelected(value:Boolean):void;
		
		function get fourthDayOfWeekSelected():Boolean;
		function set fourthDayOfWeekSelected(value:Boolean):void;
		
		function get fifthDayOfWeekSelected():Boolean;
		function set fifthDayOfWeekSelected(value:Boolean):void;
		
		function get sixthDayOfWeekSelected():Boolean;
		function set sixthDayOfWeekSelected(value:Boolean):void;
		
		function get seventhDayOfWeekSelected():Boolean;
		function set seventhDayOfWeekSelected(value:Boolean):void;
	}
}