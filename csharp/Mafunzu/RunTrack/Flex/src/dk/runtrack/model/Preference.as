package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.Preference" )]
	public class Preference
	{
		public function Preference()
		{
			_iD = -1;
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

		private var _preferedShoeID:int;

		public function get PreferedShoeID() : int
		{
			return _preferedShoeID;
		} 

		public function set PreferedShoeID(value:int) : void
		{
			_preferedShoeID = value;
		}

		private var _shoe:dk.runtrack.model.Shoe;

		public function get Shoe() : dk.runtrack.model.Shoe
		{
			return _shoe;
		} 

		public function set Shoe(value:dk.runtrack.model.Shoe) : void
		{
			_shoe = value;
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