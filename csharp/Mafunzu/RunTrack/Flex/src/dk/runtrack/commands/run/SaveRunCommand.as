package dk.runtrack.commands.run
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.Run;
	import dk.runtrack.responders.SaveRunResponder;
	
	import mx.rpc.IResponder;

	public class SaveRunCommand extends RtCommand
	{
		
		public static var resolveResponder : Function =
			function() : IResponder
			{
				return new SaveRunResponder();
			}
		
		private var _run : Run;
		public function SaveRunCommand(run: Run)
		{
			super();
			if(run==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", SaveRunCommand, run was null");
			}
			_run = run;
		}

		public override function execute():void
		{
			responder = resolveResponder();
			dispatch(remoteService.saveRun(_run)); 						
		}
		
	}
}