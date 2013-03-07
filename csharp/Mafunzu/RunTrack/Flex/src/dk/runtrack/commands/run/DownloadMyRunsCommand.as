package dk.runtrack.commands.run
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.responders.DownloadMyRunsResponder;
	import dk.runtrack.presentationmodels.interfaces.IEditAthletePresentationModel;
	
	import mx.rpc.IResponder;

	public class DownloadMyRunsCommand extends RtCommand
	{
		public static var resolveAthleteViewModel : Function = function() : IEditAthletePresentationModel
		{
			return new PresentationModelLocator().editAthletePresentationModel;
		}

		public static var resolveResponder : Function = function() : IResponder
		{
			return new DownloadMyRunsResponder();
		}
		
		public function DownloadMyRunsCommand()
		{
			this.responder = resolveResponder();	
		}

		override public function execute():void
		{
			var athleteViewModel : IEditAthletePresentationModel = resolveAthleteViewModel(); 
			var athlete : Athlete = athleteViewModel.currentathlete;
			dispatch(remoteService.downloadMyRuns(athlete));						
		}
		
	}
}