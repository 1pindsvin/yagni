package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Constants;
	
	import mx.collections.ArrayCollection;
	
	public class StatusMessageViewModel
	{
		
		private var _messages:ArrayCollection;
		private var _maxSavedMessages:int;
		
		[Bindable]
		public function set messages(value:ArrayCollection):void
		{
			_messages = value;
		}
		
		public function get messages():ArrayCollection
		{
			return _messages;
		}
		
		public function StatusMessageViewModel()
		{
			_messages = new ArrayCollection();
			_maxSavedMessages = 10;
		}
		
		public function addStatusMessage(message : String):void
		{
			if (message == null)
			{
				return;
			}
			addStatusGridItem(new StatusMessageGridViewItem(message));
		}
		
		public function addStatusGridItem(message : StatusMessageGridViewItem):void
		{
			if (message == null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION);
			}
			if (messages.length > _maxSavedMessages)
			{
				messages.removeAll();				
			}
			messages.addItemAt(message, 0);						
		}

	}
}