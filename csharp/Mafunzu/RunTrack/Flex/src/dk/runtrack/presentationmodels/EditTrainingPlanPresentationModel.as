package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.run.GetPlannedRunsCommand;
	import dk.runtrack.commands.trainingplanning.GetAthleteTrainingPlansCommand;
	import dk.runtrack.commands.trainingplanning.SaveTrainingPlanCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.DistanceFormatter;
	import dk.runtrack.model.TrainingPlan;
	import dk.runtrack.presentationmodels.interfaces.IEditTrainingPlanPresentationModel;
	
	import mx.collections.ArrayList;
	import mx.collections.IList;
	
	[Bindable]
	public class EditTrainingPlanPresentationModel implements IEditTrainingPlanPresentationModel
	{
		public function EditTrainingPlanPresentationModel()
		{
			_trainingPlan = new TrainingPlan();
			setTrainingPlans(new Array());
			canSave = false;
		}
		
		private var _intensity:int;
		
		public function get intensity() : int
		{
			return _intensity;
		} 
		
		public function set intensity(value:int) : void
		{
			_intensity = value;
		}
		
		private var _skill:int;
		public function get skill() : int
		{
			return _skill;
		} 
		
		public function set skill(value:int) : void
		{
			_skill = value;
		}
		
		private var _goalKilometers:String;
		
		public function get goalKilometers() : String
		{
			return _goalKilometers;
		} 
		
		public function set goalKilometers(value:String) : void
		{
			_goalKilometers = value;
		}
		
		private var _preferredWeekdays:int;
		
		public function get preferredWeekdays() : int
		{
			return _preferredWeekdays;
		} 
		
		public function set preferredWeekdays(value:int) : void
		{
			_preferredWeekdays = value;
		}
		
		private var _start:Date;
		
		public function get start() : Date
		{
			return _start;
		}
		
		public function set start(value:Date) : void
		{
			_start = value;
		}
		
		private var _workload:int;
		
		public function get workload() : int
		{
			return _workload;
		}
		
		public function set workload(value:int) : void
		{
			_workload = value;
		}
		
		private var _startDistance:String;
		
		public function get startDistance() : String
		{
			return _startDistance;
		}
		
		public function set startDistance(value:String) : void
		{
			_startDistance = value;
		}
		
		private function invalidateSelectedIndex() : void
		{
			selectedIndex = Constants.NULL_ITEM_INDEX;
		}
		
		private var _selectedIndex:int;
		public function get selectedIndex() : int
		{
			return _selectedIndex;
		}
		
		public function set selectedIndex(value:int) : void
		{
			_selectedIndex = value;
			_trainingPlan = _trainingPlans.getItemAt(_selectedIndex) as TrainingPlan;
			updateViewData();
		}
		
		private var _canSave:Boolean;
		public function get canSave() : Boolean
		{
			return _canSave;
		}
		
		public function set canSave(value:Boolean) : void
		{
			_canSave = value;
		}
		
		private var _trainingPlan:TrainingPlan;
		
		public function get trainingPlan() : TrainingPlan
		{
			return _trainingPlan;
		} 
		
		public function set trainingPlan(value:TrainingPlan) : void
		{
			_trainingPlan = value;
			updateViewData();
		} 
		
		private var _trainingPlans:IList;
		public function get trainingPlans() : IList
		{
			return _trainingPlans;
		} 
		
		public function set trainingPlans(value:IList) : void
		{
			_trainingPlans = value;
		} 	
		
		public function setTrainingPlans(plans:Array) : void
		{
			plans.push(TrainingPlan.nullTrainingPlan);
			plans.sort(TrainingPlan.compareByID);
			trainingPlans = new ArrayList(plans);
			var isCurrentSelectedPlanPersistent : Boolean = trainingPlan.ID>0; 
			if(!isCurrentSelectedPlanPersistent)
			{
				trainingPlan = plans[plans.length-1];
			}
			resolveSelectedIndex(trainingPlan);
			
		}
		
		public function setRuns(runs:Array) : void
		{
		}
		
		private function resolveSelectedIndex(trainingPlan : TrainingPlan) : void
		{
			if(trainingPlan==null)
			{
				return;
			}
			invalidateSelectedIndex();
			for (var idx : int = 0; idx < _trainingPlans.length; idx++)
			{
				var currenttrainingPlan : TrainingPlan = _trainingPlans.getItemAt(idx) as TrainingPlan;
				if(currenttrainingPlan.ID== trainingPlan.ID)
				{
					selectedIndex = idx;
					return;
				}
			}
			throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
		}
		
		private function updateViewData() : void
		{
			var distanceFormatter : DistanceFormatter =  new DistanceFormatter();
			goalKilometers = 
				distanceFormatter.toLocaleText( distanceFormatter.fromDatabaseDistance(_trainingPlan.Goal.Distance));
			intensity = _trainingPlan.Intensity;
			skill = trainingPlan.Skill;
			workload = trainingPlan.Workload;
			start = trainingPlan.Start;
			startDistance = distanceFormatter.toLocaleText( distanceFormatter.fromDatabaseDistance(_trainingPlan.StartDistance));
			preferredWeekdays = trainingPlan.PreferredWeekdays;
			if(trainingPlan.ID<=0)
			{
				return;
			}
			var runsCommand : GetPlannedRunsCommand = new GetPlannedRunsCommand(_trainingPlan);
			new RunTrackEvent(runsCommand).dispatch();
		}
		
		private function dispatchTrainingPlanEvents() : void
		{
			var command : SaveTrainingPlanCommand = new SaveTrainingPlanCommand(_trainingPlan);
			var runTrackEvent : RunTrackEvent = new RunTrackEvent(command);
			runTrackEvent.dispatch();
			
			var plansCommand : GetAthleteTrainingPlansCommand = new GetAthleteTrainingPlansCommand();
			new RunTrackEvent(plansCommand).dispatch();
			
		}
		
		public function save(): void
		{
			var distanceFormatter : DistanceFormatter =  new DistanceFormatter();
			_trainingPlan.Goal.Distance = distanceFormatter.toDatabaseDistance(goalKilometers);
			_trainingPlan.StartDistance = distanceFormatter.toDatabaseDistance(startDistance);
			_trainingPlan.Workload = workload;
			_trainingPlan.Intensity = this.intensity;
			_trainingPlan.Skill = this.skill;
			_trainingPlan.PreferredWeekdays = preferredWeekdays;
			_trainingPlan.Start = start;
			dispatchTrainingPlanEvents();			
		}
	}
}