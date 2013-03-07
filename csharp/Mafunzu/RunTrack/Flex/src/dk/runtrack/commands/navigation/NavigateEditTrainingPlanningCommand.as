package dk.runtrack.commands.navigation
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.commands.trainingplanning.GetAthleteTrainingPlansCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.presentationmodels.ApplicationPresentationModel;

	public class NavigateEditTrainingPlanningCommand implements IRtCommand
	{
		public function execute() : void
		{
			var command : IRtCommand = new GetAthleteTrainingPlansCommand();
			new RunTrackEvent(command).dispatch();

			var presentationModelLocator : IPresentationModelLocator = new PresentationModelLocator();
			presentationModelLocator.applicationPresentationModel.state = ApplicationPresentationModel.STATE_TRAINING_PLANNING_PERSPECTIVE;
		}
	}
}