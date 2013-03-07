package dk.runtrack.commands.user
{
	import com.adobe.cairngorm.control.CairngormEvent;
	
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.responders.LoginUserResponder;
	
	import mx.rpc.IResponder;

	public class LoginUserCommand extends RtCommand
	{
		public static var resolveResponder : Function = function() : IResponder
		{
			return new LoginUserResponder();
		}

		private var _username:String;
		private var _password:String;
		public function LoginUserCommand(username:String, password:String)
		{
			super();
			if(username==null||username.length==0)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", LoginUserCommand, username==null||username.length==0"); 
			}
			_username = username;
			if(password==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", LoginUserCommand, password==null"); 
			}
			_password = password;
			responder = resolveResponder();
		}
		
		override public function execute():void
		{
			dispatch(remoteService.authenticateUser(_username, _password));
		}
		
		
		
		
	}
}