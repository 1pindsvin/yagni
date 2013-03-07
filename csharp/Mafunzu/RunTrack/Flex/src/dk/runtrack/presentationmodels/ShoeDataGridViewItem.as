package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DistanceFormatter;
	import dk.runtrack.model.Shoe;
	
	public class ShoeDataGridViewItem
	{
		private static const TRAILING_DIGITS : uint = 2;
		private static var _distanceFormatter : DistanceFormatter =  new DistanceFormatter();

				
		public function ShoeDataGridViewItem(shoe: Shoe)
		{
			_shoe = shoe;
		}

		private static function intCompare(x : int, y: int) : int
		{
			return x > y ? 1 : x < y ? -1 : 0;
		}

		private static function numberCompare(x : Number, y: Number) : int
		{
			return x > y ? 1 : x < y ? -1 : 0;
		}
		
		public static  function filterChangedItems(item:ShoeDataGridViewItem, index:int= 0, array:Array = null) : Boolean
        {    
            return item.changed;
        }

		public static  function filterActiveItems(item:ShoeDataGridViewItem, index:int= 0, array:Array = null) : Boolean
        {    
            return item.shoe.Active;
        }

		public static  function mapToShoes(item:ShoeDataGridViewItem, index:int= 0, array:Array = null) : Shoe
        {    
            return item.shoe;
        }

		public static  function mapToShoeDataGridItem(item:Shoe, index:int= 0, array:Array = null) : ShoeDataGridViewItem
        {    
            return new ShoeDataGridViewItem(item);
        }
		

		public static function compareDistanceTravelled(x: Object, y:Object) : int
		{
			return intCompare(ShoeDataGridViewItem(x)._shoe.Usage  ,ShoeDataGridViewItem(y)._shoe.Usage);  
		}

		public static function compareDurability(x: Object, y:Object) : int
		{
			return intCompare(ShoeDataGridViewItem(x)._shoe.Durability  ,ShoeDataGridViewItem(y)._shoe.Durability);  
		}

		public static function compareRestDurability(x: Object, y:Object) : int
		{
			return numberCompare
				(
					dogetRestDurabilityPercent(ShoeDataGridViewItem(x)._shoe) ,
					dogetRestDurabilityPercent(ShoeDataGridViewItem(y)._shoe)
				);  
		}

		private static function toPresentationDistance(databaseDistance : int) : String
		{
			var asNumber : Number = _distanceFormatter.fromDatabaseDistance(databaseDistance);
			var numberStr : String = _distanceFormatter.localeFormat(asNumber.toFixed(TRAILING_DIGITS)); 
			return numberStr; 
		}

		private var _shoe : Shoe;
		public function get shoe() : Shoe
		{
			return _shoe;
		}
				
		private var _changed : Boolean;
		public function get changed() : Boolean
		{
			return _changed;	
		}

		public function set changed(v : Boolean) : void
		{
			_changed = v;	
		}

		public function get name() : String
		{
			return _shoe.Brand;
		} 

		public function set name(value:String) : void
		{
			if(value==_shoe.Brand)
			{
				return;
			}
			_shoe.Brand = value;
			_changed= true;
		}

		public function get durability() : String
		{
			return toPresentationDistance( _shoe.Durability);
		} 

 		public function set durability(value:String) : void
		{
			var intval : int = _distanceFormatter.toDatabaseDistance(value);
			if(intval==_shoe.OtherUsage)
			{
				return;				
			}
			_shoe.Durability = intval;
			_changed = true;
		}
 

		public function get otherUsage() : String
		{
			return toPresentationDistance( _shoe.OtherUsage);
		} 

 		public function set otherUsage(value:String) : void
		{
			var intval : int = _distanceFormatter.toDatabaseDistance(value);
			if(intval==_shoe.OtherUsage)
			{
				return;				
			}
			_shoe.OtherUsage = intval;
			_changed = true;
		}
 
		public function get distanceTravelled() : String
		{
			return toPresentationDistance(_shoe.Usage);
		} 

 		public function set distanceTravelled(value:String) : void
		{
			//
		}
		
		private static function dogetRestDurabilityPercent(shoe : Shoe) : Number
		{
			return  (doGetRestDurability(shoe) / shoe.Durability) * 100;
		}
		
		private static function getRestDurabilityPercent(shoe : Shoe) : String
		{
			return _distanceFormatter.localeFormat
				(
					dogetRestDurabilityPercent(shoe).toFixed(TRAILING_DIGITS)
				) + "%";
		 }
			

 		private static function doGetRestDurability(shoe: Shoe) : int
 		{
 			return shoe.Durability - (shoe.Usage + shoe.OtherUsage);
 		}
 		
		public function get restDurability() : String
		{
			return getRestDurabilityPercent(shoe);
		} 

		public function set restDurability(value:String) : void
		{
			//
		}

		public function get active() : Boolean
		{
			return _shoe.Active;
		} 

		public function set active(value:Boolean) : void
		{
			if(value==_shoe.Active)
			{
				return;				
			}
			_shoe.Active = value;
			_changed = true;

		} 
	}
}