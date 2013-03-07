package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeEnvironmentManager;
	
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;
	
	import mx.events.ValidationResultEvent;
	import mx.resources.IResourceManager;
	import mx.resources.ResourceBundle;
	import mx.resources.ResourceManager;

	public class TimeValidatorTester extends TestCase
	{
		
		private var toStringWithCurrentSeparator : Function;

		private var _environmentManager : DateTimeEnvironmentManager;
		
		public function TimeValidatorTester(methodName:String=null)
		{
			super(methodName);
			_environmentManager = new DateTimeEnvironmentManager();
		}

		override public function setUp():void
		{
			_environmentManager.setupForTesting();
			setupTestDateTimeEnvironment();
			//setupResourcemanger();
			super.setUp();
		}
		
		override public function tearDown():void
		{
			_environmentManager.teardownTestSetup();
			super.tearDown();
		}

		public static const US_LOCALE : String = "en_US"; 	
		public static const DK_LOCALE : String = "da_DK";

		public function setupResourcemanger() : void
		{
			var res : IResourceManager = ResourceManager.getInstance();
			var bundle : ResourceBundle = new ResourceBundle(DK_LOCALE, 'validators');
			bundle.content['requiredFieldError'] = "fooo";
			res.addResourceBundle(bundle);
			res.localeChain = [DK_LOCALE];
		}

		private function setupTestDateTimeEnvironment() : void
		{
			var separator : String = _environmentManager.dateSeparator;
			toStringWithCurrentSeparator = function(date : String, month : String, year :String) : String
			{
				return ([date,month,year]).join(separator);
			}
		}

		
		public function testConstructor() : void
		{
			var e: TimeValidator = new TimeValidator();
			Assert.assertNotNull(e);
		}
		
		public function testValidateShouldReturnNullForValidTime() : void
		{
			var e: TimeValidator = new TimeValidator();
			var time : String = "23:12:01";
			var result : ValidationResultEvent = e.validate(time);
			assertEquals(ValidationResultEvent.VALID, result.type);
			assertNull(result.results);
		}

		public function testValidateShouldReturnErrorValidations() : void
		{
			var e: TimeValidator = new TimeValidator();
			var time : String = "23:XX:01:XX";
			var result : ValidationResultEvent = e.validate(time);
			Assert.assertNotNull(result.results);
		}

	}
}