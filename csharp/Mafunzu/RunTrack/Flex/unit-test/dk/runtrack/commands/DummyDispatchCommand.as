package dk.runtrack.commands
{
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	
	import mx.rpc.IResponder;
	
	public class DummyDispatchCommand extends BaseCommand
	{
		public function DummyDispatchCommand()
		{
			super();
		}
		
		public override function execute(event:CairngormEvent):void
		{
			responder  = new DummyResponder();
			dispatch(new DummyRemoteService().deleteRun(null));
		}
	}
}