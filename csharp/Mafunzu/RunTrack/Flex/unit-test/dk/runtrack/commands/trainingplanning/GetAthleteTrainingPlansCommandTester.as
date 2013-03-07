package dk.runtrack.commands.trainingplanning
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.Athlete;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	
	public class GetAthleteTrainingPlansCommandTester extends TestCase
	{
		private var _athlete : Athlete;
		private var _responder : DummyResponder;
		public function GetAthleteTrainingPlansCommandTester(methodName:String=null)
		{
			super(methodName);
			_athlete = new Athlete();
			_responder = new DummyResponder();
			
			GetAthleteTrainingPlansCommand.resolveAthlete = function() : Athlete
			{
				return _athlete;
			}
				
			GetAthleteTrainingPlansCommand.resolveResponder = function() : IResponder
			{
				return _responder;
			}
					
		}
	
		public function testConstructorShouldSetResponder() : void
		{
			var e : GetAthleteTrainingPlansCommand = new GetAthleteTrainingPlansCommand();
			assertEquals(_responder.ID, DummyResponder(e.responder).ID);
		}
		
		public function testExecuteShouldCallRemoteService() : void
		{
			var e : GetAthleteTrainingPlansCommand = new GetAthleteTrainingPlansCommand();
			assertNull(DummyRemoteService.calls.getAthleteTrainingPlans);

			e.execute();
			
			assertEquals(1, DummyRemoteService.calls.getAthleteTrainingPlans);
			
		}
		
		
	}
}