package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.Shoe;
	import dk.runtrack.presentationmodels.interfaces.IEditRunPresentationModel;
	
	import mx.collections.ArrayList;
	import mx.collections.IList;
	
	public class DummyRegisterRunViewModel implements IEditRunPresentationModel
	{
		public function DummyRegisterRunViewModel()
		{
		}

		private var _canSave : Boolean;
		
		private var _editRun : Run;

		public function get athleteShoes():IList
		{
			return _athleteShoes;
		}

		public function set athleteShoes(value:IList):void
		{
			_athleteShoes = value;
		}

		public function get canSave():Boolean
		{
			return _canSave;
		}

		public function set canSave(value:Boolean):void
		{
			_canSave = value;
		}

		public function set editRun(run : Run) : void
		{
			_editRun = run;
		}

		private var _athleteShoes : IList;

		private var _state:String;
		public function get state():String
		{
			return _state;
		}
		public function set state(value: String) : void
		{
			_state=value;
		}

		private var _averageSpeed:String;
		public function get averageSpeed() : String
		{
			return _averageSpeed;
		} 

		public function set averageSpeed(value:String) : void
		{
			_averageSpeed = value;
		}

		private var _selectedIndex : int;
		public function get selectedIndex() : int
		{
			return _selectedIndex;			
		}
		
		public function set selectedIndex(v: int) : void
		{
			_selectedIndex = v;	
		}
		
		public function get kilometers():String
		{
			return null;
		}
		
		public function set kilometers(value:String):void
		{
		}
	
		private var _startDate : Date;
		public function get startDate() : Date
		{
			return _startDate;	
		}
		
		public function set startDate(value:Date) : void
		{
			_startDate = value; 
		}
		
		public function setAthleteShoes(v: Array) : void
		{
			v.push(Shoe.nullShoe);
			_athleteShoes = new ArrayList(v);
		}
		
		public function save():void
		{
		}
		
		private var _currentAthlete:Athlete;		
		public function set currentathlete(value:Athlete) : void
		{
		}

		private var _canSaveRun : Boolean;
		public 	function get canSaveRun() : Boolean
		{
			return _canSaveRun;
		}

		public function set canSaveRun(value:Boolean) :void
		{
			_canSaveRun = value;
		}


		public function updateState(suggestedState: String) :void
		{
 /* 			var currentState : String = _state;
			if(currentState==suggestedState)
			{
				return;
			}
			state = suggestedState; */
 		} 

		private var _hour : String;
		public function get hour():String
		{
			return _hour;
		}
		
		public function set hour(value:String):void
		{
			_hour = value;
		}
		
		private var _minute : String;
		public function get minute():String
		{
			return _minute;
		}
		
		public function set minute(value:String):void
		{
			_minute = value;
		}

		private var _second : String;		
		public function get second():String
		{
			return _second;
		}
		
		public function set second(value:String):void
		{
			_second = value;
		}

	}
}