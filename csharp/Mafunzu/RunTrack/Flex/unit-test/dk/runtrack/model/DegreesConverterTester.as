package dk.runtrack.model
{
	import flexunit.framework.TestCase;
	
	public class DegreesConverterTester extends TestCase
	{
		public function DegreesConverterTester(methodName:String=null)
		{
			super(methodName);
			RtConverter.resolveDecimalSeparator = function() : String
			{
				return ",";
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
		
		public function testToDbValue():void
		{
			var e : DegreesConverter = new DegreesConverter();
			assertEquals(151234567, e.toDbValue("15,1234567"));
		}
		
		public function testToPresentationValue():void
		{
			var e : DegreesConverter = new DegreesConverter();
			assertEquals("15,1234567", e.toPresentationValue(151234567));
		}
	}
}