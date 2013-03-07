package dk.runtrack.responders
{
	import dk.runtrack.model.Constants;
	
	import mx.rpc.events.ResultEvent;

	public class GetPlannedRunsResponder extends BaseResponder
	{
		public function GetPlannedRunsResponder()
		{
			super();
		}
		
		override protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var runs : Array = resultEvent.result as Array;
			if(runs==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION +", GetPlannedRunsResponder, resultEvent:ResultEvent")
			}
			presentationModelLocator.runChartPresentationModel.setRuns(runs); 	
		}
	}
}