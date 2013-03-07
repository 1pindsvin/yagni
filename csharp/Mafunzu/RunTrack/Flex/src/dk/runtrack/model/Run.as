package dk.runtrack.model
{
	
	[RemoteClass( alias="DataService.Model.Run" )]
	public class Run 
	{
		public function Run()
		{
			_iD = -1;
			_rtVersion = 0;
			_start = new Date();
			_lastChanged = new Date();
		}

		private var _iD:Number;
		public function get ID() : Number
		{
			return _iD;
		} 

		public function set ID(value:Number) : void
		{
			_iD = value;
		}

		private var _time:Number;

		public function get Time() : Number
		{
			return _time;
		} 

		public function set Time(value:Number) : void
		{
			_time = value;
		}

		private var _distance:Number;

		public function get Distance() : Number
		{
			return _distance;
		} 

		public function set Distance(value:Number) : void
		{
			_distance = value;
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

		private var _labels:int;

		public function get Labels() : int
		{
			return _labels;
		} 

		public function set Labels(value:int) : void
		{
			_labels = value;
		}

		private var _lastChanged:Date;
		public function get LastChanged() : Date
		{
			return _lastChanged;
		} 

		public function set LastChanged(value:Date) : void
		{
			_lastChanged = value;
		} 
				
		private var _rtVersion:Number;

		public function get RtVersion() : Number
		{
			return _rtVersion;
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
		
		public function set RtVersion(value:Number) : void
		{
			_rtVersion = value;
		} 

		private var _trainingPlan:dk.runtrack.model.TrainingPlan;
		
		public function get TrainingPlan() : dk.runtrack.model.TrainingPlan
		{
			return _trainingPlan;
		}
		
		public function set TrainingPlan(value:dk.runtrack.model.TrainingPlan) : void
		{
			_trainingPlan = value;
		}
		
		
		private var _athlete:dk.runtrack.model.Athlete;
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