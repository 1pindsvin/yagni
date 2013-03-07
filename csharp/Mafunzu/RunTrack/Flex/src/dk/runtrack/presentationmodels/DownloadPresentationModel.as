package dk.runtrack.presentationmodels
{
	import dk.runtrack.presentationmodels.interfaces.IDownloadPresentationModel;

	public class DownloadPresentationModel implements IDownloadPresentationModel
	{
		public function DownloadPresentationModel()
		{

		}

		private var _downloadUrl : String;
		
		public function get url():String
		{
			return _downloadUrl;
		}
		
		public function set url(v:String):void
		{
			_downloadUrl = v;
		}


		
	}
}