package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class DateTimeFormatterTester extends TestCase
	{
		private var _environmentManager : DateTimeEnvironmentManager;
		public function DateTimeFormatterTester(methodName:String=null)
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
		
		public function testIsValidDate() : void
		{
			var e : DateTimeFormatter = new DateTimeFormatter();
			var dateString : String = "04-01-2000";
			Assert.assertTrue(e.isDateValid(dateString));
			dateString = "1-1-2000";
			Assert.assertTrue(e.isDateValid(dateString));
			dateString = "01";
			Assert.assertFalse(e.isDateValid(dateString));
		}
		
		public function testConvertToDateString() : void
		{
			var e : DateTimeFormatter = new DateTimeFormatter();
			var date: Date = new Date();
			date.fullYear = 2000;
			date.month = 0;
			date.date = 4;
			var dateString : String = e.toDateString(date);
			var dateExpected : String = "04-01-2000";
			Assert.assertEquals(dateExpected, dateString);
		}
		
		public function testStringToDate() : void
		{
			var e : DateTimeFormatter = new DateTimeFormatter();
			var dateString : String = "04-03-2000";
			var d :Date = e.getDate(dateString);
			Assert.assertEquals(2000, d.fullYear);
			Assert.assertEquals(3 - 1, d.month);
			Assert.assertEquals(4, d.date);
		}

		private function setTestDateTimeEnvironment() : void
		{
			var testDateTimeEnvironment : TestDateTimeEnvironment =  new TestDateTimeEnvironment();
			testDateTimeEnvironment.setUSLocale();
			
			var environmentFunction : Function =
				function() : IDateTimeEnvironment
				{
					return testDateTimeEnvironment;				
				}
			TimeFormatter.resolveDateTimeInvironment = environmentFunction;			
			DateTimeFormatter.resolveDateTimeInvironment = environmentFunction; 			
		}

		public function testStringToDateTime() : void
		{
			setTestDateTimeEnvironment();
			var e : DateTimeFormatter = new DateTimeFormatter();
			var dateString : String = "03/04/2000 12:32:00";
				
			var d :Date = e.getDateTime(dateString);
			Assert.assertEquals(2000, d.fullYear);
			Assert.assertEquals(3-1, d.month);
			Assert.assertEquals(4, d.date);
			Assert.assertEquals(12, d.hours);
			Assert.assertEquals(32, d.minutes);
			Assert.assertEquals(0, d.seconds);
			
			Assert.assertEquals(dateString, e.toDateTimeString(d));
		}

		public function testStringToDateTimeWhenTimeSecondIsMissing() : void
		{
			setTestDateTimeEnvironment();
			var e : DateTimeFormatter = new DateTimeFormatter();

			var dateString : String =  "03/04/2000 12:32";
			var d :Date = e.getDateTime(dateString);
			Assert.assertEquals(2000, d.fullYear);
			Assert.assertEquals(3-1, d.month);
			Assert.assertEquals(4, d.date);
			Assert.assertEquals(12, d.hours);
			Assert.assertEquals(32, d.minutes);
			Assert.assertEquals(0, d.seconds);
			
			Assert.assertEquals(dateString + ":00", e.toDateTimeString(d));
		}

		public static const DEFAULT_DATE_SEPARATOR : String = "-";

		public static function toDateTimeStringWithCurrentSeparator(
			date : String, month : String, year :String, 
			hour : String, minute : String, milliSeconds : String ) : String
		{
			return toStringWithCurrentSeparator(date, month, year) + " " + ([hour,minute,milliSeconds]).join(":")
		}

		public static function toStringWithCurrentSeparator(
			date : String, month : String, year :String) : String
		{
			return ([date,month,year]).join(DEFAULT_DATE_SEPARATOR);
		}

		public function testGetDate() : void
		{
			
			var testDateTimeEnvironment : TestDateTimeEnvironment =  new TestDateTimeEnvironment();
			testDateTimeEnvironment.setUSLocale();
			
			DateTimeFormatter.resolveDateTimeInvironment = 			
				function() : IDateTimeEnvironment
				{
					return testDateTimeEnvironment;				
				}
			
			var e : DateTimeFormatter = new DateTimeFormatter();
			var dateString : String = (["01","01","2000"]).join(testDateTimeEnvironment.dateSeparator);
			var d : Date = e.getDate(dateString);
			Assert.assertEquals(2000, d.fullYear);
			Assert.assertEquals(0, d.month);
			Assert.assertEquals(1, d.date);	
		}

		public function testDateToString() : void
		{
			var year : uint = 2000;
			var month : uint= 3;
			var date : uint	 = 4;
			
			var e : DateTimeFormatter = new DateTimeFormatter();
			
			var dateStringExpected : String = toStringWithCurrentSeparator("04","03","2000");
			var d :Date = new Date(year,month-1, date);
			
			var dateString : String = e.toDateString(d);
			
			Assert.assertEquals(dateStringExpected, dateString);			 
		}

		public function testDateTimeToString() : void
		{ 
			var year : uint = 2000;
			var month : uint= 3;
			var date : uint	 = 4;
			var hour : uint = 12;
			var minute : uint = 32;
			var seconds : uint = 45;
			
			var e : DateTimeFormatter = new DateTimeFormatter();

			var d :Date = new Date(year,month-1, date, hour, minute, seconds);
			
			
		
			var dateTimeStringExpected : String = 
				toDateTimeStringWithCurrentSeparator(
				"0" + date.toString(), 
				"0" + month.toString(), 
				year.toString(), 
				hour.toString(), 
				minute.toString(), 
				seconds.toString());
			
			var dateTimeString : String = e.toDateTimeString(d);
			
			Assert.assertEquals(dateTimeStringExpected, dateTimeString);			 
		}
		
		public function testGetDateTimeWhenTimeHasOneElement() :void
		{
			var testDate : String = "23-06-2009 18";
			var e : DateTimeFormatter = new DateTimeFormatter();
			var date : Date = e.getDateTime(testDate);
			Assert.assertEquals(23, date.date);
			Assert.assertEquals(6-1, date.month);
			Assert.assertEquals(2009, date.fullYear);
			Assert.assertEquals(18, date.hours);
			Assert.assertEquals(0, date.minutes);
			Assert.assertEquals(0, date.seconds);
		}
		
		public function testDate_31_Month10_year_2009_09_34() : void
		{
			var mydate: Date =  new Date();
			
			var canRunThisSickTest : Boolean = mydate.date==31 && mydate.month==9; 
			if(!canRunThisSickTest)
			{
				return;
			} 


			var date : String = "23";
			var month : String = "06";
			var year : String = "2009";
			

			var wrongMonthThatOccursWhenRunOn3110 : uint = 6;
			var expectedMonth : uint = 5;

			mydate.fullYearUTC = uint(year);
			mydate.monthUTC = uint(month) -1;
			mydate.dateUTC = uint(date);		
			
			assertEquals(23, mydate.dateUTC);
			assertEquals(wrongMonthThatOccursWhenRunOn3110, mydate.monthUTC);
			assertEquals(2009, mydate.fullYearUTC);

			mydate.dateUTC = uint(date);		
			mydate.monthUTC = uint(month) -1;
			mydate.fullYearUTC = uint(year);

			assertEquals(23, mydate.dateUTC);
			assertEquals(expectedMonth, mydate.monthUTC);
			assertEquals(2009, mydate.fullYearUTC);

		}
		
		public function testDateToStringWithChangedFormat() : void
		{
			
			var dateEnviroment : TestDateTimeEnvironment =  DateTimeFormatter.resolveDateTimeInvironment();
			assertEquals(1, dateEnviroment.monthIndex)
			dateEnviroment.setUSLocale();
			assertEquals(0, dateEnviroment.monthIndex)			

			var year : uint = 2000;
			var month : uint= 11;
			var date : uint	 = 4;

			_environmentManager.setUSLocale();
			
			var dateStringExpected : String = 
				([
					Format.formatTwoDigit(month), 
					Format.formatTwoDigit(date),
					year
				]).
				join(_environmentManager.dateSeparator);

			var testDate :Date = new Date(year,month-1, date);
			
			var e : DateTimeFormatter = new DateTimeFormatter();
			var dateString : String = e.toDateString(testDate);
			Assert.assertEquals(dateStringExpected, dateString);			 
		}


		
	}
}