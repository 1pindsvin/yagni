package dk.runtrack.responders
{
	
	import dk.runtrack.io.CookieAdapter;
	import dk.runtrack.model.Run;
	import dk.runtrack.presentationmodels.RunActivityPresentationModel;
	import dk.runtrack.presentationmodels.EditRunPresentationModel;
	
	import mx.rpc.events.ResultEvent;

	public class SaveRunResponder extends BaseResponder
	{
		public function SaveRunResponder()
		{
			super();
		}
		
	
		protected override function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			
			var run : Run = Run(resultEvent.result);
			
			var cookie : CookieAdapter = new CookieAdapter();
			cookie.lastSavedShoeID = run.Shoe ? run.Shoe.ID : 0;

			presentationModelLocator.editRunViewModel.editRun = run;			
			presentationModelLocator.editRunViewModel.updateState(EditRunPresentationModel.STATE_RUN_SAVED);
			presentationModelLocator.runActivityPresentationModel.updateState(RunActivityPresentationModel.STATE_RUN_SAVED);
		}
	}
}