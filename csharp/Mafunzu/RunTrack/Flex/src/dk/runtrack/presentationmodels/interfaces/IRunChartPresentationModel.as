package dk.runtrack.presentationmodels.interfaces
{

	[Bindable]
	public interface IRunChartPresentationModel
	{
		
		function get state():String;
		function set state(value: String) : void;
		
		function get runs() : Array;
		function set runs(value:Array) : void;
		
		function setRuns(runs:Array) : void;
		
	}
}
