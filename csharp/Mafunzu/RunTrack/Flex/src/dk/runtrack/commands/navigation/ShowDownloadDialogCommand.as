package dk.runtrack.commands.navigation
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	
	import flash.events.Event;
	import flash.events.HTTPStatusEvent;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.net.FileReference;
	import flash.net.URLRequest;
	

	public class ShowDownloadDialogCommand implements IRtCommand
	{
		public function ShowDownloadDialogCommand() 
		{

		}
		
		private var _fileUrl:String;
	
		private var fileRef:FileReference;
		private var urlReq:URLRequest;

		private var fileRefModel : Object;
		public function execute() : void
		{
			fileRefModel = {};

			_fileUrl = new PresentationModelLocator().downloadPresentationModel.url;			

			urlReq = new URLRequest(_fileUrl);
			
			fileRef = new FileReference();
			fileRef.addEventListener(Event.CANCEL, doEvent);
			fileRef.addEventListener(Event.COMPLETE, doEvent);
			fileRef.addEventListener(Event.OPEN, doEvent);
			fileRef.addEventListener(Event.SELECT, doEvent);
			fileRef.addEventListener(HTTPStatusEvent.HTTP_STATUS, doEvent);
			fileRef.addEventListener(IOErrorEvent.IO_ERROR, doEvent);
			fileRef.addEventListener(ProgressEvent.PROGRESS, doEvent);
			fileRef.addEventListener(SecurityErrorEvent.SECURITY_ERROR, doEvent);
			
			fileRef.download(urlReq);									
		}	

		private function doEvent(evt:Event):void 
		{
			var fr:FileReference = evt.currentTarget as FileReference;
			try {
				fileRefModel.creationDate = fr.creationDate;
				fileRefModel.creator = fr.creator;
				fileRefModel.modificationDate = fr.modificationDate;
				fileRefModel.name = fr.name;
				fileRefModel.size = fr.size;
				fileRefModel.type = fr.type;
			} catch (err:*) {
				// uh oh, an error of sorts.
			}
		}

		
	}
}