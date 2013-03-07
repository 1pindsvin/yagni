package dk.runtrack.model.interfaces
{
	import dk.runtrack.io.PersistentObject;
	
	import flash.events.IEventDispatcher;

	public interface IClientModel extends IEventDispatcher
	{
		function get shoes() : Array;
		function find(key : String) : PersistentObject;
		function set loadedShoes(value:Array) : void;
		
		function runHasBeenDeleted(runID : int) : void;
		function updateAndDelete(updatedAndNewShoes : Array, deletedShoes : Array) : void;
	}
}