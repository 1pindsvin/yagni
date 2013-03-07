package dk.runtrack.commands.user
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	
	public class CreateUserWithAthleteCommandTester extends TestCase
	{
		
		
		public function CreateUserWithAthleteCommandTester(methodName:String=null)
		{
			CreateUserWithAthleteCommand.resolveResponder = function() : IResponder
			{
				return new DummyResponder();
			}
			super(methodName);
		}
		
		override public function setUp():void
		{
			super.setUp();
		}
		
		override public function tearDown():void
		{
			super.tearDown();
		}
		
		public function testAssertExecuteCallsRemoteService() : void
		{
			var email : String = "email";
			var password : String = "password";
			var e : CreateUserWithAthleteCommand = 
				new CreateUserWithAthleteCommand(email, password);
			
			e.execute();
			
			assertEquals(1, DummyRemoteService.calls.createUserWithDefaultAthlete);
		}
	}
}