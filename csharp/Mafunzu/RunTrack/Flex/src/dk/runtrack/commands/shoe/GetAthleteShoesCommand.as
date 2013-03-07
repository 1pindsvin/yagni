package dk.runtrack.commands.shoe
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.responders.GetAthleteShoesResponder;
	
	import mx.rpc.IResponder;
	
	public class GetAthleteShoesCommand extends RtCommand
	{
		
		public static var resolveResponder : Function =
			function() : IResponder
			{
				return new GetAthleteShoesResponder()
			}

		private var _athlete : Athlete;	
		public function GetAthleteShoesCommand(athlete : Athlete)
		{
			super();
			if(athlete==null)
			{
				throw new Error("InvalidoperationException expected athlete");
			}
			_athlete = athlete;
		}
		
		override public function execute():void
		{
			this.responder = resolveResponder();
			dispatch(remoteService.getAthleteShoes(_athlete));		
		}
	}
}