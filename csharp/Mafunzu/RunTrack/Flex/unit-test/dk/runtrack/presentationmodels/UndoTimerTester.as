package dk.runtrack.presentationmodels
{
	import flash.events.Event;
	
	import flexunit.framework.TestCase;

	public class UndoTimerTester extends TestCase
	{
		private	var _testTimeOutCommand : DummyCommand;

		public function UndoTimerTester(methodName:String=null)
		{
			super(methodName);
			_testTimeOutCommand =  new DummyCommand();
		}
		
		
		private function assertTimeOutCallback(event:Event, counter:Object) : void
		{
			assertEquals(counter.count, _testTimeOutCommand.executeCallCount);
		}

		public function testWhenTimedOutShouldExecuteCommand() : void
		{
			_testTimeOutCommand.executeCallCount = 0;

			var  e: UndoTimer = new UndoTimer(_testTimeOutCommand, 1);

			_testTimeOutCommand.addEventListener(DummyCommand.EVENT_EXECUTE_CALLED, addAsync(assertTimeOutCallback,5, {count:1}));
				
			e.start();
		}

		
	}
}