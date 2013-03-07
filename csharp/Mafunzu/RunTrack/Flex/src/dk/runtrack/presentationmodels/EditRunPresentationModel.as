package dk.runtrack.presentationmodels
{
	import dk.runtrack.Factory;
	import dk.runtrack.commands.StatusMessageCommand;
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.commands.run.SaveRunCommand;
	import dk.runtrack.commands.shoe.GetAthleteShoesCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.io.CookieAdapter;
	import dk.runtrack.io.PersistentObjectEvent;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.DateTimeFormatter;
	import dk.runtrack.model.DistanceFormatter;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.Shoe;
	import dk.runtrack.model.TimeFormatter;
	import dk.runtrack.model.interfaces.IClientModel;
	import dk.runtrack.model.validator.ObjectGraphValidator;
	import dk.runtrack.model.validator.RunGraphValidator;
	import dk.runtrack.presentationmodels.interfaces.IEditRunPresentationModel;
	
	import mx.collections.ArrayList;
	import mx.collections.IList;
	
	
	[Bindable]
	public class EditRunPresentationModel implements IEditRunPresentationModel
	{
		public static const STATE_READY : String 						= "ready.state";
		public static const STATE_CAN_SAVE_RUN : String 				= "can.save.run.state";
		public static const STATE_TRY_SAVE_RUN : String 				= "try.save.run.state";
		public static const STATE_TRY_SAVE_EXISTING_RUN : String 		= "try.save.existing.run.state";
		public static const STATE_RUN_SAVED : String 					= "run.saved.state";
		public static const STATE_LOADING : String 						= "loading.state";
		
		private var _timeFormatter : TimeFormatter;
		private var _validatorFactory : ValidatorFactory;
	

		public static var getClient : Function = Factory.getClient;

		public var canSave : Boolean;
		
		private function get client() : IClientModel
		{
			return getClient();
		}	

		private function shoesUpdatedHandler(event : PersistentObjectEvent) : void
		{
			setAthleteShoes(client.shoes);
		}
		
		private function runDeletedEventHandler(event : PersistentObjectEvent) : void
		{
			var runID : int = event.runID;
			var isEditingPersistentRun : Boolean = _editRun && _editRun.ID > 0
			if(!isEditingPersistentRun)
			{
				return;
			}
			if(_editRun.ID!=runID)
			{
				return;
			}
			startDate = new Date();
			state = STATE_LOADING;
			dispatchGetAthleteShoesEvent(_currentAthlete);
		}
		
		public function EditRunPresentationModel()
		{
			client.addEventListener(PersistentObjectEvent.EVENT_SHOES_UPDATED, shoesUpdatedHandler);
			client.addEventListener(PersistentObjectEvent.EVENT_RUN_DELETED, runDeletedEventHandler);
			
			doSetAthleteShoes( new Array());
			this.state = STATE_LOADING;
			_editRun = null;
			_startDate = new Date();
			_validatorFactory = new ValidatorFactory();
			_timeFormatter = new TimeFormatter();
		}

		private var _editRun : Run;
		public function set editRun(run : Run) : void
		{
			var gridViewItem : RunDataGridViewItem  = new RunDataGridViewItem(run);
			this.setTime(run.Time);
			this.kilometers = gridViewItem.distance;
			
			this.startDate = run.Start;
			
			
			if(this._currentAthlete.ID != run.Athlete.ID)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
			}
			run.Athlete=this._currentAthlete;
			_editRun = run;
			resolveSelectedIndex(run.Shoe);
			resolveStateFromViewDataChanges();
		}

		private static const NULL_SHOE_INDEX : int = 0;

		private function resolveSelectedIndex(shoe: Shoe) : void
		{
			invalidateSelectedIndex();
			if(shoe==null)
			{
				return;
			}
			if(!shoe.Active)
			{
				return;
			}
			for (var idx : int = 0; idx < _athleteShoes.length; idx++)
			{
				var currentShoe : Shoe = _athleteShoes.getItemAt(idx) as Shoe;
				if(currentShoe.ID==shoe.ID)
				{
					selectedIndex = idx;
					return;
				}
			}
			throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
		}
		
		private var _state:String;
		public function get state():String
		{
			return _state;
		}

		private function set state(value: String) : void
		{
			_state=value;
			dispatchDisplayStatusEventIfNeeded(_state);
		}

		private function dispatchDisplayStatusEventIfNeeded(statusState : String) : void
		{
			var stateShouldBeIndicatedByUIEnabledState : Boolean = 
				statusState==STATE_CAN_SAVE_RUN || 
				statusState == STATE_LOADING || 
				statusState == STATE_READY
			if(stateShouldBeIndicatedByUIEnabledState)
			{
				return;
			}
			var statusCommand : StatusMessageCommand = new StatusMessageCommand(this)
			new RunTrackEvent(statusCommand).dispatch();
		}

		public function updateState(suggestedState: String) :void
		{
			var currentState : String = _state;
			
			//message from backend, and should not be a state?
			if(suggestedState==STATE_RUN_SAVED)
			{
				state = STATE_LOADING;
				dispatchGetAthleteShoesEvent(_currentAthlete);
				return;
			}

			if(currentState==suggestedState)
			{
				return;
			}
			state = suggestedState;
		} 


		public function get averageSpeed() : String
		{
			if(!kilometers)
			{
				return "";
			}
			if(!time)
			{
				return "";
			}
			var timeFormatter : TimeFormatter = _timeFormatter;
			var distanceFormatter : DistanceFormatter = new DistanceFormatter();

			var run : Run = new Run();
			run.Time  = timeFormatter.toDatabaseTime(time);
			if(run.Time==0)
			{
				return "";
			}
			run.Distance = distanceFormatter.toDatabaseDistance(kilometers);

			var gridItem : RunDataGridViewItem = new RunDataGridViewItem(run);
			return gridItem.averageSpeed; 
		} 

		
		public function set averageSpeed(value:String) : void
		{
			//dummy;
		}

		private function setTime(dbTime : uint) : void
		{
			var timeElements : Array = 
				TimeFormatter.getTimeElements( _timeFormatter.fromDatabaseTime(dbTime));
			hour = timeElements[0];
			minute = timeElements[1];
			second = timeElements[2];
		}

		private function asUint(timeElement : String) : uint
		{
			return TimeFormatter.isUint(timeElement) ? TimeFormatter.parseUint(timeElement) : 0;
		}
				
		private function get time() : String
		{
			return 	_timeFormatter.toTimeString
				(
					asUint(hour),
					asUint(minute), 
					asUint(second)
				);    			
		} 
		
		private var _kilometers:String;
		public function get kilometers() : String
		{
			return _kilometers;
		} 

		public function set kilometers(value:String) : void
		{
			_kilometers = value;
			resolveStateFromViewDataChanges();
		}


		private var _startDate : Date;
		public function get startDate() : Date
		{
			return _startDate;	
		}
		
		public function set startDate(value:Date) : void
		{
			_startDate = value; 
			if(_editRun)
			{
				_editRun=null;
			}
			resolveStateFromViewDataChanges();
		}

		private var _currentAthlete:Athlete;		
		public function set currentathlete(value:Athlete) : void
		{
			if(value.ID < 1)
			{
				throw new Error(Constants.ATHLETE_NOT_SAVED); 
			}
			_currentAthlete = value;
		}
			
		private function resolveRun() : Run
		{
			if(_editRun && _editRun.ID > 0)
			{
				return _editRun;
			}
			return new Run();
		}	
			
		private function buildRun() : Run
		{
			var timeFormatter : TimeFormatter = _timeFormatter;
			var distanceFormatter : DistanceFormatter = new DistanceFormatter();
			
			var run : Run = resolveRun();
			
			run.Time  = timeFormatter.toDatabaseTime(time);
			run.Distance = distanceFormatter.toDatabaseDistance(_kilometers);
			
			var isExistingRunAssumesDateNotChanged : Boolean = run.ID > 0;
			if(isExistingRunAssumesDateNotChanged)
			{
			}
			else
			{
				run.Start = _startDate;
			}
			
			run.Athlete = _currentAthlete;
			
			run.Shoe = Shoe(_athleteShoes.getItemAt(selectedIndex)).ID != Shoe.NULL_SHOE_ID ? Shoe( _athleteShoes.getItemAt(selectedIndex)) : null; 

			var runGraphValidator : RunGraphValidator= new RunGraphValidator(run);
			runGraphValidator.operation = ObjectGraphValidator.CREATE;
			runGraphValidator.Validate(); 

			return run;
		}
		
		private function resolveStateFromViewDataChanges() : void
		{
			var rundataValidator : RunDataValidator = _validatorFactory.createRunDataValidator();
			rundataValidator.kilometers = kilometers;
			rundataValidator.time = time;
			rundataValidator.startDate = new DateTimeFormatter().toDateTimeString(startDate);
			this.averageSpeed = "gryffe"; //force databinding
			if(rundataValidator.isDataValid())
			{
				state = STATE_CAN_SAVE_RUN;	
				
			}
			else
			{
				state = STATE_READY; 	
			}
			canSave = state==STATE_CAN_SAVE_RUN;
		}

		public function save() : void
		{
			if(_currentAthlete==null)
			{
				throw new Error(Constants.ATHLETE_NOT_SET);
			}
						
			var run : Run = buildRun();

			var isPersistentRun : Boolean = run.ID > 0;

			this.state = isPersistentRun ? STATE_TRY_SAVE_EXISTING_RUN : STATE_TRY_SAVE_RUN;

			dispatchSaveRunEvent(run);
		}

		private function dispatchSaveRunEvent(run:Run) : void
		{
			var saveRunCommand : IRtCommand = new SaveRunCommand(run);
			new RunTrackEvent(saveRunCommand).dispatch();
		}
		
		private function dispatchGetAthleteShoesEvent(athlete: Athlete) : void
		{
			var command : IRtCommand = new GetAthleteShoesCommand(_currentAthlete);
			new	RunTrackEvent(command).dispatch();
		}

		private var _hour : String;
		public function get hour():String
		{
			return _hour;
		}
		
		public function set hour(value:String):void
		{
			_hour = value;
			resolveStateFromViewDataChanges();
		}
		
		private var _minute : String;
		public function get minute():String
		{
			return _minute;
		}
		
		public function set minute(value:String):void
		{
			_minute = value;
			resolveStateFromViewDataChanges();
		}

		private var _second : String;		
		public function get second():String
		{
			return _second;
		}
		
		public function set second(value:String):void
		{
			_second = value;
			resolveStateFromViewDataChanges();
		}


		private var _athleteShoes : IList;
		public function get athleteShoes() : IList
		{
			return _athleteShoes;
		}

		private function doSetAthleteShoes(v: Array) : void
		{
			var activeShoes : Array = v.filter(Shoe.filterActive);
			activeShoes.push(Shoe.nullShoe);
			activeShoes.sort(Shoe.compareByBrand);
			
			var shoeList : ArrayList = new ArrayList(activeShoes);
			athleteShoes = shoeList;
		}

		private function theCurrentAthleteHasPreferredShoe() : Boolean
		{
			return new CookieAdapter().lastSavedShoeID > 0;
		}
		
		public function findPreferedShoe() : Shoe
		{
			var shoeID : int = new CookieAdapter().lastSavedShoeID;
			for each(var shoe : Shoe in _athleteShoes.toArray())
			{
				if(shoe.ID!=shoeID)
				{
					continue;
				}
				if(!shoe.Active)
				{
					new CookieAdapter().lastSavedShoeID = 0;
					return null;
				}
				return shoe;
			}
			return null;
		}
	
		public function containsShoe(searchShoe:Shoe) : Boolean
		{
			for each(var shoe : Shoe in athleteShoes.toArray())
			{
				if(shoe.ID == searchShoe.ID)
				{
					return true;
				}
			}
			return false;
		}
	
		public function setAthleteShoes(v: Array) : void
		{
			var currentShoe : Shoe = Shoe(_athleteShoes.getItemAt(selectedIndex));
			
			doSetAthleteShoes(v);

			if(!containsShoe(currentShoe)|| Shoe.isNullShoe(currentShoe))
			{
				var shoe : Shoe = findPreferedShoe();
				currentShoe = shoe ? shoe : Shoe.nullShoe;
			}
			resolveSelectedIndex(currentShoe);
			resolveStateFromViewDataChanges();			
		}

		public function set athleteShoes(v: IList) : void
		{
			_athleteShoes = v;
		}

		private function invalidateSelectedIndex() : void
		{
			selectedIndex = NULL_SHOE_INDEX;
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

    } 
    
}