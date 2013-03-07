package dk.runtrack.responders
{
	import mx.rpc.events.ResultEvent;
	
	public class SaveShoesResponder extends GetAthleteShoesResponder
	{
		public function SaveShoesResponder()
		{
			super();
		}
		
		protected override function updatePresentationModel(resultEvent:ResultEvent):void
		{
			super.updatePresentationModel(resultEvent);
		} 
	}
}