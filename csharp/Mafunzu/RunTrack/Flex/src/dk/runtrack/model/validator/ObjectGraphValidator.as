package dk.runtrack.model.validator
{
	public class ObjectGraphValidator
	{
		public static const CREATE:String = "CREATE"
		public static const READ:String = "READ"
		public static const UPDATE:String = "UPDATE"
		public static const DESTROY:String = "DESTROY"
		
		private var _instance:Object
		public function ObjectGraphValidator(instance:Object)
		{
			_instance = instance;
		}

		private var _operation:String;

		public function get operation() : String
		{
			return _operation;
		} 

		public function set operation(value:String) : void
		{
			_operation = value;
		} 
		
		
	}
}