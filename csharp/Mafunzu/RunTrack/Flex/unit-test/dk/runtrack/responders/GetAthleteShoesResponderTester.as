package dk.runtrack.responders
{
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.model.DummyClient;
	import dk.runtrack.model.interfaces.IClientModel;
	
	import flexunit.framework.TestCase;
	
	import mx.rpc.events.ResultEvent;
	
	public class GetAthleteShoesResponderTester extends TestCase
	{
		
		public function GetAthleteShoesResponderTester(methodName:String=null)
		{
			super(methodName);
			GetAthleteShoesResponder.getClient = function() : IClientModel
			{
				return new DummyClient();
			}
		}
		
		override public function setUp():void
		{
			super.setUp();
		}
		
		override public function tearDown():void
		{
			super.tearDown();
		}
		
		public function testContructorExpectsNotNull():void
		{
			var e : GetAthleteShoesResponder = new GetAthleteShoesResponder();
			assertNotNull(e);
		}
		
		
		public function testResultShouldUpdateClient() : void
		{
			
			var e : GetAthleteShoesResponder = new GetAthleteShoesResponder();
			DummyClient.calls.loadedShoes = 0;			

			var resultArray : Array = new Array();
			var eventFromServer : ResultEvent = ResultEventBuilder.build(resultArray);
			
			e.result(eventFromServer);
			
			assertEquals(1,  DummyClient.calls.loadedShoes);			
		}
		
	}
}