package dk.runtrack.io
{
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.TypeResolver;
	
	public class PersistentObject
	{
		private var _item: Object;
		private var _class : String;
		private var _id : int;
			
		public function PersistentObject(item: Object)
		{
			_class = TypeResolver.getTypeName(item);
			_id = item.ID;
			if(_id<=0)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", expected ID on persistent item");
			}
			_item = item;
		}
		
		public var deleted : Boolean;
		
		public function get key() : String
		{
			return _class + item.ID;			
		}
		
		public function get item() : Object
		{
			return _item;
		}
		
		public function updateItem(persistentItem: PersistentObject) : void
		{
			if(key!=persistentItem.key)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", different keys");
			}
			_item = persistentItem._item;
		}
	}
}