package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.DateTimeFormatter;
	import dk.runtrack.model.DateTimeFormatterTester;
	import dk.runtrack.model.TestDateTimeEnvironment;
	import dk.runtrack.model.TimeFormatter;
	import dk.runtrack.model.User;
	import dk.runtrack.model.interfaces.IDateTimeEnvironment;
	
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class AthleteViewModelTester extends TestCase
	{

		private var toStringWithCurrentDateSeparator : Function = DateTimeFormatterTester.toStringWithCurrentSeparator;

		private var _dateTimeEnvironmentBeforeTests : Function; 
		private var _timeEnvironmentBeforeTests : Function; 
			
		override public function setUp():void
		{
			_timeEnvironmentBeforeTests = TimeFormatter.resolveDateTimeInvironment;
			_dateTimeEnvironmentBeforeTests = DateTimeFormatter.resolveDateTimeInvironment;
			setupTestDateTimeEnvironment();			
			super.setUp();
		}
		
		override public function tearDown():void
		{
			DateTimeFormatter.resolveDateTimeInvironment = _dateTimeEnvironmentBeforeTests;
			TimeFormatter.resolveDateTimeInvironment = _timeEnvironmentBeforeTests;
			super.tearDown();
		}
		
		private function setupTestDateTimeEnvironment() : void
		{
			var f : Function = function() : IDateTimeEnvironment
			{
				return new TestDateTimeEnvironment();
			}
			DateTimeFormatter.resolveDateTimeInvironment = f;
			TimeFormatter.resolveDateTimeInvironment = f;
		}


		public function AthleteViewModelTester(methodName:String=null)
		{
			super(methodName);
			var date : Date = new Date();
			date.fullYearUTC = 1999;
			date.monthUTC = 1;
			date.dateUTC = 12;
			_defaultDate = date;
		}
		
		private var _defaultDate : Date;
		private function buildAthlete() : Athlete
		{
			var e : Athlete = Athlete.createAthlete(new User());
			e.ID = -1;
			e.DateOfBirth = _defaultDate;
			e.FirstName = "Gombert";
			e.LastName = "Flandhart";
			return e;	
			
		}
		
		private function setGuiTestProperties(athleteViewModel:EditAthletePresentationModel):void
		{
			athleteViewModel.firstName = "firstName"
			athleteViewModel.dateOfBirth = new Date(2000,0,1); //   toStringWithCurrentDateSeparator( "01","01","2000");
			athleteViewModel.lastName = "lastName";
		}
		
		public function testConstructor():void
		{
			var e : EditAthletePresentationModel = new EditAthletePresentationModel();
			Assert.assertNotNull(e);
		}
		
		public function testSaveExpectsSetsValuesOnAthleteFromViewModel() : void
		{
			var athleteViewModel:EditAthletePresentationModel = new EditAthletePresentationModel();
			var athlete : Athlete = buildAthlete();
			
			athleteViewModel.currentathlete = athlete;			
			setGuiTestProperties(athleteViewModel);			

			athleteViewModel.save();
			
			assertNotNull(athlete.DateOfBirth);
			Assert.assertEquals(athleteViewModel.firstName, athlete.FirstName );
			Assert.assertEquals(athleteViewModel.lastName, athlete.LastName );

		}
			
	}
}