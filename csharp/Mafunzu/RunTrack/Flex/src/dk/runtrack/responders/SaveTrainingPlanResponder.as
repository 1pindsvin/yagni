package dk.runtrack.responders
{
	import dk.runtrack.model.TrainingPlan;
	
	import mx.rpc.events.ResultEvent;

	public class SaveTrainingPlanResponder extends BaseResponder
	{
		public function SaveTrainingPlanResponder()
		{
			super();
		}
		
		override protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var trainingPlan : TrainingPlan = TrainingPlan(resultEvent.result);
			presentationModelLocator.editTrainingPlanPresentationModel.trainingPlan = trainingPlan;
		}

	}
}