package dk.runtrack.responders
{
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.MonthQuery;
	
	import mx.rpc.events.ResultEvent;

	public class SetSelectedMonthResponder extends BaseResponder
	{
		public function SetSelectedMonthResponder()
		{
			super();
		}

		protected override function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var monthQuery : MonthQuery = resultEvent.result as MonthQuery;
			if (monthQuery == null)
			{
				var message : String = ", expected monthQuery on resultevent";
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + message);
			}
			presentationModelLocator.monthViewPresentationModel.monthViewData.monthQuery = monthQuery;
		}

	}
}