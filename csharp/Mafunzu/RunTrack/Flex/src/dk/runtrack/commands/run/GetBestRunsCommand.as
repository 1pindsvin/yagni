package dk.runtrack.commands.run
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.BestRunsQuery;
	import dk.runtrack.responders.GetBestRunsResponder;
	
	import mx.rpc.IResponder;
	
	public class GetBestRunsCommand extends RtCommand
	{
		public static var resolveResponder : Function = function() : IResponder
		{
			return new GetBestRunsResponder();
		}

	
		
		private var _query : BestRunsQuery
		public function GetBestRunsCommand(query : BestRunsQuery)
		{
			super();
			_query = query;
			
			_query.EnsureQueryValid();
			_query.Runs = new Array();
		}

		public override function execute() : void
		{
			responder = resolveResponder();
			dispatch(remoteService.getBestRuns(_query));
		}

	}
}