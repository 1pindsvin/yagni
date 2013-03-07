package dk.runtrack.commands.run
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.BestRunsQuery;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	
	public class GetBestRunsCommandTester extends TestCase
	{
		private var classToTestRef : dk.runtrack.commands.run.GetBestRunsCommand;
		
		public function GetBestRunsCommandTester(methodName:String=null)
		{
			super(methodName);
			GetBestRunsCommand.resolveResponder =  function() : IResponder
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
		
		public function testAssertExecuteCallsRemoteService():void
		{
			var query : BestRunsQuery = new BestRunsQuery();
			query.DistanceMaximum = 10000;
			query.DistanceMinimum = 10000;
			query.NumberOfRunsToFetch = 2;
			query.Athlete = new Athlete();
			
			var e : GetBestRunsCommand = new GetBestRunsCommand(query);
			
			DummyRemoteService.calls.getBestRuns = null;
			
			e.execute();
			
			assertEquals(1, DummyRemoteService.calls.getBestRuns)
		}
	}
}