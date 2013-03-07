package dk.runtrack.responders
{
	import dk.runtrack.model.AthleteHealthQuery;
	
	import mx.rpc.events.ResultEvent;

	public class GetHealthHistoryResponder extends BaseResponder
	{
		public function GetHealthHistoryResponder()
		{
			super();
		}
		
		override protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var query : AthleteHealthQuery = AthleteHealthQuery( resultEvent.result);
			presentationModelLocator.athleteHealthHistoryPresentationModel.setAthleteHealthQuery(query);
		}

	}
}