package dk.runtrack.presentationmodels
{
	import com.adobe.cairngorm.control.CairngormEventDispatcher;
	
	import dk.runtrack.commands.DummyRunTrackCommand;
	import dk.runtrack.events.RunTrackEvent;
	
	import flash.events.IEventDispatcher;
	
	import flexunit.framework.TestCase;

	public class EditShoeViewModelSaveTester extends TestCase
	{

		private var _serviceDispatcher:IEventDispatcher;

		public function EditShoeViewModelSaveTester(methodName:String=null)
		{
			super(methodName);
		}
		
		override public function setUp():void
		{
			super.setUp();
		}
		
		override public function tearDown():void
		{
			super.tearDown();
			
		}
		
		private function runTrackEventHandler(event : RunTrackEvent) : void
		{
			assertNotNull(event.runTrackCommand);
		}
		
		public function testConstructor() : void
		{
			var e : EditShoePresentationModel = new EditShoePresentationModel();
			assertNotNull(e);
		}

		private function whenEventIsNotTriggeredAndItsOKHandler(exstraData: Object) : void
		{
			//OK
		}

		public function testWhenNoShoesShouldNotFireSaveEvent() : void
		{
			var e : EditShoePresentationModel = new EditShoePresentationModel();
			
			CairngormEventDispatcher.getInstance().addEventListener
				(
				RunTrackEvent.EVENT_RUN_TRACK_ACTION, 
				addAsync(runTrackEventHandler,5, null, whenEventIsNotTriggeredAndItsOKHandler)
				)

			e.save();		
		}

		public function testWhenFilterSetShouldFireSaveEvent() : void
		{
			var e : EditShoePresentationModel = new EditShoePresentationModel();

			e.loadedShoes = [];
			
			e.addShoe(); //adds one changed shoe  
			
			e.athleteShoes.filterFunction = function (item:ShoeDataGridViewItem) : Boolean {return false;}
			 			
			CairngormEventDispatcher.getInstance().addEventListener
				(
					RunTrackEvent.EVENT_RUN_TRACK_ACTION, 
					addAsync(runTrackEventHandler,5)
				)

			e.save();		
		}

		public function testWhenOneShoeChangedShouldFireSaveEvent() : void
		{
			var e : EditShoePresentationModel = new EditShoePresentationModel();

			e.loadedShoes = [];
			
			e.addShoe(); //adds one changed shoe  
			 			
			CairngormEventDispatcher.getInstance().addEventListener
				(
					RunTrackEvent.EVENT_RUN_TRACK_ACTION, 
					addAsync(runTrackEventHandler,5)
				)

			e.save();		
		}


		public function testDispatchEvent() : void
		{
			var event : RunTrackEvent = new RunTrackEvent(new DummyRunTrackCommand());
			CairngormEventDispatcher.getInstance().addEventListener(
				RunTrackEvent.EVENT_RUN_TRACK_ACTION, addAsync(runTrackEventHandler,5));
			event.dispatch();
		}

		
	}
}