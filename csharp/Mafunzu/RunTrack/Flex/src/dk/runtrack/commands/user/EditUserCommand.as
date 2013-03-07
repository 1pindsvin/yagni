package dk.runtrack.commands.user
{
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.view.components.EditAthtlete;
	
	import flash.display.DisplayObject;
	
	import mx.core.FlexGlobals;
	import mx.core.IFlexDisplayObject;
	import mx.managers.PopUpManager;

	/**
	 * Command to begin the editing of a user's personal information.
	 * @author Rasmus
	 * 
	 */
	public class EditUserCommand extends RtCommand
	{
		public function EditUserCommand()
		{
			super();
		}
		
		public override function execute():void
		{
			var modal:Boolean = true;
			var parent:DisplayObject = DisplayObject (FlexGlobals.topLevelApplication.parentDocument);			
			var popup:IFlexDisplayObject = PopUpManager.createPopUp(parent, EditAthtlete, modal);
			PopUpManager.centerPopUp(popup);			
		}
		
	}
}