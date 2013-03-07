package dk.runtrack.model
{
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	import dk.runtrack.presentationmodels.TimeValidator;
	
	public class DateTimeEnvironmentManager
	{
		private var _dateTimeEnvironmentBeforeTests : Function; 
		private var _timeEnvironmentBeforeTests : Function; 

		public function DateTimeEnvironmentManager()
		{
		}

		public function setupForTesting() :void
		{
			_timeEnvironmentBeforeTests = TimeFormatter.resolveDateTimeInvironment;
			_dateTimeEnvironmentBeforeTests = DateTimeFormatter.resolveDateTimeInvironment;
			setupTestDateTimeEnvironment();
		}
		
		public function teardownTestSetup() : void
		{
			DateTimeFormatter.resolveDateTimeInvironment = _dateTimeEnvironmentBeforeTests;
			TimeFormatter.resolveDateTimeInvironment = _timeEnvironmentBeforeTests;
		}

		private function setupTestDateTimeEnvironment() : void
		{
			var f : Function = function() : IDateTimeEnvironment
			{
				return new TestDateTimeEnvironment();
			}
			_dateSeparator = f().dateSeparator;
			DateTimeFormatter.resolveDateTimeInvironment = f;
			TimeFormatter.resolveDateTimeInvironment = f;
			TimeValidator.resolveDateTimeInvironment = f;
		}
		
		private var _dateSeparator  : String;
		public function get dateSeparator() : String
		{
			return _dateSeparator;
		}

		private function setupUSTestDateTimeEnvironment() : void
		{
			var f : Function = function() : IDateTimeEnvironment
			{
				var env : TestDateTimeEnvironment = new TestDateTimeEnvironment();
				env.setUSLocale();
				return env;
			}
			_dateSeparator = f().dateSeparator;
			DateTimeFormatter.resolveDateTimeInvironment = f;
			TimeFormatter.resolveDateTimeInvironment = f;
			TimeValidator.resolveDateTimeInvironment = f;
		}
		
		public function setUSLocale( ) : void
		{
			setupUSTestDateTimeEnvironment();
		}

	}
}