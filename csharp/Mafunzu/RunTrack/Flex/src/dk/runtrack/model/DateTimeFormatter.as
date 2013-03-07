package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	
		 
	
	public class DateTimeFormatter
	{
		public static const VALIDATOR_BUNDLE_NAME : String = "validators"; 
		public static const DECIMAL_SEPARATOR_NAME : String = "decimalSeparator";
		
		public static var resolveDateTimeInvironment : Function =
			function() : IDateTimeEnvironment
			{
				return new DateTimeEnvironment();
			}

		private static var formatTwoDigit : Function = Format.formatTwoDigit;

		private static var _hasResolvedTimeCompensation : Boolean;
		private static var _hourCompensation : int;
		private function ensureCanBuildValidDates() : void
		{
			if(!_hasResolvedTimeCompensation)
			{
				var dfullYear : uint = 2000;
				var dmonth : uint = 4;
				var ddate : uint = 3;
				var dhour : uint = 12;
				var dminute : uint = 30; 
				var dsecond : uint = 30;		
				var date : Date = new Date(dfullYear, dmonth, ddate, dhour, dminute,dsecond,0);
				if(
					date.fullYear!=dfullYear ||  date.month != dmonth || date.date!= ddate || date.minutes!=dminute || date.seconds!=dsecond )
				{
					throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
				}
				if(date.hours!=dhour)
				{
					_hourCompensation = date.hours - dhour;
				}
				date = new Date(dfullYear, dmonth, ddate, dhour + _hourCompensation, dminute,dsecond,0);
				if(date.fullYear!=dfullYear || date.month != dmonth || date.date!= ddate || date.hours != dhour || date.minutes!=dminute || date.seconds!=dsecond )
				{
					throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
				}
				_hasResolvedTimeCompensation = true;								
			}
		}

		public static const SPACE : String = " ";		
		private const _dateDelimiterRegex : RegExp = /[\-\/\.]/;
		private static const _spaceRegExp : RegExp = new RegExp("\\s+");

		private var _timeFormatter : TimeFormatter;
		
		private var _dateTimeEnvironment : IDateTimeEnvironment;
		 
		public function DateTimeFormatter()
		{
			_dateTimeEnvironment = resolveDateTimeInvironment();
			_timeFormatter = new TimeFormatter();
		}
		
		public function isDateTimeValid(dateTime:String) : Boolean
		{
			if(dateTime==null)
			{
				return false;
			}
			var split : Array = dateTime.split(_spaceRegExp);
			if(split.length!=2)
			{
				return false;
			}
			return isDateValid(split[0]) && isTimeValid(split[1]);
		}
		
		
		public function isTimeValid(time:String) : Boolean
		{
			return _timeFormatter.canParseTime(time);				
		}
		
		public function isDateValid(date:String) : Boolean
		{
			if(date==null)
			{
				return false;
			}
			var result:Object = date.match(_dateDelimiterRegex);
			if(result==null)
			{
				return false;
			}
			var delimiter : String = result[0];
			if(delimiter==null)
			{
				return false;
			}
			var isDate : Boolean = false;
			try
			{
				var dummyDate : Date = getDate(date);
				isDate = true;
			}
			catch(error:Error)
			{
			}
			return isDate;
		}

		private function buildDateTime(
			year:String, month:String, date:String, hour:String, minute: String, second: String) : Date
		{
			//ensureCanBuildValidDates();
			var dfullYear : uint = uint(year);
			var dmonth : uint = uint(month) -1;
			var ddate : uint = uint(date);
			var dhour : uint = uint(hour); //+ DateTimeFormatter._hourCompensation;
			var dminute : uint = uint(minute); 
			var dsecond : uint = uint(second);		

			var mydate: Date =  new Date(dfullYear, dmonth, ddate, dhour, dminute, dsecond);
			return mydate;	
		}

		private function buildDate(year:String, month:String, date:String) : Date
		{
			var dfullYear : uint = uint(year);
			var dmonth : uint = uint(month) -1;
			var ddate : uint = uint(date);		
			var mydate: Date =  new Date(dfullYear, dmonth, ddate)
			return mydate;	
		}
	
		public function getTime(dateTime:Date) : String
		{
			return _timeFormatter.toTimeString(dateTime.hours, dateTime.minutes, dateTime.seconds);			
		}

		public function toDateTimeString(dateTime:Date) : String
		{
			return toDateString(dateTime) 
				+  SPACE +  
				_timeFormatter.toTimeString(dateTime.hours, dateTime.minutes, dateTime.seconds);
		}

		private function getDateString(yearPart : uint, monthPart : uint, datePart : uint) : String
		{
			var dateParts : Array = new Array(3);
			dateParts[_dateTimeEnvironment.monthIndex] = formatTwoDigit(monthPart + 1);
			dateParts[_dateTimeEnvironment.dateIndex] = formatTwoDigit(datePart);
			dateParts[_dateTimeEnvironment.yearIndex] = yearPart.toString();
			return dateParts.join(_dateTimeEnvironment.dateSeparator);
		}

		public function toDateString(dateTime:Date) : String
		{
			return getDateString(dateTime.fullYear,dateTime.month, dateTime.date);
		}

		public function getDate(date:String) : Date
		{
			var delimiter:String = date.match(_dateDelimiterRegex)[0];	
			var dateParts : Array = date.split(delimiter);
			if(dateParts.length < 3)
			{
				dateParts.push(new Date().fullYear);
			}
			return buildDate(
				dateParts[_dateTimeEnvironment.yearIndex], 
				dateParts[_dateTimeEnvironment.monthIndex], 
				dateParts[_dateTimeEnvironment.dateIndex]);
			
		}

		public function getDateTimeParts(dateTime:String) : Array
		{
			return dateTime.split(_spaceRegExp);
		}

		private function getDateParts(date : String) : Array
		{
			var delimiter:String = date.match(_dateDelimiterRegex)[0];	
			var dateParts : Array = date.split(delimiter);
			return dateParts;
		}

		public function toDateTime(dateTimeString:String) : Date
		{
			var split : Array = getDateTimeParts(dateTimeString);

			var dateParts : Array = getDateParts(split[0]);
			var timeElements : Array = TimeFormatter.getTimeElements(split[1]);

			if(timeElements.length==1)
			{
				timeElements = [timeElements[0],0,0];
			}
			else if (timeElements.length==2)
			{
				timeElements = [timeElements[0], timeElements[1], 0];
			}
			return buildDateTime(
				dateParts[_dateTimeEnvironment.yearIndex], 
				dateParts[_dateTimeEnvironment.monthIndex], 
				dateParts[_dateTimeEnvironment.dateIndex],
				timeElements[0],
				timeElements[1],
				timeElements[2]				
				);
			return dateTime;
		}

 		public function getDateTime(dateTime:String) : Date
		{
			return toDateTime(dateTime);
		}
 
	}
}