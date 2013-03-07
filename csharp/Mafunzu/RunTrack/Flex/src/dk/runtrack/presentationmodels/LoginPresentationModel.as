package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.User;
	import dk.runtrack.presentationmodels.interfaces.ILoginPresentationModel;

	[Bindable]
	public class LoginPresentationModel implements ILoginPresentationModel
	{
		
		private var _currentUser:User;
		private var _userName:String;
		private var _password:String;
		private var _loginDispatcher:LoginDispatcher;
		
		public static const STATE_INPUT_CREDENTIALS:String = "inputCredentialsState";
		public static const STATE_SEARCH_CREDENTIALS:String = "searchCredentialsState";
		public static const STATE_CREDENTIALS_NOT_FOUND:String = "credentialsNotFoundState";
		public static const STATE_LOGGED_IN:String = "loggedInState";
		public static const STATE_USER_UPDATED:String = "userUpdatedState";
		
		private var _state : String;

		public var statusMessage : String;
		
		public function get state():String
		{
			return _state;
		}

		public function set state(value:String):void
		{
			_state = value;
			if(_state==STATE_CREDENTIALS_NOT_FOUND)
			{
				statusMessage = "login.not.found";
			}
		}

		public function set currentuser(value:User):void
		{
			_currentUser = value;
			username = _currentUser.UserName;
		}
		public function get currentuser():User
		{
			return _currentUser;
		}
		
		public function get username():String
		{
			return _userName;	
		}
		
		public function set username(value:String): void
		{
			_userName = value;
		}
		
		public function set password(value:String):void
		{
			_password = value;
		}
		public function get password():String
		{
			return _password;
		}
		
		public function LoginPresentationModel()
		{
			state = STATE_INPUT_CREDENTIALS;
			statusMessage = "login.ready";
			_loginDispatcher = new LoginDispatcher();			
		}
		
		public function save() : void
		{			
			currentuser.Password = _password;
			_loginDispatcher.saveUser(currentuser);
		}
		
		public function login(): void
		{	
			state = STATE_SEARCH_CREDENTIALS;		
			statusMessage = "processing.login";
			_loginDispatcher.login(_userName, _password);
		}
		
		public function logout():void
		{
			_loginDispatcher.logout();
		}
	}
}