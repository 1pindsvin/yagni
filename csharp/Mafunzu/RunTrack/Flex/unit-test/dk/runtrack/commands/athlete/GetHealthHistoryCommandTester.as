package dk.runtrack.commands.athlete
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.AthleteHealthQuery;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	
	public class GetHealthHistoryCommandTester extends TestCase
	{
		private var classToTestRef : dk.runtrack.commands.athlete.GetHealthHistoryCommand;
		
		public function GetHealthHistoryCommandTester(methodName:String=null)
		{
			super(methodName);
			GetHealthHistoryCommand.resolveResponder = function() : IResponder
			{
				return new DummyResponder();
			}
		}
		
		override public function setUp():void
		{
			super.setUp();
		}
		
		override public function tearDown():void
		{
			super.tearDown();
		}

		public function testAssertConstructor() : void
		{
			var query : AthleteHealthQuery = null;
			
			assertTrue(ExceptionHelper.constructorWithArgumentTrowsException(GetHealthHistoryCommand, query));
			
			query = new AthleteHealthQuery();
			
			assertTrue(ExceptionHelper.constructorWithArgumentTrowsException(GetHealthHistoryCommand, query));
			
			query.Athlete = new Athlete();
			
			assertFalse(ExceptionHelper.constructorWithArgumentTrowsException(GetHealthHistoryCommand, query));	
		}
		
		
		public function testAssertExecuteCallsRemoteService() : void
		{
			var query : AthleteHealthQuery = new AthleteHealthQuery();
			query.Athlete = new Athlete();
			var e : GetHealthHistoryCommand = new GetHealthHistoryCommand(query);
			DummyRemoteService.calls.getHealthHistory = null;
			
			e.execute();
			
			assertEquals(1, DummyRemoteService.calls.getHealthHistory);
		}
	}
}