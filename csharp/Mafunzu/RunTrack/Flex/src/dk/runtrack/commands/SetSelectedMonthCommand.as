package dk.runtrack.commands
{
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.MonthQuery;
	import dk.runtrack.responders.SetSelectedMonthResponder;
	
	import mx.resources.ResourceManager;
	import mx.rpc.IResponder;
	
	public class SetSelectedMonthCommand extends RtCommand
	{
		public static var resolveViewModelLocator : Function =
			function () : IPresentationModelLocator
			{
				return new PresentationModelLocator();
			}

		public static var resolveResponder : Function =
			function () : IResponder
			{
				return new SetSelectedMonthResponder();
			}
	
			
		
		private var _date : Date;
		private var _athlete : Athlete;
		private var _weekStartsOnMonday : Boolean;
		
		public function SetSelectedMonthCommand(date: Date)
		{
			if(date==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + ", date expected");
			}
			_date = date;
			var presentationModelLocator : IPresentationModelLocator = resolveViewModelLocator();
			_athlete = presentationModelLocator.editAthletePresentationModel.currentathlete;
			if(_athlete==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + ", athlete expected");
			}
			_weekStartsOnMonday = ResourceManager.getInstance().localeChain[0]== Constants.DANISH_LOCALE;
		}
		
		public override function execute():void
		{
			responder = resolveResponder();
			var monthQuery : MonthQuery = new MonthQuery();
			monthQuery.Month = _date.month + 1;
			monthQuery.Year = _date.fullYear;
			monthQuery.DayActivities = new Array();
			monthQuery.WeekStartsOnMonday = _weekStartsOnMonday;
			monthQuery.Athlete = _athlete;
			
			dispatch(remoteService.getMonthQuery(monthQuery));
		}
	}
}