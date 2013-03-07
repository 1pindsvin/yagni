package dk.runtrack.commands.navigation
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.presentationmodels.ApplicationPresentationModel;
	
	public class NavigateEditTrainingCommand implements IRtCommand
	{
		public function NavigateEditTrainingCommand()
		{
		}
		
		public function execute():void
		{
			var presentationModelLocator : IPresentationModelLocator = new PresentationModelLocator();
			presentationModelLocator.applicationPresentationModel.state = ApplicationPresentationModel.STATE_TRAINING_PERSPECTIVE;
		}
	}
}