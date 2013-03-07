package dk.runtrack.responders
{

	
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.presentationmodels.DummyEditTrainingPlanPresentationModel;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.events.ResultEvent;
	
	public class GetAthleteTrainingPlansResponderTester extends TestCase
	{
		private var _viewModelLocator : DummyPresentationModelLocator;
		public function GetAthleteTrainingPlansResponderTester(methodName:String=null)
		{
			super(methodName);
			_viewModelLocator = new DummyPresentationModelLocator();
			BaseResponder.resolveViewModelLocator = function() : IPresentationModelLocator
			{
				return _viewModelLocator;
			}
		}
		
		public function testWhenResultIsNullShouldThrowException() : void
		{
			var responder : GetAthleteTrainingPlansResponder = new GetAthleteTrainingPlansResponder();
			var resultEvent : ResultEvent = ResultEventBuilder.build(null);
			assertTrue(ExceptionHelper.methodWithArgumentThrowsException(responder.result,resultEvent));
		}
		
		public function testWhenResultIsValidShouldUpdateViewModel() : void
		{
			var responder : GetAthleteTrainingPlansResponder = new GetAthleteTrainingPlansResponder();
			var resultEvent : ResultEvent = ResultEventBuilder.build(new Array());
			
			DummyEditTrainingPlanPresentationModel.calls.setTrainingPlans = null; 
			
			responder.result(resultEvent);
			
			assertEquals(1, DummyEditTrainingPlanPresentationModel.calls.setTrainingPlans);
		}
		
	}
}