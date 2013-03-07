package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.User;

	[Bindable]
	public interface ILoginPresentationModel 
	{
		function get state():String;
		function set state(value: String) : void;

		function get statusMessage():String;
		function set statusMessage(value: String) : void;
		
		function get currentuser():User
		function set currentuser(value:User):void;
		
		function get username():String
		function set username(value:String): void;
		
		function set password(value:String):void;
		function get password():String

		function save() : void;
		function login(): void;
		function logout():void;
	}
}