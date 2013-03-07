package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Activity;
	import dk.runtrack.presentationmodels.interfaces.IEditActivityPresentationModel;

	public class EditActivityPresentationModel implements IEditActivityPresentationModel
	{
		public function EditActivityPresentationModel()
		{
		}

		private var _foreignSystemID:String;

		public function get foreignSystemID() : String
		{
			return _foreignSystemID;
		}

		public function set foreignSystemID(value:String) : void
		{
			_foreignSystemID = value;
		}

		private var _activityType:int;

		public function get activityType() : int
		{
			return _activityType;
		}

		public function set activityType(value:int) : void
		{
			_activityType = value;
		}

		private var _activitySubType:int;

		public function get activitySubType() : int
		{
			return _activitySubType;
		}

		public function set activitySubType(value:int) : void
		{
			_activitySubType = value;
		}

		private var _name:String;

		public function get name() : String
		{
			return _name;
		}

		public function set name(value:String) : void
		{
			_name = value;
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

		private var _date:Date;

		public function get date() : Date
		{
			return _date;
		}

		public function set date(value:Date) : void
		{
			_date = value;
		}

		private var _totalTime:String;

		public function get totalTime() : String
		{
			return _totalTime;
		}

		public function set totalTime(value:String) : void
		{
			_totalTime = value;
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

		private var _averageHeartRate:int;

		public function get averageHeartRate() : int
		{
			return _averageHeartRate;
		}

		public function set averageHeartRate(value:int) : void
		{
			_averageHeartRate = value;
		}

		private var _maximumHeartRate:int;

		public function get maximumHeartRate() : int
		{
			return _maximumHeartRate;
		}

		public function set maximumHeartRate(value:int) : void
		{
			_maximumHeartRate = value;
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

		private var _experience:int;

		public function get experience() : int
		{
			return _experience;
		}

		public function set experience(value:int) : void
		{
			_experience = value;
		}

		private var _weather:String;

		public function get weather() : String
		{
			return _weather;
		}

		public function set weather(value:String) : void
		{
			_weather = value;
		}

		private var _labels:int;

		public function get labels() : int
		{
			return _labels;
		}

		public function set labels(value:int) : void
		{
			_labels = value;
		}

		private var _lastChanged:Date;

		public function get lastChanged() : Date
		{
			return _lastChanged;
		}

		public function set lastChanged(value:Date) : void
		{
			_lastChanged = value;
		}

		private var _intensity:String;

		public function get intensity() : String
		{
			return _intensity;
		}

		public function set intensity(value:String) : void
		{
			_intensity = value;
		}

		private var _done:Boolean;

		public function get done() : Boolean
		{
			return _done;
		}

		public function set done(value:Boolean) : void
		{
			_done = value;
		}

		private var _comments:String;

		public function get comments() : String
		{
			return _comments;
		}

		public function set comments(value:String) : void
		{
			_comments = value;
		}

		private var _activitySubTypeSelectedIndex:int;

		public function get activitySubTypeSelectedIndex() : int
		{
			return _activitySubTypeSelectedIndex;
		}

		public function set activitySubTypeSelectedIndex(value:int) : void
		{
			_activitySubTypeSelectedIndex = value;
		}

		private var _activityTypeSelectedIndex:int;

		public function get activityTypeSelectedIndex() : int
		{
			return _activityTypeSelectedIndex;
		}

		public function set activityTypeSelectedIndex(value:int) : void
		{
			_activityTypeSelectedIndex = value;
		}

		private var _shoeSelectedIndex:int;

		public function get shoeSelectedIndex() : int
		{
			return _shoeSelectedIndex;
		}

		public function set shoeSelectedIndex(value:int) : void
		{
			_shoeSelectedIndex = value;
		}

		private var _activitySubTypes:Array;

		public function get activitySubTypes() : Array
		{
			return _activitySubTypes;
		}

		public function set activitySubTypes(value:Array) : void
		{
			_activitySubTypes = value;
		}

		private var _shoes:Array;

		public function get shoes() : Array
		{
			return _shoes;
		}

		public function set shoes(value:Array) : void
		{
			_shoes = value;
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

		private var _editActivity:dk.runtrack.model.Activity;

		public function get editActivity() : dk.runtrack.model.Activity
		{
			return _editActivity;
		}

		public function set editActivity(value:dk.runtrack.model.Activity) : void
		{
			_editActivity = value;
		}

		public function save() : void
		{
		}

		public function saveAndGotoLog() : void
		{
		}

	}
}
