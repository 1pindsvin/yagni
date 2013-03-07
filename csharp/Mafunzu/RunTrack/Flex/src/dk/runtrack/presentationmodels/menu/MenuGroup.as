package dk.runtrack.presentationmodels.menu
{
	public class MenuGroup extends MenuItem
	{
		
		private var _children:Array;
		
		public function MenuGroup(label:String = "")
		{
			super(label);
			_children = new Array();
		}
		
		public function addChild(value:MenuItem):void
		{
			_children.push(value);
		}
		
		public function get children():Array
		{
			return _children;
		}
		
	}
}