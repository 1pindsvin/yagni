package dk.runtrack.responders
{
	import dk.runtrack.model.Athlete;
	import dk.runtrack.presentationmodels.RunActivityPresentationModel;
	import dk.runtrack.presentationmodels.EditAthletePresentationModel;
	
	import mx.rpc.events.ResultEvent;
	
	public class SaveAthleteResponder extends BaseResponder
	{
		public function SaveAthleteResponder()
		{
			super();
		}

		protected override function updatePresentationModel(resultEvent:ResultEvent):void
		{
			var athlete : Athlete = Athlete(resultEvent.result);
			presentationModelLocator.editAthletePresentationModel.currentathlete = athlete;
		}
		
	}
}