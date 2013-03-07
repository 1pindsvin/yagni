package dk.runtrack.commands
{
	import mx.messaging.messages.IMessage;
	import mx.rpc.AsyncToken;
	import mx.rpc.events.ResultEvent;
	
	public class ResultEventBuilder
	{
		public function ResultEventBuilder()
		{
		}

		private static var _message : IMessage ;
		public static function build(result:Object) : ResultEvent
		{
			
			var resultEvent : ResultEvent = 
				new ResultEvent(
					ResultEvent.RESULT, false,false,result, new AsyncToken(_message),null);
			return resultEvent;			
		}

	}
}