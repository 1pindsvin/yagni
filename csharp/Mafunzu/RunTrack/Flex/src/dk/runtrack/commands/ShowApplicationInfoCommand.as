package dk.runtrack.commands
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.view.components.ApplicationInfoView;
	
	import flash.display.DisplayObject;
	
	import mx.core.FlexGlobals;
	import mx.core.IFlexDisplayObject;
	import mx.managers.PopUpManager;
	import mx.managers.PopUpManagerChildList;
	
	public class ShowApplicationInfoCommand implements IRtCommand
	{
		public function ShowApplicationInfoCommand()
		{
			super();
		}
		
		public function execute():void
		{
			var modal:Boolean = true;
			var parent:DisplayObject = DisplayObject (FlexGlobals.topLevelApplication.parentDocument);			
			var popup:IFlexDisplayObject = PopUpManager.createPopUp(parent, ApplicationInfoView, modal,PopUpManagerChildList.POPUP);
			PopUpManager.centerPopUp(popup);	
		}
		
	}
}