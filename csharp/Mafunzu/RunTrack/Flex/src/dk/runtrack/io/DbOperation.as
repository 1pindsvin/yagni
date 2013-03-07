package dk.runtrack.io
{
	public class DbOperation
	{
		public function DbOperation(data: Object)
		{
			_data = data;
		}

		private var _delete:Boolean;

		public function get Delete() : Boolean
		{
			return _delete;
		} 

		public function set Delete(value:Boolean) : void
		{
			_delete = value;
		}

		private var _data:Object;

		public function get Data() : Object
		{
			return _data;
		} 

		public function set Data(value:Object) : void
		{
			_data = value;
		}

    } 
 }