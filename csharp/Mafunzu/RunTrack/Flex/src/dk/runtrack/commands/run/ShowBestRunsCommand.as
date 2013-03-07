package dk.runtrack.commands.run
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.view.components.BestRunsView;
	
	import flash.display.DisplayObject;
	
	import mx.core.FlexGlobals;
	import mx.core.IFlexDisplayObject;
	import mx.managers.PopUpManager;
	
	public class ShowBestRunsCommand implements IRtCommand
	{
		public function ShowBestRunsCommand()
		{
			
		}
		
		public function execute():void
		{
			var modal:Boolean = true;
			var parent:DisplayObject = DisplayObject (FlexGlobals.topLevelApplication.parentDocument);			
			var popup:IFlexDisplayObject = PopUpManager.createPopUp(parent, BestRunsView, modal);
			PopUpManager.centerPopUp(popup);			
		}
	}
}