package dk.runtrack.commands.run
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.LabelEnumeration;
	import dk.runtrack.model.Run;
	import dk.runtrack.responders.DeleteRunResponder;
	
	import mx.rpc.IResponder;

	public class DeleteRunCommand extends RtCommand
	{

		public static var resolveDeleteRunResponder : Function =
			function () : IResponder
			{
				return new DeleteRunResponder();
			}
		
		private var _run : Run;
		public function DeleteRunCommand(run: Run)
		{
			super();
			if(run==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", DeleteRunCommand, run was null");
			}
			_run = run;
		}


		public override function execute():void
		{
			responder = resolveDeleteRunResponder();
			_run.Labels |= LabelEnumeration.Trash;
			_run.LastChanged = new Date();
			dispatch(remoteService.saveRun(_run));
		}
		
	}
}