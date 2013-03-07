package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.Shoe" )]
	public class Shoe
	{
		public static function isNullShoe(shoe: Shoe) : Boolean
		{
			return shoe.ID == NULL_SHOE_ID;
		}
		
		public static  function filterPersistent(item:Shoe, index:int= 0, array:Array = null) : Boolean
        {    
            return item.ID > 0;
        }

		public static  function filterActive(item:Shoe, index:int= 0, array:Array = null) : Boolean
        {    
            return item.Active;
        }
        
		public static  function compareByBrand(x: Shoe, y:Shoe) : int
        {    
			return x.Brand.toLocaleLowerCase().localeCompare(y.Brand.toLocaleLowerCase());
        }
		
		public static function get nullShoe() : Shoe
		{
			var nullShoe : Shoe = new Shoe();
			nullShoe.Brand = Constants.NULL_ITEM_TEXT;
			nullShoe.ID = NULL_SHOE_ID;
			nullShoe.Active = true;
			return nullShoe;
		}
		
		public static const NULL_SHOE_ID : int = int.MIN_VALUE;
		
		
		public function Shoe()
		{
			_iD = -1;
			_rtVersion = 0;
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
		
		private var _brand:String;
		
		public function get Brand() : String
		{
			return _brand;
		} 
		
		public function set Brand(value:String) : void
		{
			_brand = value;
		}
		
		private var _usage:int;

		public function get Usage() : int
		{
			return _usage;
		} 

		public function set Usage(value:int) : void
		{
			_usage = value;
		} 
				
		private var _durability:int;
		
		public function get Durability() : int
		{
			return _durability;
		} 
		
		public function set Durability(value:int) : void
		{
			_durability = value;
		}
		
		private var _otherUsage:int;

		public function get OtherUsage() : int
		{
			return _otherUsage;
		} 

		public function set OtherUsage(value:int) : void
		{
			_otherUsage = value;
		}

		public function get RestDurability() : int
		{
			return Durability - (Usage + OtherUsage);
		} 


		private var _active:Boolean;

		public function get Active() : Boolean
		{
			return _active;
		} 

		public function set Active(value:Boolean) : void
		{
			_active = value;
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
		
		private var _athlete : dk.runtrack.model.Athlete;
		
		public function get Athlete() : dk.runtrack.model.Athlete
		{
			return _athlete;
		} 
		
		public function set Athlete(value:dk.runtrack.model.Athlete) : void
		{
			_athlete = value;
		}
		
	} 
}