package dk.runtrack.commands.user
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;

	public class LoginUserCommandExecuteTester extends TestCase
	{
		public function LoginUserCommandExecuteTester(methodName:String=null)
		{
			super(methodName);
			LoginUserCommand.resolveResponder = function() : IResponder
			{
				return new DummyResponder();
			}
		}
		
		public function testShouldCallRemoteService() : void
		{
			DummyRemoteService.calls.authenticateUser = 0;
			
			var username :String = "Gruffe";
			var password :String= username;
			var e: LoginUserCommand = new LoginUserCommand(username, password);

			e.execute();

			assertEquals(1, DummyRemoteService.calls.authenticateUser)
		}
	}
}