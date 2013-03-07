package dk.runtrack.commands.athlete
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.responders.SaveAthleteResponder;
	
	import mx.rpc.IResponder;

	public class SaveAthleteCommand extends RtCommand
	{
		public static var resolveResponder : Function =
			function() : IResponder
			{
				return new SaveAthleteResponder();
			}
		
		private var _athlete: Athlete;
		public function SaveAthleteCommand(athlete: Athlete)
		{
			super();
			if(athlete==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", SaveAthleteCommand, athlete was null");
			}
			_athlete = athlete;
			
		}

		public override function execute():void
		{
			responder = resolveResponder();
			dispatch(remoteService.saveAthlete(_athlete));
		}
	}
}