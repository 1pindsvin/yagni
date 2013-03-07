package dk.runtrack.io
{
	import flash.net.SharedObject;
	
	public class CookieAdapter
	{
		public static var cookie : Object;
		
		private static const COOKIE_NAME : String = "RunTrack";
		
		public function CookieAdapter()
		{
			_userName = localCookie.data.userName;
			if(userName==null)
			{
				_userName="";
				_password="";
				_lastSavedShoeID= 0;
				save();
			}
			_password = localCookie.data.password;
			_lastSavedShoeID = localCookie.data.lastSavedShoeID;
		}

		private static function get localCookie() : Object
		{
			if(!cookie)
			{
				cookie = SharedObject.getLocal(COOKIE_NAME);
			}
			return cookie;		
		}

		private var _lastSavedShoeID:int;

		public function get lastSavedShoeID() : int
		{
			return _lastSavedShoeID;
		} 

		public function set lastSavedShoeID(value:int) : void
		{
			if(_lastSavedShoeID==value)
			{
				return;
			}
			_lastSavedShoeID = value;
			save();
		}
		
		private var _userName:String;

		public function get userName() : String
		{
			return _userName;
		} 

		public function set userName(value:String) : void
		{
			if(_userName==value)
			{
				return;
			}
			_userName = value;
			save();
		}

		private var _password:String;

		public function get password() : String
		{
			return _password;
		} 

		public function set password(value:String) : void
		{
			if(_password==value)
			{
				return;
			}
			_password = value;
			save();
		}

		public function save() : void
		{
			localCookie.data.userName = _userName; 
			localCookie.data.password = _password;
			localCookie.data.lastSavedShoeID = _lastSavedShoeID;
			localCookie.flush();
		}

	}
}