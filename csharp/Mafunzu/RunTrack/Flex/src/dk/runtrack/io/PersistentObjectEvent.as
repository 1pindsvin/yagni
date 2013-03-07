package dk.runtrack.io
{
	import flash.events.Event;

	public class PersistentObjectEvent extends Event
	{
		public static const EVENT_SHOES_UPDATED : String = "shoesUpdatedEvent";
		public static const EVENT_RUN_DELETED : String = "runDeletedEvent";
		
		public var runID : int;

		public function PersistentObjectEvent(type:String, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
		}
		
	}
}