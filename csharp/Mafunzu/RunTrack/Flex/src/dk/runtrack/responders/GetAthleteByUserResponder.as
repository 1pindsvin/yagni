package dk.runtrack.responders
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.commands.shoe.GetAthleteShoesCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.User;
	import dk.runtrack.presentationmodels.RunActivityPresentationModel;
	
	import mx.rpc.events.ResultEvent;
	
	public class GetAthleteByUserResponder extends BaseResponder
	{
		private var _user : User;
		public function GetAthleteByUserResponder(user: User)
		{
			super();
			_user = user;
		}
		
		
		private function dispatchGetAthleteShoesEvent(athlete : Athlete) : void
		{
			var command : IRtCommand = new GetAthleteShoesCommand(athlete);
			new	RunTrackEvent(command).dispatch();
		}

		protected override function updatePresentationModel(resultEvent:ResultEvent):void
		{
			var athlete : Athlete = resultEvent.result as Athlete;
			if(athlete==null)
			{
				throw new Error("Athlete not found");
			}
			dispatchGetAthleteShoesEvent(athlete);
			presentationModelLocator.currentathlete = athlete;
			presentationModelLocator.runActivityPresentationModel.updateState(RunActivityPresentationModel.STATE_ATHLETE_CHANGED);
		}
	}
}