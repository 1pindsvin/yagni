package dk.runtrack.commands.shoe
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.util.ExceptionHelper;
	
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	import mx.rpc.Responder;

	public class GetAthleteShoesCommandTester extends TestCase
	{
		public function GetAthleteShoesCommandTester(methodName:String=null)
		{
			GetAthleteShoesCommand.resolveResponder = function() : IResponder
			{
				return new Responder(null,null);
			}
			RtCommand.resolveRemoteService = 
				function () : IRtRemoteService
				{
					return new DummyRemoteService();
				}

			super(methodName);
		}
		
		public function testExecuteShouldCallGetAthleteShoesOnRemoteService() :void
		{
			var getShoesCommand : IRtCommand = new GetAthleteShoesCommand(new Athlete());
			getShoesCommand.execute();
			Assert.assertEquals(1, DummyRemoteService.calls.getAthleteShoes);
		}

		public function testConstructorThrowsExceptionWhenAthleteIsNull() :void
		{
		 	Assert.assertTrue(ExceptionHelper.constructorWithArgumentTrowsException(GetAthleteShoesCommand, null ));
		}
		
	}
}