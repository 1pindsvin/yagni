package dk.runtrack.presentationmodels.menu
{
	public class MenuItem
	{
		
		private var _label:String;
		private var _groupName:String;
		private var _enabled:Boolean;
		private var _action:*;
		private var _type:String;
		private var _toggled:Boolean;
		
		public function MenuItem(label:String = "")
		{
			_enabled = true;
			_label = label;
		}
		
		public function get action():*
		{
			return _action;
		}
		
		public function set action(value:*):void
		{
			_action = value;
		}
		
		public function get enabled():Boolean
		{
			return _enabled;
		}
		
		public function set enabled(value:Boolean):void
		{
			_enabled = value;
		}
		
		public function get label():String
		{
			return _label;
		}
		
		public function set label(value:String):void
		{
			_label = value;
		}
		
		public function get type():String
		{
			return _type;
		}
		
		public function set type(value:String):void
		{
			_type = value;
		}
		
		public function set groupName(value:String):void
		{
			_groupName = value;
		}
		
		public function get groupName():String
		{
			return _groupName;
		}
		
		public function get toggled():Boolean
		{
			return _toggled;
		}
		
		public function set toggled(value:Boolean):void
		{
			_toggled = value;
		}

	}
}