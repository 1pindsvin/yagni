package dk.runtrack.commands.run
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Run;

	public class SetSelectedRunCommand implements IRtCommand
	{
		public static var resolveViewModelLocator : Function =
			function () : IPresentationModelLocator
			{
				return new PresentationModelLocator();
			}

		private var _run : Run;
		public function SetSelectedRunCommand(run : Run)
		{
			_run = run;
		}

		public function execute():void
		{
			var presentationModelLocator : IPresentationModelLocator = resolveViewModelLocator();
			presentationModelLocator.editRunViewModel.editRun = _run;
		}
		
	}
}