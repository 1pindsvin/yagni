package dk.runtrack.commands.run
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.RunsPage;
	import dk.runtrack.responders.RunPageResponder;
	
	import mx.rpc.IResponder;

	public class GetAthleteRunsCommand extends RtCommand
	{
		public static var resolveAthleteRunsResponder : Function = function() : IResponder
		{
			return new RunPageResponder();
		}

		private var _runsPage: RunsPage
		public function GetAthleteRunsCommand(runsPage: RunsPage)
		{
			super();
			if(runsPage == null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + "GetAthleteRunsCommand, runsPage was null");				
			}
			_runsPage = runsPage;
		}
			
		override public function execute():void
		{
			responder = resolveAthleteRunsResponder();			
			dispatch(remoteService.getRunsPage(_runsPage));
		}
		
	}
}