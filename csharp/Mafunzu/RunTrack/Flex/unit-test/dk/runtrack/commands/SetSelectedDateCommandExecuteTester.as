package dk.runtrack.commands
{
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.TestCase;

	public class SetSelectedDateCommandExecuteTester extends TestCase
	{
		private var _viewModelLocator : DummyPresentationModelLocator;
		private var _remoteService : DummyRemoteService; 
		 
		public function SetSelectedDateCommandExecuteTester(methodName:String=null)
		{
			super(methodName);
			
		}
	
		override public function setUp():void
		{
			super.setUp();
			_viewModelLocator = new DummyPresentationModelLocator();
			_remoteService = new DummyRemoteService();
			RtCommand.resolveRemoteService = 
				function() : IRtRemoteService
				{
					return _remoteService;
				}			
			
			SetSelectedDateCommand.resolveViewModelLocator =
				function () : IPresentationModelLocator
				{
					return _viewModelLocator;
				}
		}
		
		override public function tearDown():void
		{
			super.tearDown();
		}
		
		public function testShouldNotFailButDoesSomeTimes() : void
		{
			var athlete : Athlete = new Athlete();
			athlete.ID = 1;
			
			_viewModelLocator.editAthletePresentationModel.currentathlete = athlete;
			try
			{
				var date : Date = new Date();
				var e : SetSelectedDateCommand = new SetSelectedDateCommand(date);
			}
			catch(error:Error)
			{
				fail("constructor fails because current athlete is null!");
			}
		}		
		
		
		public function testShouldCallRemoteServiceGetRunsPage() : void
		{
			//solves the problem from testShouldNotFailButDoes
			var f : Function =	function () : IPresentationModelLocator
				{
					var athlete : Athlete = new Athlete();
					athlete.ID = 1;
					var vmLocator : DummyPresentationModelLocator = new DummyPresentationModelLocator();
					vmLocator.editAthletePresentationModel.currentathlete = athlete;
					return vmLocator;					
				}
			SetSelectedDateCommand.resolveViewModelLocator = f;

			var date : Date = new Date();
			var e : SetSelectedDateCommand = new SetSelectedDateCommand(date);
			e.execute();

			assertEquals(1, DummyRemoteService.calls.getRunsPage)
		}		

		public function testConstructorWhenDateIsNullShouldThrow() : void
		{
			try
			{
				var e : SetSelectedDateCommand = new SetSelectedDateCommand(null);
				fail("constructor should fail on null argument");
			}
			catch(error:Error)
			{
			}
		}		
	}
}