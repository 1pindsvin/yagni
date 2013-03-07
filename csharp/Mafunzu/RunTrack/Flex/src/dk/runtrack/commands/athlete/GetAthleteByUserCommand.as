package dk.runtrack.commands.athlete
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.User;
	import dk.runtrack.responders.GetAthleteByUserResponder;
	
	import mx.rpc.IResponder;

	public class GetAthleteByUserCommand extends RtCommand
	{
		public static var resolveResponder : Function =
			function(user: User) : IResponder
			{
				return new GetAthleteByUserResponder(user);
			}
		
		private var _user : User;
		public function GetAthleteByUserCommand(user : User)
		{
			if(user==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", GetAthleteByUserCommand, user was null");
			}
			_user = user;
		}

		public override function execute():void
		{
			responder  = resolveResponder(_user);
			dispatch(remoteService.getAthleteByUser(_user));
		}
		
	}
}