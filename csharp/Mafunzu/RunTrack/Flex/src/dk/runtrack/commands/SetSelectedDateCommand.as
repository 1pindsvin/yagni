package dk.runtrack.commands
{
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.RunsPage;
	import dk.runtrack.responders.RunPageResponder;
	
	import mx.rpc.IResponder;

	public class SetSelectedDateCommand extends RtCommand
	{
		public static var resolveViewModelLocator : Function =
			function () : IPresentationModelLocator
			{
				return new PresentationModelLocator();
			}

		public static var resolveResponder : Function =
			function () : IResponder
			{
				return new RunPageResponder();
			}
		
		
		private var _selectedDate : Date;
		private var _athlete : Athlete;
		
		public function SetSelectedDateCommand(selectedDate : Date )
		{
			if(selectedDate==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
			}
			_selectedDate = selectedDate;

			var presentationModelLocator : IPresentationModelLocator = resolveViewModelLocator();
			_athlete = presentationModelLocator.editAthletePresentationModel.currentathlete;
			if(_athlete==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", current athlete was null");
			}
		}

		public override function execute():void
		{
			var runsPage : RunsPage = new RunsPage();
			runsPage.Athlete = _athlete;
			runsPage.ByDateTime = _selectedDate;

			responder = resolveResponder();
			dispatch(remoteService.getRunsPage(runsPage));
		}
		
	}
}