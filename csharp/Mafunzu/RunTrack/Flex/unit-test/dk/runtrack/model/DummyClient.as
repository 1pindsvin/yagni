package dk.runtrack.model
{
	import dk.runtrack.io.PersistentObject;
	import dk.runtrack.model.interfaces.IClientModel;
	
	import flash.events.Event;

	public class DummyClient implements IClientModel
	{
		public static var calls : Object = new Object();
		
		private static function incrementCalls(name : String) : void
		{
			if(calls[name]==null)
			{
				calls[name] = 1;
			}
			else
			{
				calls[name] += 1;
			}
			
		}
		
		
		public function DummyClient()
		{
		}

		public function runHasBeenDeleted(runID : int) : void
		{

		}

		public function get shoes():Array
		{
			incrementCalls("shoes");
			return null;
		}
		
		public function find(key:String):PersistentObject
		{
			return null;
		}
		
		public function set loadedShoes(value:Array):void
		{
			incrementCalls("loadedShoes");
		}
		
		public function updateAndDelete(updatedAndNewShoes:Array, deletedShoes:Array):void
		{
		}
		
		public function addEventListener(type:String, listener:Function, useCapture:Boolean=false, priority:int=0, useWeakReference:Boolean=false):void
		{
		}
		
		public function removeEventListener(type:String, listener:Function, useCapture:Boolean=false):void
		{
		}
		
		public function dispatchEvent(event:Event):Boolean
		{
			return false;
		}
		
		public function hasEventListener(type:String):Boolean
		{
			return false;
		}
		
		public function willTrigger(type:String):Boolean
		{
			return false;
		}
		
	}
}