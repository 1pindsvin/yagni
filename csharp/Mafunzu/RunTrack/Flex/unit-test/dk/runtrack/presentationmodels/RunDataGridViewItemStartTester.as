package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeEnvironmentManager;
	import dk.runtrack.model.Run;
	
	import flexunit.framework.TestCase;

	public class RunDataGridViewItemStartTester extends TestCase
	{
		private var _environmentManager : DateTimeEnvironmentManager;
		public function RunDataGridViewItemStartTester(methodName:String=null)
		{
			super(methodName);
			_environmentManager = new DateTimeEnvironmentManager();

		}

		override public function setUp():void
		{
			_environmentManager.setupForTesting();
			super.setUp();
		}
		
		override public function tearDown():void
		{
			_environmentManager.teardownTestSetup();
			super.tearDown();
		}

		private function buildTestDate() : Date
		{
			return new Date(2009, 1,1,0,0,0,0);
		}

		private function buildRun() : Run
		{
			var run : Run = new Run();
			run.Start = buildTestDate();
			return run;
		}
		
		public function testWhenLocaleIsChangedShouldSwitchDateFormat() : void
		{
			var runGridItem : RunDataGridViewItem = new RunDataGridViewItem(buildRun());
			assertEquals("01-02-2009 00:00:00",  runGridItem.start)
			_environmentManager.setUSLocale();
			assertEquals("02/01/2009 00:00:00",  runGridItem.start)
		}
		
		
	}
}