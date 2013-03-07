package dk.runtrack.commands.run
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.TrainingPlan;
	import dk.runtrack.responders.GetPlannedRunsResponder;
	
	import mx.rpc.IResponder;
	
	public class GetPlannedRunsCommand extends RtCommand
	{
		public static var resolveResponder : Function = function() : IResponder
		{
			return new GetPlannedRunsResponder();
		}
		
		private var _trainingPlan : TrainingPlan
		public function GetPlannedRunsCommand(trainingPlan : TrainingPlan)
		{
			super();
			if(trainingPlan==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION);
			}
			_trainingPlan = trainingPlan
		}
		
		public override function execute() : void
		{
			responder = resolveResponder();
			dispatch(remoteService.getPlannedRuns(_trainingPlan));
		}
	}
}