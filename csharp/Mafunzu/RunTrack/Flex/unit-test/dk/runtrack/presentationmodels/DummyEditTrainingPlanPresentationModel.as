package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.TrainingPlan;
	import dk.runtrack.presentationmodels.interfaces.IEditTrainingPlanPresentationModel;
	
	import mx.collections.IList;
	
	public class DummyEditTrainingPlanPresentationModel implements IEditTrainingPlanPresentationModel
	{
		public static var calls : Object= {};
		
		public function DummyEditTrainingPlanPresentationModel()
		{
		}
		
		public function get intensity():int
		{
			return 0;
		}
		
		public function set intensity(value:int):void
		{
		}
		
		public function get skill():int
		{
			return 0;
		}
		
		public function set skill(value:int):void
		{
		}
		
		public function get goalKilometers():String
		{
			return null;
		}
		
		public function set goalKilometers(value:String):void
		{
		}
		
		public function get preferredWeekdays():int
		{
			return 0;
		}
		
		public function set preferredWeekdays(value:int):void
		{
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

		
		public function get trainingPlan():TrainingPlan
		{
			return null;
		}
		
		public function set trainingPlan(value:TrainingPlan):void
		{
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
		
		public function setTrainingPlans(plans:Array):void
		{
			calls.setTrainingPlans = 1;
		}

		public function setRuns(runs:Array) : void
		{
			calls.setRuns = 1;
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
		
		private var _canSave:Boolean;
		
		public function get canSave() : Boolean
		{
			return _canSave;
		}
		
		public function set canSave(value:Boolean) : void
		{
			_canSave = value;
		}

		public function save():void
		{
		}
	}
}