package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.AthleteHealth;
	import dk.runtrack.model.AthleteHealthQuery;
	import dk.runtrack.presentationmodels.interfaces.IAthleteHealthHistoryPresentationModel;
	
	public class DummyAthleteHealthHistoryPresentationModel implements IAthleteHealthHistoryPresentationModel
	{
		public  static var calls : Object = {};
		
		public function DummyAthleteHealthHistoryPresentationModel()
		{
		}
		
		public function get state():String
		{
			return null;
		}
		
		public function set state(value:String):void
		{
		}
		
		public function get healths():Array
		{
			return null;
		}
		
		public function set healths(value:Array):void
		{
		}
		
		public function get selectedAthleteHealth():AthleteHealth
		{
			return null;
		}
		
		public function set selectedAthleteHealth(value:AthleteHealth):void
		{
		}
		
		public function get showUndo():Boolean
		{
			return false;
		}
		
		public function set showUndo(value:Boolean):void
		{
		}
		
		public function get showNavigatePage():Boolean
		{
			return false;
		}
		
		public function set showNavigatePage(value:Boolean):void
		{
		}
		
		public function undoDelete():void
		{
		}
		
		public function deleteSelected():void
		{
		}
		
		public function sortBy(name:String):void
		{
		}
		
		public function previous():void
		{
		}
		
		public function next():void
		{
		}
		
		public function last():void
		{
		}
		
		public function first():void
		{
		}
		
		public function navigateTo(page:int):void
		{
		}
		
		public function setAthleteHealthQuery(query:AthleteHealthQuery):void
		{
			calls.setAthleteHealthQuery = 1;	
		}
	}
}