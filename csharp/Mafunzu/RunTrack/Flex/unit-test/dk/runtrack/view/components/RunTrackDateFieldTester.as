package dk.runtrack.view.components
{
	import dk.runtrack.model.DateTimeEnvironmentManager;
	import dk.runtrack.model.DateTimeFormatter;
	
	import flexunit.framework.TestCase;

	public class RunTrackDateFieldTester extends TestCase
	{
		private var _environmentManager : DateTimeEnvironmentManager;

		public function RunTrackDateFieldTester(methodName:String=null)
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
		
		public function testConstructor() : void
		{
			var e :RunTrackDateField = new RunTrackDateField();
			assertNotNull(e);
		}
		
		public function testMaxNumberValue() : void
		{
			var number : Number = 17801321952112017408;
			assertEquals(17801321952112017408, number)
		}
		
	}
}