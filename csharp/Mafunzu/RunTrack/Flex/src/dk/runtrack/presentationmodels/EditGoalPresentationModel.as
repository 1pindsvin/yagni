package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Goal;
	import dk.runtrack.presentationmodels.interfaces.IEditGoalPresentationModel;

	[Bindable]
	public class EditGoalPresentationModel implements IEditGoalPresentationModel
	{
		public function EditGoalPresentationModel()
		{
			_goal = new Goal();
		}
		
		public var hour:String
		
		public var minute:String

		public var second:String

		public var kilometers:String

		private var _goal : Goal;
		public function set goal(value:Goal) : void
		{
			_goal = value;	
		}

	}
}