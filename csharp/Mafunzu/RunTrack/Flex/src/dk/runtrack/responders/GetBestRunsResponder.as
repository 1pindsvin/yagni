package dk.runtrack.responders
{
	import dk.runtrack.model.BestRunsQuery;
	import dk.runtrack.model.Constants;
	
	import mx.rpc.events.ResultEvent;

	public class GetBestRunsResponder extends BaseResponder
	{
		public function GetBestRunsResponder()
		{
			super();
		}
	
		override protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var query : BestRunsQuery = resultEvent.result as BestRunsQuery;
			if(query==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION +", GetBestRunsResponder, resultEvent:ResultEvent")
			}
			presentationModelLocator.bestRunsPresentationModel.setQuery(query);
			presentationModelLocator.runActivityPresentationModel.setRuns(query.Runs);
		}

	}
}