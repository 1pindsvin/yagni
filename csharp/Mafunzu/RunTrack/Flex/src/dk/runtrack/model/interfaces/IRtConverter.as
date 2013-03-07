package dk.runtrack.model.interfaces
{
	public interface IRtConverter
	{
		function toPresentationValue(dbValue : int) : String;
		function toDbValue(presentationValue : String) : int;
	}
}