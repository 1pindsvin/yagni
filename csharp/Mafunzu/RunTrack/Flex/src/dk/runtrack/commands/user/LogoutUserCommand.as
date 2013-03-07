package dk.runtrack.commands.user
{
	import com.adobe.cairngorm.business.ServiceLocator;
	
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.presentationmodels.ApplicationPresentationModel;
	import dk.runtrack.presentationmodels.LoginPresentationModel;
	
	import flash.net.URLRequest;
	import flash.net.navigateToURL;

	public class LogoutUserCommand implements IRtCommand
	{

		private var resolveViewModelLocator : Function = function() : IPresentationModelLocator
		{
			return new PresentationModelLocator();
		}

		
		public function LogoutUserCommand()
		{

		}
		
		private static const INVALID_PASSWORD : String = "Gryffe";
		private static const LOGIN_HTML_PAGE_NAME : String = "/"; //"RunTrack.html";
		//new CookieAdapter().password = INVALID_PASSWORD;
		
		public function execute():void
		{
			var presentationModelLocator : IPresentationModelLocator = resolveViewModelLocator();
			try
			{
				var isLogoutSuccess : Boolean = true;
				try
				{
					//remoteobjects logout might fail  :(
					//remoteService.channelSet == null 
					//com.adobe.cairngorm.business.Remoteobjects
					ServiceLocator.getInstance().logout();
				}
				catch(error:Error)
				{
					isLogoutSuccess = false;
				}
				if(isLogoutSuccess)
				{
					ServiceLocator.getInstance().setCredentials(null, null);
				}
				presentationModelLocator.applicationPresentationModel.state = ApplicationPresentationModel.STATE_NOT_LOGGED_IN;
				presentationModelLocator.loginPresentationModel.state = LoginPresentationModel.STATE_INPUT_CREDENTIALS;
				
			}
			finally
			{
				var urlString:String =  LOGIN_HTML_PAGE_NAME;
				var request:URLRequest = new URLRequest(urlString);
				navigateToURL(request, "_self");
			}
			
		}
		
	}
}