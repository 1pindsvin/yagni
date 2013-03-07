package dk.runtrack.model
{
	
	[RemoteClass( alias="DataService.Model.Trainer" )]
	public class Trainer
	{
		public function Trainer()
		{
		}
		
		private var _iD:int;
		
		public function get ID() : int
		{
			return _iD;
		}
		
		public function set ID(value:int) : void
		{
			_iD = value;
		}
		
		private var _name:String;
		
		public function get Name() : String
		{
			return _name;
		}
		
		public function set Name(value:String) : void
		{
			_name = value;
		}
		
		private var _description:String;
		
		public function get Description() : String
		{
			return _description;
		}
		
		public function set Description(value:String) : void
		{
			_description = value;
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
		
	}
}