package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class TimeFormatterTester extends TestCase
	{
		
		private var toNullSeparated : Function = DateTimeFormatterTester.toStringWithCurrentSeparator;

		private var _environmentManager : DateTimeEnvironmentManager;


		public function TimeFormatterTester(methodName:String=null)
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


		private function setupTestDateTimeEnvironmentWithUSLocale() : void
		{
			var testDateTimeEnvironment : TestDateTimeEnvironment =  new TestDateTimeEnvironment();
			testDateTimeEnvironment.setUSLocale();
			
			var environmentFunction : Function =
				function() : IDateTimeEnvironment
				{
					return testDateTimeEnvironment;				
				}
			TimeFormatter.resolveDateTimeInvironment = environmentFunction;			
		}

		public function testToString() : void
		{
			var e : TimeFormatter = new TimeFormatter();
			var timeString : String = e.toTimeString(1,2,3);
			var timeExpected : String = ("01:02:03");
			Assert.assertEquals(timeExpected, timeString);
		}

		public function testToDatabaseTime() : void
		{
			setupTestDateTimeEnvironmentWithUSLocale();
			var e : TimeFormatter = new TimeFormatter();
			var time : String = "01:02:03";
			var dbTime : uint = e.toDatabaseTime(time);
			var dbTimeExpected : uint = 3600 + 120 + 3;
			
			Assert.assertEquals(dbTimeExpected, dbTime);
		}
		
		public function testFromDatabaseTime() : void
		{
			setupTestDateTimeEnvironmentWithUSLocale();
			var e : TimeFormatter = new TimeFormatter();
			var timeExpected : String = "01:02:03";
			var dbTime : uint = e.toDatabaseTime(timeExpected);
			var fromDbTime : String = e.fromDatabaseTime(dbTime);
			Assert.assertEquals(timeExpected, fromDbTime);
		}

		public function testSeveralFromDatabaseTime() : void
		{
			setupTestDateTimeEnvironmentWithUSLocale();
			var e : TimeFormatter = new TimeFormatter();
			var timesExpected : Array = ["01:02:03", "00:01:03", "00:00:03", "00:12:00"];
			for each (var timeExpected : String in timesExpected)
			{
				var dbTime : uint = e.toDatabaseTime(timeExpected);
				var fromDbTime : String = e.fromDatabaseTime(dbTime);
				Assert.assertEquals(timeExpected, fromDbTime);
			}
		}
		
		public function testIsUIntAndParseUintForValidNumbers() : void
		{
			var e : TimeFormatter = new TimeFormatter();
			var times : Array = ["010203", "000103", "000003", "001200", "0000", "0"];
			for each (var time : String in times)
			{
				Assert.assertTrue(TimeFormatter.isUint(time));
				Assert.assertFalse( 
					ExceptionHelper.methodWithArgumentThrowsException(TimeFormatter.parseUint, time)
					);
			}
		}
		
		public function testIsUIntAndParseUintForInValidNumbers() : void
		{
			var e : TimeFormatter = new TimeFormatter();
			var times : Array = ["0102x3", "00x0103", "x000003", "001200x", "0000x", "0x"];
			for each (var time : String in times)
			{
				Assert.assertFalse(TimeFormatter.isUint(time));
				Assert.assertTrue( 
					ExceptionHelper.methodWithArgumentThrowsException(TimeFormatter.parseUint, time)
					);
			}
		}

		public function testMySplitAssert() : void
		{
			const element : String = "element";
			Assert.assertEquals(element,element.split(":")[0]);
		}

		
	}
}