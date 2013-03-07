package dk.runtrack.events
{
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.TypeResolver;
	
	import flash.events.Event;

	public class RunTrackEvent extends CairngormEvent
	{
		public static const EVENT_RUN_TRACK_ACTION:String = "runTrackActionEvent";

		public function RunTrackEvent(runTrackCommand : IRtCommand, bubbles:Boolean=false, cancelable:Boolean=false)
		{
/* 			//must register in cairngorm
			var  type : String = TypeResolver.getTypeName(runTrackCommand);
			type = type.toUpperCase() + "ActionEvent";
 */			
			super(EVENT_RUN_TRACK_ACTION, bubbles, cancelable);
			if(runTrackCommand==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
			}
			_runTrackCommand = runTrackCommand;
		}
		
		public override function clone():Event
		{
			return new RunTrackEvent(runTrackCommand, this.bubbles, this.cancelable);
		}
		
		private var _runTrackCommand : IRtCommand;
		public function get runTrackCommand() : IRtCommand
		{
			return _runTrackCommand;
		}

		public function set runTrackCommand(value : IRtCommand) : void
		{
			_runTrackCommand = value;
		}
		
	}
}