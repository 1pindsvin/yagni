package dk.runtrack.responders
{
	import dk.runtrack.Factory;
	import dk.runtrack.model.interfaces.IClientModel;
	import dk.runtrack.model.Run;
	
	import mx.rpc.events.ResultEvent;
	
	public class DeleteRunResponder extends BaseResponder
	{
		
		public static var getClient : Function = Factory.getClient;  
		
		public function DeleteRunResponder()
		{
			super();
		}

		protected override function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var run : Run = resultEvent.result as Run;
			var client : IClientModel = getClient();
			client.runHasBeenDeleted(run.ID);
		}

	}
}