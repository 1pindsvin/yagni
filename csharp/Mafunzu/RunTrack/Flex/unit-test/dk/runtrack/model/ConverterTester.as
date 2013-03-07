package dk.runtrack.model
{
	import flexunit.framework.TestCase;
	
	public class ConverterTester extends TestCase
	{
		public function ConverterTester(methodName:String=null)
		{
			super(methodName);
			Converter.resolveDecimalSeparator = function() : String
			{
				return ",";
			}
		}
		
		public function testToDatabaseHeight() : void
		{
			var e: Converter = new Converter();
			var height : String = "181,5";
			var dbHeightExpected : int = 18150;
			assertEquals(dbHeightExpected, e.toDatabase(height));
		}
		
		public function testFromDatabaseHeight() : void
		{
			var e: Converter = new Converter();
			var dbHeight : int = 18150;
			var heightExpected : String = "181,50";
			assertEquals(heightExpected, e.toLocaleText(e.fromDatabase(dbHeight)));
		}

		public function testAssertBmiCalculation() : void
		{
			var e: Converter = new Converter();
			var dbHeight : int = 18100;
			var dbWeight : int = 95000;
			var expectedBmi : String = "29,00";
			var actualBmi : String = e.bmi(dbHeight, dbWeight);
			assertEquals(expectedBmi, actualBmi);
		}

		
	}
}