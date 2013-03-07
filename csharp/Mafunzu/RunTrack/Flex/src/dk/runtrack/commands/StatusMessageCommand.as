package dk.runtrack.commands
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Constants;
	import dk.runtrack.presentationmodels.StatusMessageGridViewItem;
	
	import flash.utils.getQualifiedClassName;

	public class StatusMessageCommand implements  IRtCommand
	{
		
		public static var resolveViewModelLocator : Function =
			function () : IPresentationModelLocator
			{
				return new PresentationModelLocator();
			}

		private var  _viewModel : Object;
		public function StatusMessageCommand(viewModel : Object) 
		{
			if(viewModel==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION);
			}
			_viewModel = viewModel;
		}

		private var _displayableState : String;
		public function get displayableState() : String
		{
			if(_displayableState==null)
			{
				return _viewModel.state;
			}
			return _displayableState;				
		}

		public function set displayableState(value : String) : void
		{
			_displayableState = value;					
		}


		private function buildLookupMessage(className : String) : StatusMessageGridViewItem
		{
			var message : String = className.toLowerCase() + "." + displayableState;
			var gridItem : StatusMessageGridViewItem = new StatusMessageGridViewItem(message);
			gridItem.type = StatusMessageGridViewItem.MESSAGE_TYPE_RESOURCE_LOOKUP; 
			return gridItem;
		} 

		public function execute():void
		{
			var presentationModelLocator : IPresentationModelLocator = resolveViewModelLocator();
			
			var classTokens : Array = getQualifiedClassName(_viewModel).split("::")
			var className : String = classTokens[classTokens.length-1];
			var item : StatusMessageGridViewItem = buildLookupMessage(className);
			
			presentationModelLocator.statusMessageViewModel.addStatusGridItem(item);			
				
		}

		
	}
}