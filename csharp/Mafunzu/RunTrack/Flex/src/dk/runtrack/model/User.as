package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.User" )]
	public class User
	{
		
		public function User()
		{
		}

		private var _rtVersion:Number;

		public function get RtVersion() : Number
		{
			return _rtVersion;
		} 

		public function set RtVersion(value:Number) : void
		{
			_rtVersion = value;
		}

		private var _iD:Number;

		public function get ID() : Number
		{
			return _iD;
		} 

		public function set ID(value:Number) : void
		{
			_iD = value;
		}

		private var _userName:String;

		public function get UserName() : String
		{
			return _userName;
		} 

		public function set UserName(value:String) : void
		{
			_userName = value;
		}

		private var _password:String;

		public function get Password() : String
		{
			return _password;
		} 

		public function set Password(value:String) : void
		{
			_password = value;
		}

		private var _roles:String;

		public function get Roles() : String
		{
			return _roles;
		} 

		public function set Roles(value:String) : void
		{
			_roles = value;
		}

//		private 
//		public function get IsAuthenticated : Boolean
//		{
//			
//		}
    } 
 }