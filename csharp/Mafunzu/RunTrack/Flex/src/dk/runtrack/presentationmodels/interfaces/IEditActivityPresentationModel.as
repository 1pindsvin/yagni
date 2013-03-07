package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.Activity;

	public interface IEditActivityPresentationModel
	{
		function get foreignSystemID() : String;
		function set foreignSystemID(value:String) : void;

		function get activityType() : int;
		function set activityType(value:int) : void;

		function get activitySubType() : int;
		function set activitySubType(value:int) : void;

		function get name() : String;
		function set name(value:String) : void;

		function get description() : String;
		function set description(value:String) : void;

		function get date() : Date;
		function set date(value:Date) : void;

		function get totalTime() : String;
		function set totalTime(value:String) : void;

		function get distance() : String;
		function set distance(value:String) : void;

		function get averageHeartRate() : int;
		function set averageHeartRate(value:int) : void;

		function get maximumHeartRate() : int;
		function set maximumHeartRate(value:int) : void;

		function get workload() : int;
		function set workload(value:int) : void;

		function get experience() : int;
		function set experience(value:int) : void;

		function get weather() : String;
		function set weather(value:String) : void;

		function get labels() : int;
		function set labels(value:int) : void;

		function get lastChanged() : Date;
		function set lastChanged(value:Date) : void;

		function get intensity() : String;
		function set intensity(value:String) : void;

		function get done() : Boolean;
		function set done(value:Boolean) : void;

		function get comments() : String;
		function set comments(value:String) : void;

		function get activitySubTypeSelectedIndex() : int;
		function set activitySubTypeSelectedIndex(value:int) : void;

		function get activityTypeSelectedIndex() : int;
		function set activityTypeSelectedIndex(value:int) : void;

		function get shoeSelectedIndex() : int;
		function set shoeSelectedIndex(value:int) : void;

		function get activitySubTypes() : Array;
		function set activitySubTypes(value:Array) : void;

		function get shoes() : Array;
		function set shoes(value:Array) : void;

		function get state() : String;
		function set state(value:String) : void;

		function get canSave() : Boolean;
		function set canSave(value:Boolean) : void;

		function get editActivity() : Activity;
		function set editActivity(value:Activity) : void;

		function save() : void;

		function saveAndGotoLog() : void;

	}
}
