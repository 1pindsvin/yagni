package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.Goal;

	[Bindable]
	public interface IEditGoalPresentationModel
	{
		function get hour():String;
		function set hour(value: String) : void;
		
		function get minute():String;
		function set minute(value: String) : void;
		
		function get second():String;
		function set second(value: String) : void;
		
		function get kilometers() : String;
		function set kilometers(value:String) : void;
		
		function set goal(value:Goal) : void
	}
}