package dk.runtrack.model
{
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;
	
	import mx.resources.IResourceBundle;
	import mx.resources.IResourceManager;
	import mx.resources.ResourceBundle;
	import mx.resources.ResourceManager;

	public class DistanceFormatterTester extends TestCase
	{
		public function DistanceFormatterTester(methodName:String=null)
		{
			super(methodName);
		}

		override public function setUp():void
		{
			super.setUp();
			ensureResourceBundles();
		}
		
		override public function tearDown():void
		{
			super.tearDown();
			ResourceManager.getInstance().localeChain = [];
		}

		public function testResourceManagerAvailableAndCanSetLocale() : void
		{
			var resourceManager : IResourceManager = ResourceManager.getInstance();
			assertNotNull(resourceManager);	
			resourceManager.localeChain = ["da_DK"];				
		}

		public function testValidatorBundleIsLoaded() : void
		{
			ensureResourceBundles();
			var resourceManager : IResourceManager = ResourceManager.getInstance();
			resourceManager.localeChain = [danishLocale];				
			var validatorBundle : IResourceBundle = resourceManager.getResourceBundle(danishLocale, DistanceFormatter.VALIDATOR_BUNDLE_NAME);
			assertNotNull(validatorBundle);					
			assertEquals(validatorBundle.content[DistanceFormatter.DECIMAL_SEPARATOR_NAME], ",");
		}

		private var danishLocale : String = "da_DK";
		private var usLocale : String = "en_US";
		
		private function ensureResourceBundles() : void
		{
			var resourceManager : IResourceManager = ResourceManager.getInstance();
			resourceManager.localeChain = [danishLocale];				

			var strings : IResourceBundle  = new ResourceBundle(danishLocale, DistanceFormatter.VALIDATOR_BUNDLE_NAME);
			strings.content[DistanceFormatter.DECIMAL_SEPARATOR_NAME] = ",";
			strings.content["thousandsSeparator"] = "\.";
			
			resourceManager.addResourceBundle(strings);

			strings  = new ResourceBundle(usLocale, DistanceFormatter.VALIDATOR_BUNDLE_NAME);
			strings.content[DistanceFormatter.DECIMAL_SEPARATOR_NAME] = "\.";
			strings.content["thousandsSeparator"] = ",";

			resourceManager.addResourceBundle(strings);
			
			strings  = new ResourceBundle(danishLocale, DistanceFormatter.COMMONWORDS_BUNDLE_NAME);
			strings.content[DistanceFormatter.KILOMETERS_NAME] = "kilometer";
			strings.content[DistanceFormatter.MINUTES_NAME] = "minutter";
			strings.content[DistanceFormatter.SECONDS_NAME] = "sekunder";

			resourceManager.addResourceBundle(strings);
		}
		
		public function testParseFloatFailsWithDanishLocale() : void
		{
			ensureResourceBundles();
			
			var databaseDistanceExpected : uint = 1000 * 10;
			var kilometerString : String = "10,2";
			
			var testFloatNumber : Number = parseFloat(kilometerString) * 1000;
			
			assertEquals(databaseDistanceExpected, testFloatNumber);
			
		}
		
		public function testFromDatabaseDistanceShouldConvertToKilometersWithSeparator() : void
		{
			var e : DistanceFormatter = new DistanceFormatter();
			var databaseDistance : uint = 10200;
			var kilometerStringExpected : String = "10.2";
			var kilometerStringActual : String = e.fromDatabaseDistance(databaseDistance).toString();
			Assert.assertEquals(kilometerStringExpected, kilometerStringActual);
		}

		public function testToDatabaseDistanceShouldConvertToMeters() : void
		{
			var e : DistanceFormatter = new DistanceFormatter();
			var databaseDistanceExpected : uint = 10200;
			var kilometerString : String = "10.2";
			var databaseDistanceMeters : uint = e.toDatabaseDistance(kilometerString);
			Assert.assertEquals(databaseDistanceExpected, databaseDistanceMeters);
		}
		

		public function testToDatabaseDistanceWithChangedLocaleShouldConvertToMeters() : void
		{
			var e : DistanceFormatter = new DistanceFormatter();
			var databaseDistanceExpected : uint = 10200;
			var kilometerString : String = "10,2";
			var databaseDistanceMeters : uint = e.toDatabaseDistance(kilometerString);
			Assert.assertEquals(databaseDistanceExpected, databaseDistanceMeters);
		}

		public function testToUsLocaleKilometerText() : void
		{
			ResourceManager.getInstance().localeChain = [usLocale];
			var e : DistanceFormatter = new DistanceFormatter();
			var databaseDistance : uint = 10200;
			var kilometerStringExpected : String = "10.2";
			var databaseDistanceMeters : String = e.toLocaleText(databaseDistance/1000);
			Assert.assertEquals(kilometerStringExpected, databaseDistanceMeters);
			
		}

		public function testToDkLocaleKilometerText() : void
		{
			var e : DistanceFormatter = new DistanceFormatter();
			var databaseDistance : uint = 10200;
			var kilometerStringExpected : String = "10,2";
			var databaseDistanceMeters : String = e.toLocaleText(databaseDistance/1000);
			Assert.assertEquals(kilometerStringExpected, databaseDistanceMeters);
		}
		
		public function testToMinutesPrKilometerShouldReturnFormattedText() : void
		{ 
			ResourceManager.getInstance().localeChain = [danishLocale];
			var e : DistanceFormatter = new DistanceFormatter();
			var average : String = e.toMinutesPrKilometer(1,1);
			
			var expectedDanishString : String = "1:01";
			assertEquals(expectedDanishString, average);			
		}
		
	}
}