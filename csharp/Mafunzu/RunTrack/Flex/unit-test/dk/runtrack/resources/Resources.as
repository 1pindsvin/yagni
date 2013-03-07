package dk.runtrack.resources
{
	
	import dk.runtrack.model.DistanceFormatter;
	
	import mx.resources.IResourceBundle;
	import mx.resources.IResourceManager;
	import mx.resources.ResourceBundle;
	import mx.resources.ResourceManager;
	
	public class Resources
	{
		public static const US_LOCALE : String = "en_US"; 	
		public static const DK_LOCALE : String = "da_DK";
		public static const SUPPORTED_LOCALES:Array = [US_LOCALE, DK_LOCALE];

		public function Resources()
		{

		}
		
		private static var _currentLocale : String = US_LOCALE;
		public static function set currentLocale(value:String) : void
		{
			_currentLocale = value;
			ResourceManager.getInstance().localeChain = [_currentLocale];
		}
		
		public static function get currentLocale() : String
		{
			return _currentLocale;
		}
		
		
		
		public static function setup() : void
		{
			var res : Resources = new Resources();
			res.ensureSharedResourcesBundle();
			res.ensureValidatorResourceBundles();
			manager.localeChain = [DK_LOCALE];
		} 
		

		public static function tearDown() : void
		{
			for each (var bundleName : String in [SHARED_RESOURCES, DistanceFormatter.VALIDATOR_BUNDLE_NAME])
			{
				manager.removeResourceBundle(DK_LOCALE, bundleName);
				manager.removeResourceBundle(US_LOCALE, bundleName);
			}
			manager.localeChain = [];
		}

		private static function get manager() : IResourceManager
		{
			return ResourceManager.getInstance();
		}

		private static const SHARED_RESOURCES : String = "SharedResources";
		private static const DATE_FORMAT : String = "dateFormat";
		
		private function ensureSharedResourcesBundle() : void
		{
			var resourceManager : IResourceManager = ResourceManager.getInstance();

			var strings : IResourceBundle  = new ResourceBundle(DK_LOCALE, SHARED_RESOURCES);
			strings.content[DATE_FORMAT] = "DD-MM-YYYY";
			
			resourceManager.addResourceBundle(strings);

			strings  = new ResourceBundle(US_LOCALE, SHARED_RESOURCES);
			strings.content[DATE_FORMAT] = "MM/DD/YYYY";

			resourceManager.addResourceBundle(strings);
		
		}


		private function ensureValidatorResourceBundles() : void
		{
			var resourceManager : IResourceManager = ResourceManager.getInstance();

			var strings : IResourceBundle  = new ResourceBundle(DK_LOCALE, DistanceFormatter.VALIDATOR_BUNDLE_NAME);
			strings.content[DistanceFormatter.DECIMAL_SEPARATOR_NAME] = ",";
			strings.content["thousandsSeparator"] = "\.";
			
			resourceManager.addResourceBundle(strings);

			strings  = new ResourceBundle(US_LOCALE, DistanceFormatter.VALIDATOR_BUNDLE_NAME);
			strings.content[DistanceFormatter.DECIMAL_SEPARATOR_NAME] = "\.";
			strings.content["thousandsSeparator"] = ",";

			resourceManager.addResourceBundle(strings);
		}
		

	}
}