package dk.runtrack.presentationmodels.menu
{
	import dk.runtrack.commands.ShowApplicationInfoCommand;
	import dk.runtrack.commands.locale.ChangeLocaleCommand;
	import dk.runtrack.commands.navigation.NavigateEditTrainingCommand;
	import dk.runtrack.commands.navigation.NavigateEditTrainingPlanningCommand;
	import dk.runtrack.commands.navigation.ShowDownloadDialogCommand;
	import dk.runtrack.commands.run.DownloadMyRunsCommand;
	import dk.runtrack.commands.run.ShowBestRunsCommand;
	import dk.runtrack.commands.shoe.EditShoeCommand;
	import dk.runtrack.commands.user.EditUserCommand;
	import dk.runtrack.events.RunTrackEvent;
	
	import mx.collections.ArrayCollection;
	import mx.resources.IResourceManager;
	import mx.resources.ResourceManager;
	
	public class MenuBuilder
	{				
		
		private static var _resourceManager:IResourceManager = ResourceManager.getInstance();;
		private var _supportedLocales:Array;
		
		public function MenuBuilder(supportedLocales:Array)
		{
			_supportedLocales = supportedLocales;		
		}
		
		
		public function createApplicationMenu(locale:String):ArrayCollection		
		{
			var applicationMenu:ArrayCollection = new ArrayCollection();

			var settingsMenu:MenuItem = createSettingsMenu(locale);
			applicationMenu.addItem(settingsMenu);

			var selectViewMenu : MenuItem = createSelectViewMenu(locale);
			applicationMenu.addItem(selectViewMenu);
			
			var downloadMenu : MenuItem = createDownloadMenu(locale);
			applicationMenu.addItem(downloadMenu);
			
			return applicationMenu;			
		}
		
		private static function createSeparator():MenuItem
		{
			var menuItem:MenuItem = new MenuItem();
			menuItem.type = MenuItemType.SEPARATOR;
			return menuItem;
		}

		private function createDownloadMenu(locale:String):MenuItem
		{			
			var downloadMenu:MenuGroup = new MenuGroup(_resourceManager.getString("applicationMenuBar", "download", [], locale));
			downloadMenu.action = new DownloadMyRunsCommand();

			var myRuns : MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar", "my.runs", [], locale));
			myRuns.action = new ShowDownloadDialogCommand(); 
			
			downloadMenu.addChild(myRuns);
			return downloadMenu;
		}
		

		private function createSelectViewMenu(locale:String):MenuItem
		{
			var selectViewMenuGroup :MenuGroup = new MenuGroup(_resourceManager.getString("applicationMenuBar", "select.view", [], locale));
			
			var navigateEditTrainingPlanningView : MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar", "navigate.edit-training-planning-view", [], locale));
			navigateEditTrainingPlanningView.action = new NavigateEditTrainingPlanningCommand(); 

			var navigateEditTrainingView : MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar", "navigate.edit-training-view", [], locale));
			navigateEditTrainingView.action = new NavigateEditTrainingCommand(); 
			
			selectViewMenuGroup.addChild(navigateEditTrainingPlanningView);
			selectViewMenuGroup.addChild(navigateEditTrainingView);
			
			return selectViewMenuGroup;

		}
		
	
		private function createSettingsMenu(locale:String):MenuItem
		{			
			var settingsGroup:MenuGroup = new MenuGroup(_resourceManager.getString("applicationMenuBar", "settings", [], locale));

			var personalInformation:MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar", "personal.information", [], locale));
			personalInformation.action = new EditUserCommand();

			var myShoes : MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar", "my.shoes", [], locale));
			myShoes.action = new EditShoeCommand(); 

			var bestRuns : MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar", "my.best.runs", [], locale));
			bestRuns.action = new ShowBestRunsCommand(); 

			var applicationInformation:MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar", "application.information", [], locale));			
			applicationInformation.action = new ShowApplicationInfoCommand();
			
			var languageGroup:MenuGroup = new MenuGroup(_resourceManager.getString("applicationMenuBar","language", [], locale));
			
			var length:int = _supportedLocales.length;
			
			for (var i:int = 0; i < length; i++)
			{
				var currentLocale:String = _supportedLocales[i];
				var languageTextKey:String = "language." + currentLocale;
				var menuItem:MenuItem = new MenuItem(_resourceManager.getString("applicationMenuBar",languageTextKey, [], locale));
				menuItem.groupName = "language";
				menuItem.type = MenuItemType.RADIO;
				menuItem.action = new ChangeLocaleCommand(currentLocale);
				menuItem.toggled = locale == currentLocale;
				languageGroup.addChild(menuItem);
			}	
			
			settingsGroup.addChild(personalInformation);
			settingsGroup.addChild(myShoes);
			settingsGroup.addChild(bestRuns);
			settingsGroup.addChild(languageGroup);
			settingsGroup.addChild(applicationInformation);
			return settingsGroup;
		}
		
		

	}
}