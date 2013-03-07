package dk.runtrack.responders
{
	import dk.runtrack.model.User;
	import mx.resources.IResourceManager;
	import mx.resources.ResourceManager;
	
	import mx.events.MetadataEvent;
	import mx.rpc.events.ResultEvent;
	
	public class SaveUserResponder extends BaseResponder
	{
		private var _resourceManager:IResourceManager;
		
		public function get resourceManager():IResourceManager
		{
			if (_resourceManager==null)
			{
				_resourceManager = ResourceManager.getInstance();
			}
			return _resourceManager;
		}
		

		
		public function SaveUserResponder()
		{
			super();
		}
		
		
		
		protected override function updatePresentationModel(resultEvent:ResultEvent) : void
		{			
			var user : User = resultEvent.result as User;
			presentationModelLocator.loginPresentationModel.currentuser = user;
			var message:String = resourceManager.getString("statusMessages", "user.saved", [], "da_DK"); 
			presentationModelLocator.statusMessageViewModel.addStatusMessage(message); 
		}
		
	}
}