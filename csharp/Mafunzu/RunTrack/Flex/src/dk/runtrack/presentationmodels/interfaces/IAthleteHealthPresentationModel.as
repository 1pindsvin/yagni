package dk.runtrack.presentationmodels.interfaces
{
	[Bindable]
	public interface IAthleteHealthPresentationModel
	{
		function get weight() : String;
		function set weight(v: String) : void;
		
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

	}
}