package dk.runtrack.responders
{
	import dk.runtrack.model.Run;
	import dk.runtrack.model.RunsPage;
	
	import mx.rpc.events.ResultEvent;
	
	public class RunPageResponder extends BaseResponder
	{
		public function RunPageResponder()
		{
			super();
		}
		
		protected override function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var runspage : RunsPage = resultEvent.result as RunsPage;
			if (runspage == null)
			{
				var message : String = "Expected RunsPage on resultevent";
				throw new Error(message);
			}
			presentationModelLocator.runActivityPresentationModel.runsPage = runspage;
			presentationModelLocator.monthViewPresentationModel.monthViewData.runsPage = runspage;
		}
	}
}