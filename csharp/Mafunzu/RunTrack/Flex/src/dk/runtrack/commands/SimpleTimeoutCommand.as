package dk.runtrack.commands
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.presentationmodels.interfaces.IRunActivityPresentationModel;

	public class SimpleTimeoutCommand implements IRtCommand
	{
		private var _athleteRunsViewModel : IRunActivityPresentationModel;
		public function SimpleTimeoutCommand(runActivityPresentationModel : IRunActivityPresentationModel)
		{
			_athleteRunsViewModel = runActivityPresentationModel;
		}

		public function execute():void
		{
			_athleteRunsViewModel.showUndo = false;
		}
		
	}
}