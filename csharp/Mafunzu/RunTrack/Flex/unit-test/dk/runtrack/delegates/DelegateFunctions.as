package dk.runtrack.delegates
{
	import dk.runtrack.delegates.run.interfaces.IGetAthleteRunsDelegate;

	import dk.runtrack.model.AthleteRunsPage;
	import dk.runtrack.model.Login;
	import dk.runtrack.model.Run;
	
	import mx.rpc.IResponder;
	
	public class DelegateFunctions 
		implements
				IGetAthleteRunsDelegate
	{
		public static var calls : Object= {}; 
		
		public function DelegateFunctions(responder:IResponder)
		{
		}
		

		public function runGetAthleteRunsRemote(page:AthleteRunsPage):void
		{
			calls.runGetAthleteRunsRemote = 1
		}

	}
}