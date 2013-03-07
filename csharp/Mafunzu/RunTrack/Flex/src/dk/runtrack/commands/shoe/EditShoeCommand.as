package dk.runtrack.commands.shoe
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.view.components.EditShoeView;
	
	import flash.display.DisplayObject;
	
	import mx.core.Application;
	import mx.core.FlexGlobals;
	import mx.core.IFlexDisplayObject;
	import mx.managers.PopUpManager;

	public class EditShoeCommand implements IRtCommand
	{
		public function EditShoeCommand()
		{
		}

		public function execute():void
		{
			var modal:Boolean = true;
			var parent:DisplayObject = DisplayObject (FlexGlobals.topLevelApplication.parentDocument);			
			var popup:IFlexDisplayObject = PopUpManager.createPopUp(parent, EditShoeView, modal);
			PopUpManager.centerPopUp(popup);			
		}
		
	}
}