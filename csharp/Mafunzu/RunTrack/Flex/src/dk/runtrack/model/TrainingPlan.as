package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.TrainingPlan" )]
	public class TrainingPlan
	{
		public static const NULL_TRAINING_PLAN_ID : int = int.MIN_VALUE;

		public static function isNullTrainingPlan(trainingPlan: TrainingPlan) : Boolean
		{
			return trainingPlan.ID == NULL_TRAINING_PLAN_ID;
		}

		
		public static function get nullTrainingPlan() : TrainingPlan
		{
			var nullPlan : TrainingPlan = new TrainingPlan();
			nullPlan.ID = NULL_TRAINING_PLAN_ID;
			return nullPlan;
		}

		public static  function compareByID(x: TrainingPlan, y:TrainingPlan) : int
		{    
			return  x.ID > y.ID ? 1 : y.ID > x.ID ? -1 : 0;
		}

		
		public function TrainingPlan()
		{
			_iD=-1;
			_start  = new Date();
			_goal = new dk.runtrack.model.Goal();
			_goal.TrainingPlans = this;
			_workload = 50;
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
		
		private var _intensity:int;
		
		public function get Intensity() : int
		{
			return _intensity;
		} 
		
		public function set Intensity(value:int) : void
		{
			_intensity = value;
		}
		
		private var _skill:int;
		
		public function get Skill() : int
		{
			return _skill;
		} 
		
		public function set Skill(value:int) : void
		{
			_skill = value;
		}

		private var _workload:int;
		
		public function get Workload() : int
		{
			return _workload;
		}
		
		public function set Workload(value:int) : void
		{
			_workload = value;
		}
		
		private var _start:Date;
		
		public function get Start() : Date
		{
			return _start;
		}
		
		public function set Start(value:Date) : void
		{
			_start = value;
		}
		
		private var _startDistance:int;
		
		public function get StartDistance() : int
		{
			return _startDistance;
		}
		
		public function set StartDistance(value:int) : void
		{
			_startDistance = value;
		}
		
		
		private var _preferredWeekdays:int;
		
		public function get PreferredWeekdays() : int
		{
			return _preferredWeekdays;
		} 
		
		public function set PreferredWeekdays(value:int) : void
		{
			_preferredWeekdays = value;
		}
		
		private var _athlete:dk.runtrack.model.Athlete;
		
		public function get Athlete() : dk.runtrack.model.Athlete
		{
			return _athlete;
		} 
		
		public function set Athlete(value:dk.runtrack.model.Athlete) : void
		{
			_athlete = value;
			_goal.Athlete = _athlete;
		}
		
		private var _goal:dk.runtrack.model.Goal;
		
		public function get Goal() : dk.runtrack.model.Goal
		{
			return _goal;
		} 
		
		public function set Goal(value:dk.runtrack.model.Goal) : void
		{
			_goal = value;
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