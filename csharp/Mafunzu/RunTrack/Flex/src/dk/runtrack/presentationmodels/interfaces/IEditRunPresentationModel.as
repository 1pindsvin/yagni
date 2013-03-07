package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Run;
	
	import mx.collections.IList;
	
	
	[Bindable]
	public interface IEditRunPresentationModel //extends  ITimeInputViewModel
	{
		
		function set editRun(run : Run) : void;
		
		function get averageSpeed() : String;
		function set averageSpeed(value:String) : void;
		
		function get hour():String;
		function set hour(value: String) : void;

		function get minute():String;
		function set minute(value: String) : void;

		function get second():String;
		function set second(value: String) : void;

		function get kilometers() : String;
		function set kilometers(value:String) : void;

		function get startDate() : Date;
		function set startDate(value:Date) : void;

		function set currentathlete(value:Athlete) : void;
		
		function get selectedIndex() : int;
		function set selectedIndex(v: int) : void;
		
		function setAthleteShoes(v: Array) : void;
		function get athleteShoes() : IList;
		function set athleteShoes(v: IList) : void;

		function get canSave():Boolean;
		function set canSave(value:Boolean):void;

		function get state():String;
		
		function updateState(suggestedState: String) :void ;

		function save() : void;
	}
}