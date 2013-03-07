package dk.runtrack.commands.athlete
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.AthleteHealthQuery;
	import dk.runtrack.model.Constants;
	import dk.runtrack.responders.GetHealthHistoryResponder;
	
	import mx.rpc.IResponder;
	
	public class GetHealthHistoryCommand extends RtCommand
	{
		public static var resolveResponder : Function = function() : IResponder
		{
			return new GetHealthHistoryResponder(); 
		}
		
		private var _query : AthleteHealthQuery;
		public function GetHealthHistoryCommand(query : AthleteHealthQuery)
		{
			super();
			if(query==null||query.Athlete==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", query==null||query.Athlete==null in GetHealthHistoryCommand");  
			}
			_query = query;
		}
		
		public override function execute() : void
		{
			responder = resolveResponder();
			dispatch(remoteService.getHealthHistory(_query));
		}

	}
}