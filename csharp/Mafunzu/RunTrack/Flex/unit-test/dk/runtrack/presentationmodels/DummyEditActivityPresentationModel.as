package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Activity;
	import dk.runtrack.presentationmodels.interfaces.IEditActivityPresentationModel;
	
	public class DummyEditActivityPresentationModel implements IEditActivityPresentationModel
	{
		public  static var calls : Object = {};

		public function DummyEditActivityPresentationModel()
		{
		}
		
		public function get foreignSystemID():String
		{
			return null;
		}
		
		public function set foreignSystemID(value:String):void
		{
		}
		
		public function get activityType():int
		{
			return 0;
		}
		
		public function set activityType(value:int):void
		{
		}
		
		public function get activitySubType():int
		{
			return 0;
		}
		
		public function set activitySubType(value:int):void
		{
		}
		
		public function get name():String
		{
			return null;
		}
		
		public function set name(value:String):void
		{
		}
		
		public function get description():String
		{
			return null;
		}
		
		public function set description(value:String):void
		{
		}
		
		public function get date():Date
		{
			return null;
		}
		
		public function set date(value:Date):void
		{
		}
		
		public function get totalTime():String
		{
			return null;
		}
		
		public function set totalTime(value:String):void
		{
		}
		
		public function get distance():String
		{
			return null;
		}
		
		public function set distance(value:String):void
		{
		}
		
		public function get averageHeartRate():int
		{
			return 0;
		}
		
		public function set averageHeartRate(value:int):void
		{
		}
		
		public function get maximumHeartRate():int
		{
			return 0;
		}
		
		public function set maximumHeartRate(value:int):void
		{
		}
		
		public function get workload():int
		{
			return 0;
		}
		
		public function set workload(value:int):void
		{
		}
		
		public function get experience():int
		{
			return 0;
		}
		
		public function set experience(value:int):void
		{
		}
		
		public function get weather():String
		{
			return null;
		}
		
		public function set weather(value:String):void
		{
		}
		
		public function get labels():int
		{
			return 0;
		}
		
		public function set labels(value:int):void
		{
		}
		
		public function get lastChanged():Date
		{
			return null;
		}
		
		public function set lastChanged(value:Date):void
		{
		}
		
		public function get intensity():String
		{
			return null;
		}
		
		public function set intensity(value:String):void
		{
		}
		
		public function get done():Boolean
		{
			return false;
		}
		
		public function set done(value:Boolean):void
		{
		}
		
		public function get comments():String
		{
			return null;
		}
		
		public function set comments(value:String):void
		{
		}
		
		public function get activitySubTypeSelectedIndex():int
		{
			return 0;
		}
		
		public function set activitySubTypeSelectedIndex(value:int):void
		{
		}
		
		public function get activityTypeSelectedIndex():int
		{
			return 0;
		}
		
		public function set activityTypeSelectedIndex(value:int):void
		{
		}
		
		public function get shoeSelectedIndex():int
		{
			return 0;
		}
		
		public function set shoeSelectedIndex(value:int):void
		{
		}
		
		public function get activitySubTypes():Array
		{
			return null;
		}
		
		public function set activitySubTypes(value:Array):void
		{
		}
		
		public function get shoes():Array
		{
			return null;
		}
		
		public function set shoes(value:Array):void
		{
		}
		
		public function get state():String
		{
			return null;
		}
		
		public function set state(value:String):void
		{
		}
		
		public function get canSave():Boolean
		{
			return false;
		}
		
		public function set canSave(value:Boolean):void
		{
		}
		
		public function get editActivity():Activity
		{
			return null;
		}
		
		public function set editActivity(value:Activity):void
		{
			calls.editActivity = 1;
		}
		
		public function save():void
		{
		}
		
		public function saveAndGotoLog():void
		{
		}
	}
}