package dk.runtrack.view
{
	import dk.runtrack.model.IEditAthleteView;

	public class DummyEditAthleteView implements IEditAthleteView
	{
		
		public static function CreateDefault():DummyEditAthleteView
		{
			var e : DummyEditAthleteView = new DummyEditAthleteView();
			e.SetDefaultTestValues();
			return e;
		}
		
		public function DummyEditAthleteView()
		{
		}
		
		public function SetDefaultTestValues() : void
		{
			var e : DummyEditAthleteView = this;
			e._firstName = "firstName"
			e._dateOfBirth = "01-01-2000";
			e._email = "email";
			e._lastName = "lastName";
			e._password = "password";
		}
		
		private var _firstName : String;
		public function get firstName():String
		{
			return _firstName;
		}
		
		public function set firstName(value:String):void
		{
		}
		
		private var _lastName : String;
		public function get lastName():String
		{
			return _lastName;
		}
		
		public function set lastName(value:String):void
		{
		}
		
		private var _dateOfBirth : String;
		public function get dateOfBirth():String
		{
			return _dateOfBirth;
		}
		
		public function set dateOfBirth(value:String):void
		{
		}

		private var _email : String;
		public function get email():String
		{
			return _email;
		}
		
		public function set email(value:String):void
		{
			
		}
		
		private var _password : String;
		public function get password():String
		{
			return _password;
		}
		
		public function set password(value:String):void
		{
			
		}
		
		public function showValidationErrors(propertyNames:Array, errors:Array):void
		{
			
		}
		
	}
}