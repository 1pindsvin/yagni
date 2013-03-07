package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	
	import mx.resources.IResourceManager;
	import mx.resources.ResourceManager;

	public class DateTimeEnvironment implements IDateTimeEnvironment
	{
		public function DateTimeEnvironment()
		{
			resolveDateParts();
		}

		protected function resolveDateParts() : void
		{
				var dateParts : Array = dateFormat.split(dateSeparator);
				//the simplest hack
				_yearIndex = 2;
				if(dateParts[0]=="MM")
				{
					_monthIndex = 0;
					_dateIndex = 1;
				}
				else
				{
					_monthIndex=1
					_dateIndex=0;
				}							
			
		}

		private var _dateIndex : uint
		public function get dateIndex():uint
		{
			return _dateIndex;
		}
		
		private var _monthIndex : uint;
		public function get monthIndex():uint
		{
			return _monthIndex;
		}
		
		private var _yearIndex : uint;
		public function get yearIndex():uint
		{
			return _yearIndex;
		}
		
		public function get dateSeparator():String
		{
			try
			{
				var format : String = dateFormat;
				if(format.match(/\//))
				{
					return "/";
				}
				if(format.match(/\-/))
				{
					return "-";			
				}
			}
			catch(error:Error)
			{
				throw new Error(Constants.RESOURCEMANAGER_NOT_INITIALIZED_EXCEPTION + ", " + error.getStackTrace());
			}
			throw new Error("dateSeparator not found");
		}
		
		public function get timeSeparator() : String
		{
			return ":";	
		}

		private static var _dateFormat : String = null;
		public function get dateFormat() : String
		{
			if(_dateFormat==null)
			{
				var resourceManager : IResourceManager = ResourceManager.getInstance();
				_dateFormat = resourceManager.getString('SharedResources','dateFormat');
			}
			return _dateFormat ;
		}

		public static function updateDateFormat() : void
		{
			_dateFormat = null;
		}
		
		public function get timeFormat() : String
		{
			return "HH:NN:SS";
		}
		
	}
}