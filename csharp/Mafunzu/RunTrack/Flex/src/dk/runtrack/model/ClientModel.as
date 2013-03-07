package dk.runtrack.model
{
	import dk.runtrack.commands.shoe.DeleteAndUpdateShoesCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.io.DbOperation;
	import dk.runtrack.io.PersistentObject;
	import dk.runtrack.io.PersistentObjectEvent;
	import dk.runtrack.model.interfaces.IClientModel;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.events.IEventDispatcher;

	public class ClientModel implements IClientModel
	{
		private static var _data : ClientModel;
		public static function get data() : ClientModel
		{
			if(_data==null)
			{
				_data = new ClientModel();
			}
			return _data;
		}

		public function runHasBeenDeleted(runID : int) : void
		{
			dispatchRunDeletedEvent(runID);
		}
		
		private var _persistentItems : Array;
		public function find(key : String) : PersistentObject
		{
			for each(var persistentItem : PersistentObject in _persistentItems)
			{
				if(persistentItem.key==key)
				{
					return persistentItem;
				}
			}
			return null;
		}
		
		private function createDeleteDbOperation(shoe: Shoe) : DbOperation
		{
			var dbOperation : DbOperation = new DbOperation(shoe);
			dbOperation.Delete = true;
			return dbOperation;
		}
		
		private function updateDictionary(dictionary : Object, id : int) : void
		{
			if(dictionary[id]!=null)
			{
				throw new Error("key [" + id + "] was found in dictionary")
			}
			dictionary[id] = id;
		}
		
		
		public function updateAndDelete(updatedAndNewShoes : Array, deletedShoes : Array) : void
		{
			var dic : Object = {};
			var dbOperations : Array = new Array();
			
			var persistentDeletedShoes : Array = deletedShoes.filter(Shoe.filterPersistent);
			for each (var shoe : Shoe in persistentDeletedShoes)
			{
				dbOperations.push(createDeleteDbOperation(shoe));
				updateDictionary(dic, shoe.ID);
			}
			for each (var updatedShoe : Shoe in updatedAndNewShoes)
			{
				dbOperations.push(new DbOperation(updatedShoe));
				updateDictionary(dic, updatedShoe.ID);
			}
			if(dbOperations.length==0)
			{
				return;
			}
			new RunTrackEvent(new DeleteAndUpdateShoesCommand(dbOperations)).dispatch();
		}
		
		private function markShoeDeleted(shoe: Shoe) : void
		{
			var persistentShoe : PersistentObject = new PersistentObject(shoe);
			var existingPersistentShoe : PersistentObject = find(persistentShoe.key);
			existingPersistentShoe.deleted = true;	
		}
		
		
		public function set loadedShoes(value:Array) : void
		{
 			_persistentItems = value.concat();
 			dispatchShoesUpdatedEvent();
		} 
		
		public function get shoes() : Array
		{
			return _persistentItems.concat();
		}

		public function clear() : void
		{
			_persistentItems = new Array();
		}

		private function dispatchRunDeletedEvent(runID : int) : void
		{
			var event : PersistentObjectEvent = 
				new PersistentObjectEvent(PersistentObjectEvent.EVENT_RUN_DELETED);
			event.runID = runID;
			dispatchEvent(event);
		}
		
		private function dispatchShoesUpdatedEvent() : void
		{
			var event : PersistentObjectEvent = new PersistentObjectEvent(PersistentObjectEvent.EVENT_SHOES_UPDATED);
			dispatchEvent(event);
		}

		public static var createEventDispatcher : Function = function(target:IEventDispatcher) : IEventDispatcher
		{
			return new EventDispatcher(target);
		}
		
		private var _dispatcher:EventDispatcher;

		public function ClientModel()
		{
			if(_data!=null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
			}
			_persistentItems = new Array();
			this._dispatcher = createEventDispatcher(this);
		}

	    public function addEventListener(type:String, listener:Function, useCapture:Boolean = false, priority:int = 0, useWeakReference:Boolean = false):void
	    {
	        _dispatcher.addEventListener(type, listener, useCapture, priority);
	    }
	           
	    public function dispatchEvent(evt:Event):Boolean
	    {
	        return _dispatcher.dispatchEvent(evt);
	    }
	    
	    public function hasEventListener(type:String):Boolean
	    {
	        return _dispatcher.hasEventListener(type);
	    }
	    
	    public function removeEventListener(type:String, listener:Function, useCapture:Boolean = false):void
	    {
	        _dispatcher.removeEventListener(type, listener, useCapture);
	    }
	                   
	    public function willTrigger(type:String):Boolean 
	    {
	        return _dispatcher.willTrigger(type);
	    }

	}
}