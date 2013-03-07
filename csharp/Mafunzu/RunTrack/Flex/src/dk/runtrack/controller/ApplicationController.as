package dk.runtrack.controller
{
	import com.adobe.cairngorm.control.FrontController;
	
	import dk.runtrack.commands.RunTrackCairngormCommand;
	import dk.runtrack.events.RunTrackEvent;

	public class ApplicationController extends FrontController
	{
		public function ApplicationController()
		{
			super();
			setupCommands();
		}
		
		public function setupCommands() : void
		{
			//Generic command - the only needed?
			addCommand(RunTrackEvent.EVENT_RUN_TRACK_ACTION, RunTrackCairngormCommand);
		}

		
	}
}