package dk.runtrack.responders
{
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.presentationmodels.DummyAthleteHealthHistoryPresentationModel;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.events.ResultEvent;
	
	public class GetHealthHistoryResponderTester extends TestCase
	{
		private var classToTestRef : dk.runtrack.responders.GetHealthHistoryResponder;
		
		public function GetHealthHistoryResponderTester(methodName:String=null)
		{
			super(methodName);
			BaseResponder.resolveViewModelLocator = function() : IPresentationModelLocator 
			{
				return new DummyPresentationModelLocator();
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
		
		public function testResultShouldUpdateViewModel():void
		{
			var e : GetHealthHistoryResponder = new GetHealthHistoryResponder();
			  
			var resultEvent : ResultEvent = ResultEventBuilder.build(null);
	
			DummyAthleteHealthHistoryPresentationModel.calls.setAthleteHealthQuery = null;
			
			e.result(resultEvent);
			
			assertEquals(1, DummyAthleteHealthHistoryPresentationModel.calls.setAthleteHealthQuery);
		}
	}
}