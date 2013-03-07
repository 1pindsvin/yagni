package dk.runtrack.presentationmodels
{
	import mx.collections.ArrayCollection;
	
	
	/**
	 * 	The application view model is used for keeping track of how the 'main' view shold behave.
	 *  It is the state of this view model that decides what sub-view is currently shown in
	 *  the application.
	 * @author Rasmus
	 * 
	 */
	[Bindable]
	public class ApplicationPresentationModel
	{
		
		public static const STATE_NOT_LOGGED_IN:String = "notLoggedInState";				
		public static const STATE_TRAINING_PERSPECTIVE:String = "trainingPerspective";
		public static const STATE_TRAINING_PLANNING_PERSPECTIVE:String = "trainingPlanningPerspective";		
		
		
		private var _supportedLocales:Array;		
		private var _state:String;		
		private var _menuItems:ArrayCollection;
				
		public var version:String;
		
		public function set state(value:String):void
		{
			_state = value;
		}
		
		public function get state():String
		{
			return _state;
		}
		
		public function set supportedLocales(value:Array):void
		{
			_supportedLocales = value;
		}
		
		public function get supportedLocales():Array
		{
			return _supportedLocales;
		}
		
		/**
		 * Default no-args constructor. 
		 * 
		 */		
		public function ApplicationPresentationModel()
		{
			
		}
		
		
		
		

	}
}