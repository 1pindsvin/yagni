package dk.runtrack.commands.user
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.User;
	import dk.runtrack.responders.SaveUserResponder;
	
	import mx.rpc.IResponder;

	public class SaveUserCommand extends RtCommand
	{
		
		public static var resolveResponder : Function =
			function () : IResponder
			{
				return new SaveUserResponder();
			}
		private var _user: User;
		public function SaveUserCommand(user:User)
		{
			super();
			responder = resolveResponder();
			if(user==null)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + " ,SaveUserCommand, user==null");
			}
			_user=user;
		}
		
		override public function execute():void
		{
			dispatch(remoteService.saveUser(_user));
		}
	}
}