package dk.runtrack.commands.athlete
{
	import dk.runtrack.commands.OntrackCommandTester;
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.User;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.Assert;
	
	import mx.rpc.IResponder;

	public class GetAthleteByUserCommandTester extends OntrackCommandTester
	{
		public function GetAthleteByUserCommandTester(methodName:String=null)
		{
			super(methodName);
			GetAthleteByUserCommand.resolveResponder = 
				function () : IResponder
				{
					return new DummyResponder();
				}
		}
		
		public function testAssertConstructorThrowsWhenUserIsNull() : void
		{
			assertTrue(ExceptionHelper.constructorWithArgumentTrowsException(GetAthleteByUserCommand, null));
		}
		

		public function testExecuteShouldCallDelegate() : void
		{
			var user : User = new User();
			var e : GetAthleteByUserCommand = new GetAthleteByUserCommand(user);
			DummyRemoteService.clearTokens();
			DummyRemoteService.calls.getAthleteByUser=null;
			
			e.execute();
			
			Assert.assertEquals(1, DummyRemoteService.calls.getAthleteByUser)
			Assert.assertTrue(DummyRemoteService.hasRegisteredOneToken());
		}

		
	}
}