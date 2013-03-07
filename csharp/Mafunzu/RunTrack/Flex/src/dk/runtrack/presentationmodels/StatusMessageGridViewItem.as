package dk.runtrack.presentationmodels
{
	public class StatusMessageGridViewItem
	{
		public static const MESSAGE_TYPE_RESOURCE_LOOKUP : int = 0;
		public static const MESSAGE_TYPE_STATUS : int = 1;
		
		public function StatusMessageGridViewItem(newMessage: String)
		{
			message = newMessage;
			type = MESSAGE_TYPE_STATUS;
		}
		
		public var message : String;
			
		public var type : int;
		
		
		
	}
}