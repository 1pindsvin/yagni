package dk.runtrack.commands.run
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.TrainingPlan;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	
	public class GetPlannedRunsComandTester extends TestCase
	{
		public function GetPlannedRunsComandTester(methodName:String=null)
		{
			super(methodName);
			GetPlannedRunsCommand.resolveResponder =  function() : IResponder
			{
				return new DummyResponder();
			}
		}
		
		public function testWhenTrainingPlanIsNullShouldThrow() : void
		{
			var throwsError : Boolean = true;
			try
			{
				var e : GetPlannedRunsCommand = new GetPlannedRunsCommand(null);
				throwsError = false;
			}
			catch(error:Error)
			{
			}
			assertTrue(throwsError);				
		}
		
		public function testAssertExecuteCallsRemoteService() : void
		{
			var trainingPlan : TrainingPlan = new TrainingPlan();
			var e : GetPlannedRunsCommand = new GetPlannedRunsCommand(trainingPlan);
			
			DummyRemoteService.calls.getPlannedRuns = null;
			
			e.execute();
			
			assertEquals(1, DummyRemoteService.calls.getPlannedRuns)
		}

	}
}