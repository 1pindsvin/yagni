package dk.runtrack.responders
{
	import dk.runtrack.Factory;
	import dk.runtrack.model.interfaces.IClientModel;
	import dk.runtrack.presentationmodels.interfaces.IEditRunPresentationModel;
	
	import mx.rpc.events.ResultEvent;

	public class GetAthleteShoesResponder extends BaseResponder
	{
		
		public static var getClient : Function = Factory.getClient;
		
		public function GetAthleteShoesResponder()
		{
			super();
		}
		
		private var _registerRunViewModel : IEditRunPresentationModel;
		public function get registerRunViewModel() : IEditRunPresentationModel
		{
			if(_registerRunViewModel==null)
			{
				_registerRunViewModel = presentationModelLocator.editRunViewModel;
			}	
			return _registerRunViewModel;
		}
		
		public function set registerRunViewModel(v: IEditRunPresentationModel) : void
		{
			_registerRunViewModel = v;
		} 
		
		override protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			var shoes : Array = resultEvent.result as Array;
			var client : IClientModel = getClient();
			client.loadedShoes = shoes.concat();
		}
	}
}