package dk.runtrack.commands
{
	import com.adobe.cairngorm.commands.ICommand;
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import dk.runtrack.controller.RtRemoteService;
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	
	import mx.rpc.AsyncToken;
	import mx.rpc.IResponder;

	public class BaseCommand implements ICommand
	{
		public static var resolveRemoteService : Function =
			function () : IRtRemoteService
			{
				return new RtRemoteService();
			}

		private var _remoteService : IRtRemoteService

		private var _responder : IResponder;
		
		protected final function get remoteService() : IRtRemoteService
		{
			return _remoteService;	
		}
		
		public final function get responder() : IResponder
		{
			return _responder
		}

		public final function set responder(value:IResponder) : void
		{
			_responder = value;
		}
		
		protected final function dispatch(remoteCall:AsyncToken) : void
		{
			if(_responder==null)
			{
				throw new Error("Responder is not set");
			}
			remoteCall.addResponder(_responder);			
		}
		
		public function BaseCommand()
		{
			_remoteService = resolveRemoteService();	
		}

		public function execute(event:CairngormEvent):void
		{
			throw new Error("Invalid operation, subclasses must override execute");			
		}
		
	}
}