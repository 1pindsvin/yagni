package dk.runtrack.commands
{
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Constants;
	import dk.runtrack.responders.UploadWatchDataResponder;
	
	import mx.rpc.IResponder;

	public class UploadWatchDataCommand extends RtCommand
	{

		public static var resolveCurrentAthlete : Function = function() : Athlete
		{
			return new PresentationModelLocator().editAthletePresentationModel.currentathlete;			
		}
		
		public static var resolveResponder : Function = function() : IResponder
		{
			return new UploadWatchDataResponder();			
		}

		private var _compressedData : String
		private var _athlete : Athlete;
		
		public function UploadWatchDataCommand(compressedData : String)
		{
			super();
			if(!compressedData)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION + ", !compressedData"); 
			}
			_compressedData = compressedData;
			_athlete = resolveCurrentAthlete();
		}
		
		public override function execute():void
		{
			responder = resolveResponder();
			dispatch(remoteService.uploadWatchData(_athlete, _compressedData));
		}
		
	}
}