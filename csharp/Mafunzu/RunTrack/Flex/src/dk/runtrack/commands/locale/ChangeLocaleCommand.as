package dk.runtrack.commands.locale
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.DateTimeEnvironment;
	import dk.runtrack.presentationmodels.menu.MenuBuilder;
	
	import flash.events.Event;
	import flash.events.IEventDispatcher;
	
	import mx.collections.ArrayCollection;
	import mx.controls.Alert;
	import mx.events.ResourceEvent;
	import mx.resources.IResourceBundle;
	import mx.resources.IResourceManager;
	import mx.resources.ResourceBundle;
	import mx.resources.ResourceManager;

	public class ChangeLocaleCommand extends RtCommand
	{
		private var _locale:String;
		public function get locale():String
		{
			return _locale;
		}
		
		
		public function ChangeLocaleCommand(locale:String)
		{
			super();
			if (locale == null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", ChangeLocaleCommand, locale must be non-null");				
			}
			_locale = locale;
		}

		override public function execute():void
		{
			var newLocale:String = _locale;
			var resourceManager:IResourceManager = ResourceManager.getInstance();
			var loadedLocales:Array = resourceManager.getLocales();
			if (loadedLocales.indexOf(newLocale) != -1)
			{				
				 completeHandler(null);
				 return;
			}
			var resourceSwfPath:String = "locales/resources_" + newLocale + ".swf";
			var updateImmediately:Boolean = true;
			
			var eventDispatcher:IEventDispatcher = resourceManager.loadResourceModule(resourceSwfPath, updateImmediately);
			eventDispatcher.addEventListener(ResourceEvent.COMPLETE, completeHandler);
			eventDispatcher.addEventListener(ResourceEvent.ERROR, errorHandler);
		}
		
		private function completeHandler(event:Event):void
		{
			var resourceManager:IResourceManager = ResourceManager.getInstance();
						 
			var menuBuilder:MenuBuilder = new MenuBuilder(new PresentationModelLocator().applicationPresentationModel.supportedLocales);
			var menuItems:ArrayCollection = menuBuilder.createApplicationMenu(_locale);
			
			var resourceBundle:IResourceBundle = resourceManager.getResourceBundle(_locale, "menu");
			
			DateTimeEnvironment.updateDateFormat();
			
			if (!resourceBundle)
			{
				resourceBundle = new ResourceBundle(_locale, "menu");				
				resourceManager.addResourceBundle(resourceBundle);
			}	
			resourceBundle.content["menuItems"] = menuItems;
			resourceManager.localeChain = [ _locale ];
			resourceManager.update();			
		}
		
		private function errorHandler(event:Event):void
		{
			Alert.show("the locale:" + locale + " could not be loaded");	
		}
		
		
		
	}
}