package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.Athlete;
	
	import mx.collections.ArrayCollection;
	
	[Bindable]
	public interface IEditShoePresentationModel
	{
		function set loadedShoes(value:Array) : void;
		function set currentathlete(value:Athlete) : void;

		function get athleteShoes() : ArrayCollection;
		function set athleteShoes(v: ArrayCollection) : void;

		function get showInActiveShoes() : Boolean;
		function set showInActiveShoes(value:Boolean) : void;

		function get selectedIndex() : int;
		function set selectedIndex(v : int) :void;

		function addShoe() : void;
		function deleteSelected() : void;
		
		function get canDeleteSelected() : Boolean;
		
		function get state() : String;
		
		function get status() : String;
		
		function save() : void;
	}
}