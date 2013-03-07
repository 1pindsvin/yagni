package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.Run;
	import dk.runtrack.model.RunsPage;
	
	import mx.collections.IList;
	
	[Bindable]
	public interface IRunActivityPresentationModel
	{

		function get showUndo() : Boolean
		function set showUndo(v : Boolean) : void;

		function undoDelete() : void;
		
		function get showNavigatePageDialog() : Boolean;
		function set showNavigatePageDialog(value : Boolean) : void;
		
		function setRuns(runs : Array) : void;
		function get runs() : IList;
		function set runs(value:IList) : void;

		function get selectedRun() : Run;
		function set selectedRun(value:Run) : void;
		function set runsPage(value:RunsPage) : void
		function deleteSelectedRun() : void;
		function getPreviousItems() : void;
		function getNextItems() : void;
		function loadFirstRuns() : void;
		function loadLastRuns() : void;
		function sortRuns(orderByColumnName: String) : void;
		function get state():String;
		function updateState(suggestedState: String) :void ;
		function get status() : String; 
	}
}