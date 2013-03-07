package dk.runtrack.responders
{
	import dk.runtrack.model.Run;
	import dk.runtrack.presentationmodels.RunActivityPresentationModel;
	
	import mx.rpc.events.ResultEvent;

	public class UndoDeleteRunResponder extends BaseResponder
	{
		public function UndoDeleteRunResponder()
		{
			super();
		}

		protected override function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var run : Run = Run(resultEvent.result);
			presentationModelLocator.runActivityPresentationModel.updateState(RunActivityPresentationModel.STATE_RUN_SAVED);
		}

	}
}