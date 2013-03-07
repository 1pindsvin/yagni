package dk.runtrack.responders
{
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.ActivityQuery;
	import dk.runtrack.presentationmodels.DummyEditActivityPresentationModel;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.events.ResultEvent;
	
	public class GetActivitiesForSingleDayResponderTester extends TestCase
	{
		public function GetActivitiesForSingleDayResponderTester(methodName:String=null)
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
		
		public function testAssertResultUpdatesPresentationModel():void
		{
			var e : GetActivitiesForSingleDayResponder = new GetActivitiesForSingleDayResponder();
			var serverEvent : ResultEvent = ResultEventBuilder.build(new ActivityQuery());
			DummyEditActivityPresentationModel.calls.editActivity = null;
			
			e.result(serverEvent);
			
			assertEquals(1, DummyEditActivityPresentationModel.calls.editActivity);
		}
	}
}