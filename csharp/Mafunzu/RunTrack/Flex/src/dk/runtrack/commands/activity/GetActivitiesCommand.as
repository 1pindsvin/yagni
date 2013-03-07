package dk.runtrack.commands.activity
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.ActivityQuery;
	import dk.runtrack.model.Constants;
	
	import mx.rpc.IResponder;
	
	public class GetActivitiesCommand extends RtCommand
	{
		public static var resolveResponder : Function = function() : IResponder
		{
			throw new Error(Constants.NOTIMPLEMENTEDEXCEPTION);
		}
		
		private var _activityQuery : ActivityQuery;
		public function GetActivitiesCommand(query:ActivityQuery)
		{
			super();
			if(query==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + ", GetActivitiesCommand(query:ActivityQuery)");
			}
			_activityQuery = query;			
		}
		
		public override function execute():void
		{
			responder = resolveResponder();
			dispatch(remoteService.getActivities(_activityQuery));
		}
	}
}