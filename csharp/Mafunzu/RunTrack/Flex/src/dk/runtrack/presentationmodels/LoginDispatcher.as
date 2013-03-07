package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.commands.user.LoginUserCommand;
	import dk.runtrack.commands.user.LogoutUserCommand;
	import dk.runtrack.commands.user.SaveUserCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.User;

	public class LoginDispatcher
	{
		public function LoginDispatcher()
		{
			
		}

		public function logout() : Boolean
		{
			return dispatch(new LogoutUserCommand());
		}
		
		public function login(username:String, password:String): Boolean
		{
			return dispatch(new LoginUserCommand(username, password));
		}
		
		public function saveUser(user:User) : Boolean
		{
			 return dispatch(new SaveUserCommand(user));
		}
		
		private function dispatch(command:IRtCommand) : Boolean
		{
			return new RunTrackEvent(command).dispatch();
		}
	}
}