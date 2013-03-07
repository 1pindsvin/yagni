package dk.runtrack.commands.trainingplanning
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.TrainingPlan;
	import dk.runtrack.responders.SaveTrainingPlanResponder;
	
	import mx.rpc.IResponder;
	
	public class SaveTrainingPlanCommand extends RtCommand
	{
		
		public static var resolveResponder : Function = function() : IResponder
		{
			return new SaveTrainingPlanResponder();
		}
		
		public static var resolveAthlete : Function = function() : Athlete
		{
			return new PresentationModelLocator().editAthletePresentationModel.currentathlete;	
		}	
			
		private var _trainingPlan : TrainingPlan;
		public function SaveTrainingPlanCommand(trainingPlan : TrainingPlan)
		{
			super();
			if(trainingPlan==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + ", trainingPlan in SaveTrainingPlanCommand");
			}
			_trainingPlan = trainingPlan;
			_trainingPlan.Athlete = resolveAthlete();			
			responder = resolveResponder();			
		}
		
		public override function execute() : void
		{
			dispatch(remoteService.saveTrainingPlan(_trainingPlan));
		}
	}
}