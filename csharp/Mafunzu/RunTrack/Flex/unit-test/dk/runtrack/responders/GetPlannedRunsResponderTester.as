package dk.runtrack.responders
{
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.presentationmodels.DummyEditTrainingPlanPresentationModel;
	import dk.runtrack.presentationmodels.DummyRunChartPresentationModel;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.events.ResultEvent;
	
	public class GetPlannedRunsResponderTester extends TestCase
	{
		private var _viewModelLocator : DummyPresentationModelLocator;
		public function GetPlannedRunsResponderTester(methodName:String=null)
		{
			super(methodName);
			_viewModelLocator = new DummyPresentationModelLocator();
			BaseResponder.resolveViewModelLocator = function() : IPresentationModelLocator
			{
				return _viewModelLocator;
			}
		}
		
		public function testWhenResultIsValidShouldUpdateViewModel() : void
		{
			var responder : GetPlannedRunsResponder = new GetPlannedRunsResponder();
			var resultEvent : ResultEvent = ResultEventBuilder.build(new Array());
			
			DummyRunChartPresentationModel.calls.setRuns = null; 
			
			responder.result(resultEvent);
			
			assertEquals(1, DummyRunChartPresentationModel.calls.setRuns);
		}
	}
}