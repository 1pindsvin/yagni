package dk.runtrack.commands.run
{
	import dk.runtrack.commands.OntrackCommandTester;
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.Run;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.Assert;

	public class SaveRunCommandTester extends OntrackCommandTester
	{
		public function SaveRunCommandTester(methodName:String=null)
		{
			super(methodName);
		}
		
		public function testAssertConstructorThrowsWhenRunIsNull() : void
		{
			assertTrue(ExceptionHelper.constructorWithArgumentTrowsException(SaveRunCommand, null));
		}
		
		public function testAssertExecuteCallsRemoteService() : void
		{
			DummyRemoteService.calls.runSaveRunRemote=null;
			var run : Run = new Run();
			var e : SaveRunCommand = new SaveRunCommand(run);
			
			e.execute();

			assertEquals(1, DummyRemoteService.calls.runSaveRunRemote)
		}
		
		
	}
}