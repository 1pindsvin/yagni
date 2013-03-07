package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.AthleteHealth;
	import dk.runtrack.model.AthleteHealthQuery;

	[Bindable]
	public interface IAthleteHealthHistoryPresentationModel
	{
		function get state() : String;
		function set state(value:String) : void;

		function get healths() : Array;
		function set healths(value:Array) : void;

		function get selectedAthleteHealth() : AthleteHealth;
		function set selectedAthleteHealth(value:AthleteHealth) : void;

		function get showUndo() : Boolean;
		function set showUndo(value:Boolean) : void;

		function get showNavigatePage() : Boolean;
		function set showNavigatePage(value:Boolean) : void;

		function undoDelete() : void;

		function deleteSelected() : void;

		function sortBy(name:String) : void;

		function previous() : void;

		function next() : void;

		function last() : void;

		function first() : void;

		function navigateTo(page:int) : void;

		function setAthleteHealthQuery(query:AthleteHealthQuery) : void;

	}
}