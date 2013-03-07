package dk.runtrack.commands.user
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.responders.LoginUserResponder;
	
	import mx.rpc.IResponder;
	
	public class CreateUserWithAthleteCommand extends RtCommand
	{
		private var _emailAsUsername : String;
		private var _password : String;
		
		public static var resolveResponder : Function = function() : IResponder
		{
			return new LoginUserResponder();
		}
		
		public function CreateUserWithAthleteCommand(emailAsUsername : String, password : String)
		{
			super();
			if(!emailAsUsername)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + " emailAsUsername");
			}
			if(!password)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + " password");
			}
			_emailAsUsername = emailAsUsername;
			_password = password;
		}
		
		public override function execute():void
		{
			responder = resolveResponder();
			dispatch(remoteService.createUserWithDefaultAthlete(_emailAsUsername, _password));
		}
	}
}