package dk.runtrack.commands
{
	import dk.runtrack.controller.DummyRemoteService;
	
	import flexunit.framework.Assert;
	
	import mx.rpc.AsyncToken;
	
	public class OnTrackCommandDispatchTester extends OntrackCommandTester
	{
		public function OnTrackCommandDispatchTester(methodName:String=null)
		{
			super(methodName);
		}
		
		public function testDispatchShouldSetResponder() : void
		{
			var e : DummyDispatchCommand = new DummyDispatchCommand();
			DummyRemoteService.registeredAsyncTokens.splice(0);
			e.execute(null);
			Assert.assertNotNull(e.responder);
			Assert.assertEquals(1, AsyncToken(DummyRemoteService.registeredAsyncTokens[0]).responders.length);
		}
		
	}
}