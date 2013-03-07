package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.Athlete;
	
	[Bindable]
	public interface IEditAthletePresentationModel
	{
		function get canSave():Boolean;
		function set canSave(value: Boolean) : void;

		function get state():String;
		function set state(value: String) : void;

		function set currentathlete(value:Athlete) : void;
		function get currentathlete() : Athlete;

		function get firstName():String
		function set firstName(value:String):void
		
		function get lastName():String
		function set lastName(value:String):void
		
		function get dateOfBirth():Date
		function set dateOfBirth(value:Date):void
			
		function get weight() : String;
		function set weight(v: String) : void;
		
		function get height() : String;
		function set height(v: String) : void;

		function get bmi() : String;
		function set bmi(v: String) : void;
		
		function get waist() : String;
		function set waist(v: String) : void;
		
		function get thigh() : String;
		function set thigh(v: String) : void;
		
		function get arm() : String;
		function set arm(v: String) : void;
		
		function get restingHeartRate() : String;
		function set restingHeartRate(v: String) : void;
		
		function get maximumHeartRate() : String;
		function set maximumHeartRate(v: String) : void;
		
		function get thresholdHeartRate() : String;
		function set thresholdHeartRate(v: String) : void;

		function save() : void
	}
}