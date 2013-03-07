package dk.runtrack.responders
{
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	import dk.runtrack.model.Format;
	
	import mx.controls.Alert;
	import mx.rpc.IResponder;
	import mx.rpc.events.FaultEvent;
	import mx.rpc.events.ResultEvent;
	
	public class BaseResponder implements IResponder
	{
		public static var resolveViewModelLocator : Function = function() : IPresentationModelLocator 
		{
			return new PresentationModelLocator();
		}
		
		private var _viewModelLocator : IPresentationModelLocator;
		public function BaseResponder()
		{
						
		}
		
		public function get presentationModelLocator():IPresentationModelLocator
		{
			if(_viewModelLocator==null)
			{
				_viewModelLocator = resolveViewModelLocator();
			}
			return _viewModelLocator;
		}

		public function set presentationModelLocator(v:IPresentationModelLocator):void
		{
			_viewModelLocator = v;
		}

		public final function result(data:Object):void
		{
			updatePresentationModel(ResultEvent(data));
		}
		
		protected function updatePresentationModel(resultEvent:ResultEvent) : void
		{
			throw new Error("Must implement updatePresentationModel");
		}
		
		public function fault(info:Object):void
		{
			if(info is FaultEvent)
			{
				var message : String = FaultEvent(info).fault.faultString + "," + FaultEvent(info).fault.faultDetail;
				Alert.show(message);
			}
			else
			{
				Alert.show("[" + Format.formatError(info)  +  "]");	
			}
		}

		
	}
}