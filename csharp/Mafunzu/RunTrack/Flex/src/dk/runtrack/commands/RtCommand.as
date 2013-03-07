package dk.runtrack.commands
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.model.Constants;

	import dk.runtrack.controller.RtRemoteService;
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	
	import mx.rpc.AsyncToken;
	import mx.rpc.IResponder;
	
	public class RtCommand implements IRtCommand
	{

		public static var resolveRemoteService : Function =
			function () : IRtRemoteService
			{
				return new RtRemoteService();
			}

		public function RtCommand()
		{
			_remoteService = resolveRemoteService();	
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

		public function execute():void
		{
			throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", subclasses must override execute");		
		}
		
	}
}