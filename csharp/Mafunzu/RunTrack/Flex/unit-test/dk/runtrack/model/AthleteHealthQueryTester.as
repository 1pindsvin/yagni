package dk.runtrack.model
{
	import flexunit.framework.TestCase;
	
	public class AthleteHealthQueryTester extends TestCase
	{
		
		private var classToTestRef : dk.runtrack.model.AthleteHealthQuery;
		
		public function AthleteHealthQueryTester(methodName:String=null)
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
		
		public function testAssertConstructorSetsHasLoFalse() : void
		{
			var e : AthleteHealthQuery = new AthleteHealthQuery();
			assertFalse(e.hasLoadedServerData());
		}
	}
}