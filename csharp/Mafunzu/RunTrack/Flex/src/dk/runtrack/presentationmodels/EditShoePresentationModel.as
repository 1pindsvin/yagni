package dk.runtrack.presentationmodels
{
	import dk.runtrack.io.PersistentObjectEvent;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.ClientModel;
	import dk.runtrack.model.Shoe;
	import dk.runtrack.model.TypeResolver;
	import dk.runtrack.model.interfaces.IClientModel;
	import dk.runtrack.presentationmodels.interfaces.IEditShoePresentationModel;
	
	import mx.collections.ArrayCollection;
	import mx.logging.ILogger;
	import mx.logging.Log;

	[Bindable]
	public class EditShoePresentationModel implements IEditShoePresentationModel
	{
		private static var _log : ILogger = Log.getLogger(TypeResolver.getTypeName(EditShoePresentationModel));
 
 		public static const STATE_READY:String = "editshoeviewmodel.ready.state";
        public static const STATE_LOADING : String = "editshoeviewmodel.loading.state";      


		public static var getClient : Function = function() : IClientModel
		{
			return ClientModel.data;
		}

		private function get client() : IClientModel
		{
			return getClient();
		}

		public function EditShoePresentationModel()
		{
			_deletedShoes=new Array();
			client.addEventListener(PersistentObjectEvent.EVENT_SHOES_UPDATED, shoesUpdatedHandler);
			_athleteShoes = new ArrayCollection();

			showInActiveShoes = false;
			this.state = STATE_LOADING;
			this.status = STATE_LOADING;
 		}

		
		private function shoesUpdatedHandler(event : PersistentObjectEvent) : void
		{
			loadedShoes = client.shoes;
		}
		
		private var _currentathlete : Athlete;
		public function set currentathlete(value:Athlete):void
		{
			_currentathlete = value;	
		}

		public function set loadedShoes(value:Array) : void
		{
			athleteShoes.list.removeAll();
			athleteShoes.source = value.map(ShoeDataGridViewItem.mapToShoeDataGridItem);
			updateList();
			this.status = STATE_READY;
		} 

		private var _selectedIndex:int;
		public function get selectedIndex() : int
		{
			return _selectedIndex;
		} 

		public function set selectedIndex(value:int) : void
		{
			_selectedIndex = value;
		} 

		private function updateList() : void
		{
			athleteShoes.filterFunction = _showInActiveShoes ? null : ShoeDataGridViewItem.filterActiveItems;
			athleteShoes.refresh();			
		}
		
		private var _athleteShoes:ArrayCollection;
		public function get athleteShoes() : ArrayCollection
		{
			return _athleteShoes;
		} 

		public function set athleteShoes(value:ArrayCollection) : void
		{
			_athleteShoes = value;
		}  
		
		private var _showInActiveShoes:Boolean;
		public function get showInActiveShoes() : Boolean
		{
			return _showInActiveShoes;
		} 

		public function set showInActiveShoes(value:Boolean) : void
		{
			_showInActiveShoes = value;
			updateList();
		} 
		
		public function addShoe() : void
		{
			var shoe : Shoe = new Shoe();
			shoe.Active	= true;
			shoe.Brand = "????"
			shoe.Athlete = _currentathlete;
			shoe.Durability = 1000*1000;
			shoe.OtherUsage = 0;
			shoe.Usage = 0;
			var gridItem : ShoeDataGridViewItem = new ShoeDataGridViewItem(shoe);
			gridItem.changed = true;
			athleteShoes.addItem(gridItem);
			updateList();
		}
		
		private var _deletedShoes : Array;
		public function deleteSelected():void
		{
			if(!canDeleteSelected)
			{
				return;
			}
			var item : ShoeDataGridViewItem = athleteShoes.removeItemAt(_selectedIndex) as ShoeDataGridViewItem;
			_deletedShoes.push(item.shoe);						
		}
		
		public function get canDeleteSelected():Boolean
		{
			var isValidSelection : Boolean = 
				athleteShoes.length > 0 && _selectedIndex>= 0 && _selectedIndex < athleteShoes.length;
			if(!isValidSelection)
			{
				return false;
			}
			var item : ShoeDataGridViewItem = athleteShoes.getItemAt(_selectedIndex) as ShoeDataGridViewItem;
			return item.shoe.Usage==0;			
		}

		private var _state : String;
		public function get state() : String
		{
			return _state;
		}
		
		private function set state(v : String) : void
		{
			_state = v;
		}
		
		private var _status:String;
		public function get status() : String
		{
			return _status;
		} 

		private function set status(value:String) : void
		{
			_status = value;
		} 
		
		public function save():void
		{
			var newOrUpdatedItems : Array = 
				athleteShoes.list.toArray().filter(ShoeDataGridViewItem.filterChangedItems);
			newOrUpdatedItems = newOrUpdatedItems.map(ShoeDataGridViewItem.mapToShoes);	
			client.updateAndDelete(newOrUpdatedItems, _deletedShoes);
			_deletedShoes=new Array();
		}
		
	}
}