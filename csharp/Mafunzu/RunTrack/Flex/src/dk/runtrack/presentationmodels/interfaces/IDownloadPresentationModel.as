package dk.runtrack.presentationmodels.interfaces
{
	[Bindable]
	public interface IDownloadPresentationModel
	{
		function get url() : String;
		function set url(v : String) : void;
	}
}