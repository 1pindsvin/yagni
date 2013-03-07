package dk.runtrack.presentationmodels
{
	import dk.runtrack.presentationmodels.interfaces.IMonthViewPresentationModel;

	[Bindable]
	public class DummyMonthPresentationModel implements IMonthViewPresentationModel
	{
		public function DummyMonthPresentationModel()
		{
			_monthViewData = new MonthViewData(function(): void{});	
		}
		
		public function get state():String
		{
			return null;
		}
		
		public function get date():Date
		{
			return null;
		}
		
		public function set date(value:Date):void
		{
		}
		
		private var _monthViewData : MonthViewData;
		public function get monthViewData():MonthViewData
		{
			return _monthViewData;
		}
		
		public function previousMonth() : void
		{

		}
		
		public function nextMonth() : void
		{
		
		}
		
		public var activities : Array;	
		
		public var selectedMonthIndex : int;

		public var selectedYear : int;
		
	}
}