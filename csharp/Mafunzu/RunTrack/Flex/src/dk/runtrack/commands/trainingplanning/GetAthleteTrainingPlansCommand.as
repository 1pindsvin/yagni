package dk.runtrack.commands.trainingplanning
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.responders.GetAthleteTrainingPlansResponder;
	
	import mx.rpc.IResponder;
	
	public class GetAthleteTrainingPlansCommand extends RtCommand
	{
		public static var resolveAthlete : Function = function() : Athlete
		{
			return new PresentationModelLocator().editAthletePresentationModel.currentathlete;	
		}	
		
		public static var resolveResponder : Function = function() : IResponder
		{
			return new GetAthleteTrainingPlansResponder();
		}
			
		private var _athlete : Athlete
		public function GetAthleteTrainingPlansCommand()
		{
			super();
			_athlete = resolveAthlete();
			if(_athlete==null)
			{
				throw new Error(Constants.ARGUMENT_NULL_EXCEPTION + ", _athlete==null GetAthleteTrainingPlansCommand"); 
			}
			responder = resolveResponder();
		}
		
		public override function execute() : void
		{
			dispatch(remoteService.getAthleteTrainingPlans(_athlete));
		}
		
	}
}