package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.presentationmodels.MonthViewData;
	
	import mx.collections.IList;

	[Bindable]
	public interface IMonthViewPresentationModel
	{
		function get state():String;
		function get date() : Date;
		function set date(value :Date) : void;
		function previousMonth() : void;
		function nextMonth() : void;

		function get activities() : Array;
		function set activities(v : Array) : void;
		
		function get selectedMonthIndex() : int;
		function set selectedMonthIndex(v : int) : void;
		
		function get selectedYear() : int;
		function set selectedYear(v : int) : void;
		
		function get monthViewData() : MonthViewData;
	}
}