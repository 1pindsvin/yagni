package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Athlete;
	import dk.runtrack.presentationmodels.interfaces.IEditShoePresentationModel;
	
	import mx.collections.ArrayCollection;

	public class DummyEditShoeViewModel implements IEditShoePresentationModel
	{
		public function DummyEditShoeViewModel()
		{
		}

		private var _currentathlete : Athlete;
		public function set currentathlete(value:Athlete):void
		{
			_currentathlete = value;	
		}

		
		private var _loadedShoes:Array;
 
		public function set loadedShoes(value:Array) : void
		{
			_loadedShoes = value;
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


		public function get athleteShoes():ArrayCollection
		{
			return null;
		}
		
		public function set athleteShoes(v:ArrayCollection):void
		{
		}
		

		private var _showActiveShoes:Boolean;
		public function get showInActiveShoes() : Boolean
		{
			return _showActiveShoes;
		} 

		public function set showInActiveShoes(value:Boolean) : void
		{
			_showActiveShoes = value;
		} 

		public function addShoe() : void
		{
			
		}

		private var _state : String;
		public function get state() : String
		{
			return _state;
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

		}
		
		public function deleteSelected():void
		{
		}
		
		public function get canDeleteSelected():Boolean
		{
			return false;
		}
		
	}
}