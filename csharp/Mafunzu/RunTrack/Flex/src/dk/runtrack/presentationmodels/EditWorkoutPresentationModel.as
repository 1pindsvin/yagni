package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Workout;
	import dk.runtrack.presentationmodels.interfaces.IEditWorkoutPresentationModel;

	public class EditWorkoutPresentationModel implements IEditWorkoutPresentationModel
	{
		public function EditWorkoutPresentationModel()
		{
		}
		
		private var _description:String;
		
		public function get description() : String
		{
			return _description;
		}
		
		public function set description(value:String) : void
		{
			_description = value;
		}
		
		private var _type:int;
		
		public function get type() : int
		{
			return _type;
		}
		
		public function set type(value:int) : void
		{
			_type = value;
		}
		
		private var _distance:String;
		
		public function get distance() : String
		{
			return _distance;
		}
		
		public function set distance(value:String) : void
		{
			_distance = value;
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
		
		private var _workoutTypeSelectedIndex:int;
		
		public function get workoutTypeSelectedIndex() : int
		{
			return _workoutTypeSelectedIndex;
		}
		
		public function set workoutTypeSelectedIndex(value:int) : void
		{
			_workoutTypeSelectedIndex = value;
		}
		
		private var _state:String;
		
		public function get state() : String
		{
			return _state;
		}
		
		public function set state(value:String) : void
		{
			_state = value;
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
		
		private var _editWorkout:Workout;
		
		public function get editWorkout() : Workout
		{
			return _editWorkout;
		}
		
		public function set editWorkout(value:Workout) : void
		{
			_editWorkout = value;
		}
		
		public function save() : void
		{
		}

	}
}