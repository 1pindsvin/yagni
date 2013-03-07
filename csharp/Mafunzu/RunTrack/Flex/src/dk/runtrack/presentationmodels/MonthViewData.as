package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.MonthQuery;
	import dk.runtrack.model.RunsPage;

	public class MonthViewData
	{
		
		public function get runsPage():RunsPage
		{
			return _runsPage;
		}

		public function set runsPage(value:RunsPage):void
		{
			_runsPage = value;
			_update();
		}

		private var _update : Function;
		public function MonthViewData(updateFunction : Function)
		{
			if(updateFunction==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + ", updateFunction : Function");
			}
			_update = updateFunction;
			monthQuery = new MonthQuery();
		}
		private var _runsPage : RunsPage;
		
		public var athlete : Athlete;
		public var monthQuery : MonthQuery;

	}
}