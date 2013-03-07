package dk.runtrack.delegates.athlete
{
	import mx.rpc.IResponder;

	public class DummyResponder implements IResponder
	{
		
		private static var _iD:Number;
		
		public function get ID() : Number
		{
			return _iD;
		} 
		
		public function set ID(value:Number) : void
		{
			_iD = value;
		}

		
		public function DummyResponder()
		{
			_iD++;			
		}

		public function result(data:Object):void
		{
		}
		
		public function fault(info:Object):void
		{
		}
		
	}
}