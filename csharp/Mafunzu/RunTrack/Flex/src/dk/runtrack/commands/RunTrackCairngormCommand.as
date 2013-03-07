package dk.runtrack.commands
{
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import dk.runtrack.commands.interfaces.IRtCommand;
	
	import dk.runtrack.events.RunTrackEvent;

	public class RunTrackCairngormCommand implements ICommand
	{
		public function RunTrackCairngormCommand()
		{
		}

		public function execute(event:CairngormEvent):void
		{
			var runTrackEvent : RunTrackEvent = RunTrackEvent(event);
			var command : IRtCommand = runTrackEvent.runTrackCommand;
			command.execute();
		}
		
	}
}