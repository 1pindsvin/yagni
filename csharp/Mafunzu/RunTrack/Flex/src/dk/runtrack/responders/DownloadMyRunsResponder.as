package dk.runtrack.responders
{
	
	import mx.rpc.events.ResultEvent;
	
	public class DownloadMyRunsResponder extends BaseResponder
	{
		public function DownloadMyRunsResponder()
		{
			super();
		}

		override protected function updatePresentationModel(resultEvent:ResultEvent):void
		{
			var url : String = resultEvent.result as String;
			presentationModelLocator.downloadPresentationModel.url = url;
  		}
	}
}
