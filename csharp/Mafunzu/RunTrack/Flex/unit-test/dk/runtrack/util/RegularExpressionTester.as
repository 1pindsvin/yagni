package dk.runtrack.util
{
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class RegularExpressionTester extends TestCase
	{
		public function RegularExpressionTester(methodName:String=null)
		{
			super(methodName);
		}
		
		public function testSplitOnSpaceOrTabRegExp() : void
		{
			var testElement : String = "XXX";
			var expressionsWithTests : Array = 
				[
					["\\s", " "],
					["\\s+", "  "],
					["\\s+", (["\t","\t","\t", " "]).join("")]
				]
			for each(var expressionWithTest: Array in expressionsWithTests)
			{
				var expression : String = expressionWithTest[0];
				var test : String =  expressionWithTest[1];
				var regexp : RegExp = new RegExp(expression); 
				var joined : String = ([testElement, testElement]).join(test);
				var split : Array = joined.split(regexp);
				Assert.assertEquals(testElement, split[0])
				Assert.assertEquals(testElement, split[1])
				Assert.assertEquals(2, split.length)
			}
		}
		
		public function testTimeInputMask() : void
		{
			//maskDateTimeRegEx
			var e : RegExp = new RegExp("^\\d{1,2}$"); // /^\d{1,2}$/
			for each(var failTest : String in ["",  "1x", "x1x", "x11x" ])
			{
				var matched : Object = failTest.match(e);
				Assert.assertFalse(matched); //actually null
			} 
			for each(var successTest : String in ["0",  "00", "12"])
			{
				var successMatched : Object = successTest.match(e);
				Assert.assertTrue(successMatched); //actually null
			} 
			
			
		}

		public function testResolveClassNameFromQualifiedClassName() : void
		{
			var className : String = "classname";
			var name  : String = "dummy::"+ className;
			
			var split : Array = name.split("::")
			
			assertEquals(className, split[1]);

			split = className.split("::");
			
			assertEquals(className, split[0]);
				
		}		


		public function testComplexTimeInputMask() : void
		{
			//maskDateTimeRegEx
			var e : RegExp = new RegExp("^\\d{1,2}:\\d{1,2}(:\\d{1,2})?$"); // /^\d{1,2}$/
			for each(var failTest : String in ["", ":",  "1:x", "x1x:sf", "x11x:" ])
			{
				var matched : Object = failTest.match(e);
				Assert.assertFalse(matched); //actually null
			} 
			for each(var successTest : String in ["0:0",  "00:00", "12:01", "12:00:12"])
			{
				var successMatched : Object = successTest.match(e);
				Assert.assertTrue(successMatched); //actually null
			} 
			
			
		}
		
		

		
	}
}