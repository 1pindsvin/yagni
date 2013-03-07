package dk.runtrack.responders
{
	import com.adobe.cairngorm.business.ServiceLocator;
	
	import dk.runtrack.commands.athlete.GetAthleteByUserCommand;
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.User;
	import dk.runtrack.presentationmodels.ApplicationPresentationModel;
	import dk.runtrack.presentationmodels.LoginPresentationModel;
	
	import mx.rpc.events.ResultEvent;
	
	public class LoginUserResponder extends BaseResponder
	{
		public function LoginUserResponder()
		{
			super();
		}
		
		protected override function updatePresentationModel(resultEvent:ResultEvent):void
		{
			var user:User = resultEvent.result as User;
			if (user == null)
			{
				presentationModelLocator.loginPresentationModel.state = LoginPresentationModel.STATE_CREDENTIALS_NOT_FOUND;				
			}
			else
			{
				presentationModelLocator.loginPresentationModel.state = LoginPresentationModel.STATE_LOGGED_IN;
				presentationModelLocator.loginPresentationModel.currentuser = user;								 
				presentationModelLocator.applicationPresentationModel.state = ApplicationPresentationModel.STATE_TRAINING_PERSPECTIVE;
				ServiceLocator.getInstance().setCredentials(user.UserName, user.Password);
				var command : IRtCommand = new GetAthleteByUserCommand(user);
				new RunTrackEvent(command).dispatch();
			}				
			
		}
		

	}
}