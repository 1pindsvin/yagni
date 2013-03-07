package dk.runtrack.commands.activity
{
	import dk.runtrack.commands.OntrackCommandTester;
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.ActivityQuery;
	import dk.runtrack.model.User;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.Assert;
	
	import mx.rpc.IResponder;

	public class GetActivitiesCommandTester extends OntrackCommandTester
	{
		public function GetActivitiesCommandTester(methodName:String=null)
		{
			super(methodName);
			GetActivitiesCommand.resolveResponder = 
				function () : IResponder
				{
					return new DummyResponder();
				}
		}
		
		public function testAssertConstructorThrowsWhenQueryIsNull() : void
		{
			assertTrue(ExceptionHelper.constructorWithArgumentTrowsException(GetActivitiesCommand, null));
		}

		public function testAssertExecuteCallsRemoteService() : void
		{
			var query : ActivityQuery = new ActivityQuery();
			var e : GetActivitiesCommand = new GetActivitiesCommand(query);

			DummyRemoteService.clearTokens();
			DummyRemoteService.calls.getActivities=null;
			
			e.execute();
			
			Assert.assertEquals(1, DummyRemoteService.calls.getActivities)
			Assert.assertTrue(DummyRemoteService.hasRegisteredOneToken());
		}

		
	}
}