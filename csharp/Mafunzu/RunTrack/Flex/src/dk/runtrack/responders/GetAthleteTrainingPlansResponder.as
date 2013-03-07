package dk.runtrack.responders
{
	import dk.runtrack.model.Constants;
	
	import mx.rpc.events.ResultEvent;

	public class GetAthleteTrainingPlansResponder extends BaseResponder
	{
		public function GetAthleteTrainingPlansResponder()
		{
			super();
		}
		
		override protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var plans : Array = resultEvent.result as Array;
			if(plans==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION +", GetAthleteTrainingPlansResponder, resultEvent:ResultEvent")
			}
			presentationModelLocator.editTrainingPlanPresentationModel.setTrainingPlans(plans); 	
		}

	}
}