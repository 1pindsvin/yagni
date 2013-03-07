package dk.runtrack.model
{
	public class Login
	{
		
		public function Login(email:String, password:String)
		{
			_password= password
			_email = email;			
		}

		private var _email : String;
		public function get email():String
		{
			return _email;
		}
		
		public function set email(value:String):void
		{
			_email = value;
		}
		
		private var _password : String;
		public function get password():String
		{
			return _password;
		}
		
		public function set password(value:String):void
		{
			_password = value;
		}

	}
}