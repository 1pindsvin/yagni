package dk.runtrack.responders
{
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.BestRunsQuery;
	import dk.runtrack.presentationmodels.DummyBestRunsPresentationModel;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.events.ResultEvent;
	
	public class GetBestRunsResponderTester extends TestCase
	{

		private var _viewModelLocator : DummyPresentationModelLocator;
		public function GetBestRunsResponderTester(methodName:String=null)
		{
			super(methodName);
			_viewModelLocator = new DummyPresentationModelLocator();
			BaseResponder.resolveViewModelLocator = function() : IPresentationModelLocator
			{
				return _viewModelLocator;
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
		
		public function testWhenResultIsValidShouldUpdateViewModel() : void
		{
			var responder : GetBestRunsResponder = new GetBestRunsResponder();
			var resultEvent : ResultEvent = ResultEventBuilder.build(new BestRunsQuery());
			
			DummyBestRunsPresentationModel.calls.setQuery=null;
			
			responder.result(resultEvent);
			
			assertEquals(1, DummyBestRunsPresentationModel.calls.setQuery);
		}
	}
}