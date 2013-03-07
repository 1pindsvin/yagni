package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	
	
	
	public class TimeFormatter
	{
		public static var resolveDateTimeInvironment : Function =
			function() : IDateTimeEnvironment
			{
				return new DateTimeEnvironment();
			}

		
		private static var formatTwoDigit : Function = Format.formatTwoDigit;
		private var _timeSeparator : String;
		private static var _subTimeElements : Array = ["hour", "minute", "second"];
		
		public function TimeFormatter()
		{
			_timeSeparator = resolveDateTimeInvironment().timeSeparator;
		}

		public function toTimeString(hours:uint, minutes:uint, seconds:uint): String
		{
			var result : Array =[ formatTwoDigit(hours), formatTwoDigit(minutes), formatTwoDigit(seconds) ]; 
			return result.join(_timeSeparator);			
		}
		
		public static function getTimeElements(time:String) : Array
		{
			return time.split(new TimeFormatter()._timeSeparator);
		}
		
		public function canParseTime(time:String) : Boolean
		{
			return canParseTimeElements(getTimeElements(time));
		}
				
		public static function parseUint(number:String) : uint
		{
			if(!isUint(number))
			{
				throw new Error("Not an integer [" + number + "]");	
			}
			return uint(number); 
		}

		private static const _uintRegex : RegExp =  /^\d+$/; 		
		public static function isUint(number: String) : Boolean
		{
			return number ? number.match(_uintRegex) : false;
		}
		
		private function canParseTimeElements(timeElements : Array) : Boolean
		{ 
			if(timeElements.length > _subTimeElements.length || timeElements.length==0)
			{
				return false;
			}	
			for each (var timeElement : String in timeElements)
			{
				if(!isUint(timeElement))
				{
					return false;
				}
				if(timeElement.length>2)
				{
					return false;
				}
			}
			return true;
		}
		
		public function fromDatabaseTime(time:uint) : String
		{
			var hours : uint = Math.floor(time/3600);
			time = time - (hours*3600);
			var minutes : uint = Math.floor(time/60);
			var seconds : uint = time - (minutes*60);
			var timeElements : Array = new Array();
			for each (var timeElement : uint in [hours, minutes, seconds])
			{
				if(timeElement >= 0)
				{
					timeElements.push(formatTwoDigit(timeElement));
				}
			}
			return timeElements.join(_timeSeparator);
		}
		
		
		public function toDatabaseTime(time:String) : uint
		{
			var split:Array = time.split(_timeSeparator);
			if(!canParseTimeElements(split))
			{
				throw new Error("Cannot parse this as time [" + time + "]");
			}
			if(split.length==1)
			{
				return parseUint(split[0]);
			}
			if(split.length==2)
			{
				return parseUint(split[1]) + (60 * parseUint(split[0]));
			}
			return parseUint(split[2]) + (60 * parseUint(split[1])) + (3600 * parseUint(split[0]));
		}
	}
}