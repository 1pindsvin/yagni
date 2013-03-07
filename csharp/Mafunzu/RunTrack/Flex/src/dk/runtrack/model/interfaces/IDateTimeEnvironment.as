package dk.runtrack.model.interfaces
{
	
	public interface IDateTimeEnvironment
	{
		function get dateIndex() : uint;
		function get monthIndex() : uint;
		function get yearIndex() : uint;
		function get dateSeparator() : String;
		function get timeSeparator() : String;
		function get dateFormat() : String;
		function get timeFormat() : String;
	}
}