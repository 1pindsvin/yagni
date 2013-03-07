package dk.runtrack.responders
{
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.model.RunsPage;
	import dk.runtrack.util.ExceptionHelper;
	import dk.runtrack.presentationmodels.DummyAthleteRunsViewModel;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.events.ResultEvent;

	public class RunPageResponderUpdateViewModelTester extends TestCase
	{
		public function RunPageResponderUpdateViewModelTester(methodName:String=null)
		{
			super(methodName);
		}

			
		override public function setUp():void
		{
			super.setUp();
		}
		
		override public function tearDown():void
		{
			super.tearDown();			
		}

		public function testResultExpectsThrowsExceptionWhenRunsNotFoundOnResult() : void
		{
			var e : RunPageResponder = new RunPageResponder();
			var resultEvent : ResultEvent = ResultEventBuilder.build(null);
			assertTrue(
				ExceptionHelper.methodWithArgumentThrowsException(e.result, resultEvent) 
				);	
		}

		
		public function testWhenResultEventHasRunsPageShouldUpdateViewModel() : void
		{
			
			var runspage : RunsPage = new RunsPage();
			var resultEvent : ResultEvent = ResultEventBuilder.build(runspage);
			
			var e : RunPageResponder = new RunPageResponder();
			e.presentationModelLocator = new DummyPresentationModelLocator();
			DummyAthleteRunsViewModel.runsPageWasSet = false;
			
			e.result(resultEvent);
			
			assertTrue(DummyAthleteRunsViewModel.runsPageWasSet);
			
		}
		
	}
}