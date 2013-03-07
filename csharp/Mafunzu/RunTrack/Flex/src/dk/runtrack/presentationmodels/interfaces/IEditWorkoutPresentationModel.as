package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.Workout;

	[Bindable]
	public interface IEditWorkoutPresentationModel
	{
		function get description() : String;
		function set description(value:String) : void;
		
		function get type() : int;
		function set type(value:int) : void;
		
		function get distance() : String;
		function set distance(value:String) : void;
		
		function get start() : Date;
		function set start(value:Date) : void;
		
		function get workoutTypeSelectedIndex() : int;
		function set workoutTypeSelectedIndex(value:int) : void;
		
		function get state() : String;
		function set state(value:String) : void;
		
		function get canSave() : Boolean;
		function set canSave(value:Boolean) : void;
		
		function get editWorkout() : Workout;
		function set editWorkout(value:Workout) : void;
		
		function save() : void;
		
	}
}