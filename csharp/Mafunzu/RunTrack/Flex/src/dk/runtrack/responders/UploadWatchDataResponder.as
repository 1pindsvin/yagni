package dk.runtrack.responders
{
	import mx.rpc.events.ResultEvent;

	public class UploadWatchDataResponder extends BaseResponder
	{
		public function UploadWatchDataResponder()
		{
			super();
		}
		
		override protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			trace("Data uploaded");
		}

	}
}