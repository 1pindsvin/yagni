package dk.runtrack.commands.trainingplanning
{
	import dk.runtrack.delegates.athlete.DummyResponder;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Goal;
	import dk.runtrack.model.TrainingPlan;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	
	public class SaveTrainingPlanCommandTester extends TestCase
	{
		private var _athlete : Athlete;
		private var _responder : IResponder;
		public function SaveTrainingPlanCommandTester(methodName:String=null)
		{
			super(methodName);
			_athlete = new Athlete();
			_responder = new DummyResponder();
				
			SaveTrainingPlanCommand.resolveAthlete = function() : Athlete  
			{
				return _athlete;
			};
			SaveTrainingPlanCommand.resolveResponder = function() :  IResponder
			{
				return _responder;
			}
		}
		
		
		
		public function testWhenTraingPlanIsNullShouldThrow() : void
		{
			var throwsError : Boolean = true;
			try
			{
				var e : SaveTrainingPlanCommand = new SaveTrainingPlanCommand(null);
				throwsError = false;
			}
			catch(error:Error)
			{
			}
			assertTrue(throwsError);			
		}

		private function buildTrainingPlan() : TrainingPlan
		{
			var plan : TrainingPlan = new TrainingPlan();
			return plan;
		}
			
		public function testWhenConstructedShouldSetAthlete() : void
		{
			var plan : TrainingPlan = buildTrainingPlan();
			var e : SaveTrainingPlanCommand = new SaveTrainingPlanCommand(plan);
			assertNotNull(plan.Athlete);
			assertNotNull(plan.Goal.Athlete);
			assertNotNull(e.responder);
		}

		
		public function testWhenExecutedSholdCallResponder() : void
		{
			var plan : TrainingPlan = buildTrainingPlan();
			var e : SaveTrainingPlanCommand = new SaveTrainingPlanCommand(plan);
			e.execute();
		}

	}
}