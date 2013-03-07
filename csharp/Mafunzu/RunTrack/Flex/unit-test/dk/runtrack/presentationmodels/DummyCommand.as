package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.events.IEventDispatcher;

	public class DummyCommand implements IRtCommand, IEventDispatcher
	{
		
		public static const EVENT_EXECUTE_CALLED : String = "execute.called.event";
		
		
		public var executeCallCount : int;
		public var callBackFunction:Function;

		public function DummyCommand()
		{
	        dispatcher = new EventDispatcher(this);
		}

		public function execute():void
		{
			executeCallCount+=1;
			dispatchEvent(new Event(EVENT_EXECUTE_CALLED));
		}
		
	    private var dispatcher:EventDispatcher;
	               
	    public function addEventListener(type:String, listener:Function, useCapture:Boolean = false, priority:int = 0, useWeakReference:Boolean = false):void{
	        dispatcher.addEventListener(type, listener, useCapture, priority);
	    }
	           
	    public function dispatchEvent(evt:Event):Boolean{
	        return dispatcher.dispatchEvent(evt);
	    }
	    
	    public function hasEventListener(type:String):Boolean{
	        return dispatcher.hasEventListener(type);
	    }
	    
	    public function removeEventListener(type:String, listener:Function, useCapture:Boolean = false):void{
	        dispatcher.removeEventListener(type, listener, useCapture);
	    }
	                   
	    public function willTrigger(type:String):Boolean {
	        return dispatcher.willTrigger(type);
	    }
		
	}
}