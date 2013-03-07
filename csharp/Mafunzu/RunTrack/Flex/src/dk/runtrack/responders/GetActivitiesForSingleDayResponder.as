package dk.runtrack.responders
{
	import dk.runtrack.model.Activity;
	import dk.runtrack.model.ActivityQuery;
	import dk.runtrack.model.Constants;
	
	import mx.rpc.events.ResultEvent;
	

	public class GetActivitiesForSingleDayResponder extends BaseResponder
	{
		public function GetActivitiesForSingleDayResponder()
		{
			super();
		}
		
		protected override function updatePresentationModel(resultEvent:ResultEvent):void
		{
			var query : ActivityQuery = resultEvent.result as ActivityQuery;
			if(query==null)
			{
				throw new Error("resultEvent.result as ActivityQuery");
			}
			var activity : Activity = query.Items.length > 0 ? query.Items[0] : null;
			presentationModelLocator.editActivityPresentationModel.editActivity = activity;
		}
	}
}