package dk.runtrack
{
	import dk.runtrack.model.ClientModel;
	import dk.runtrack.model.interfaces.IClientModel;
	
	public class Factory
	{
		public function Factory()
		{
			
		}
		
		public static function getClient() : IClientModel
		{
			return ClientModel.data;
		} 
	}
}