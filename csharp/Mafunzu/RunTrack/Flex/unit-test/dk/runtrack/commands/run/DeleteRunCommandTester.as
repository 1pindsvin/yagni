package dk.runtrack.commands.run
{
	import dk.runtrack.commands.OntrackCommandTester;
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.Run;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.Assert;
	
	import mx.rpc.IResponder;
	
	public class DeleteRunCommandTester extends OntrackCommandTester
	{
		public function DeleteRunCommandTester(methodName:String=null)
		{
			DeleteRunCommand.resolveDeleteRunResponder = 
				function() : IResponder
				{
					return new DummyResponder();
				}
			super(methodName);
		}
		
		public function testAssertConstructorThrowsWhenRunIsNull() : void
		{
			assertTrue(ExceptionHelper.constructorWithArgumentTrowsException(DeleteRunCommand,null));
		}
		
		public function testAssertExecuteCallsRemoteService() : void
		{
			var run : Run = new Run();
			var e : DeleteRunCommand = new DeleteRunCommand(run);
			DummyRemoteService.calls.runSaveRunRemote = null;
			
			e.execute();
			
			Assert.assertEquals(1, DummyRemoteService.calls.runSaveRunRemote)
		}
	}
}