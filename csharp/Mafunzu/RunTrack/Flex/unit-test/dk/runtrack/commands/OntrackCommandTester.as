package dk.runtrack.commands
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	
	import flexunit.framework.TestCase;

	public class OntrackCommandTester extends TestCase
	{
		public function OntrackCommandTester(methodName:String=null)
		{
			BaseCommand.resolveRemoteService = 
			function() : IRtRemoteService
			{
				return new DummyRemoteService();
			}
			super(methodName);
		}
	
	}
}