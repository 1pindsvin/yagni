package dk.runtrack.commands.run
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.LabelEnumeration;
	import dk.runtrack.model.Run;
	import dk.runtrack.responders.UndoDeleteRunResponder;
	
	import mx.rpc.IResponder;

	public class UndoDeleteRunCommand extends RtCommand
	{
		
		public var resolveResponder : Function = function() : IResponder
		{
			return new UndoDeleteRunResponder();
		}
		
		private var _run : Run;
		public function UndoDeleteRunCommand(run : Run)
		{
			_run = run;
		}

		public override function execute():void
		{
			responder = resolveResponder();
			dispatch(remoteService.undoDeleteRun(_run));
		}
		
	}
}