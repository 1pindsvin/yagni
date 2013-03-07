package dk.runtrack
{
	import dk.runtrack.commands.BaseCommand;
	import dk.runtrack.commands.OnTrackCommandDispatchTester;
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.commands.SetSelectedDateCommandExecuteTester;
	import dk.runtrack.commands.activity.GetActivitiesCommandTester;
	import dk.runtrack.commands.athlete.GetAthleteByUserCommandTester;
	import dk.runtrack.commands.athlete.GetHealthHistoryCommandTester;
	import dk.runtrack.commands.run.DeleteRunCommandTester;
	import dk.runtrack.commands.run.GetBestRunsCommandTester;
	import dk.runtrack.commands.run.GetPlannedRunsComandTester;
	import dk.runtrack.commands.run.SaveRunCommandTester;
	import dk.runtrack.commands.shoe.GetAthleteShoesCommandTester;
	import dk.runtrack.commands.trainingplanning.GetAthleteTrainingPlansCommandTester;
	import dk.runtrack.commands.trainingplanning.SaveTrainingPlanCommandTester;
	import dk.runtrack.commands.user.CreateUserWithAthleteCommandTester;
	import dk.runtrack.commands.user.LoginUserCommandExecuteTester;
	import dk.runtrack.controller.DummyRemoteService;
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	import dk.runtrack.io.CookieAdapterTester;
	import dk.runtrack.io.PersistentObjectTester;
	import dk.runtrack.model.AthleteHealthQueryTester;
	import dk.runtrack.model.ClientShoesTester;
	import dk.runtrack.model.ConverterTester;
	import dk.runtrack.model.DateTimeFormatterTester;
	import dk.runtrack.model.DegreesConverterTester;
	import dk.runtrack.model.DistanceFormatterTester;
	import dk.runtrack.model.DummyClient;
	import dk.runtrack.model.TimeFormatterTester;
	import dk.runtrack.model.interfaces.IClientModel;
	import dk.runtrack.presentationmodels.AthleteHealthHistoryPresentationModelTester;
	import dk.runtrack.presentationmodels.AthleteViewModelTester;
	import dk.runtrack.presentationmodels.EditRunPresentationModel;
	import dk.runtrack.presentationmodels.EditRunPresentationModelTester;
	import dk.runtrack.presentationmodels.EditShoeViewModelSaveTester;
	import dk.runtrack.presentationmodels.EditTrainingPlanSaveTester;
	import dk.runtrack.presentationmodels.PagerTester;
	import dk.runtrack.presentationmodels.RunDataGridViewItemStartTester;
	import dk.runtrack.presentationmodels.SortColumnsTester;
	import dk.runtrack.presentationmodels.TimeValidatorTester;
	import dk.runtrack.presentationmodels.UndoTimerTester;
	import dk.runtrack.responders.BaseResponderTester;
	import dk.runtrack.responders.GetActivitiesForSingleDayResponderTester;
	import dk.runtrack.responders.GetAthleteByUserResponderTester;
	import dk.runtrack.responders.GetAthleteShoesResponderTester;
	import dk.runtrack.responders.GetAthleteTrainingPlansResponderTester;
	import dk.runtrack.responders.GetBestRunsResponderTester;
	import dk.runtrack.responders.GetHealthHistoryResponderTester;
	import dk.runtrack.responders.GetPlannedRunsResponderTester;
	import dk.runtrack.responders.RunPageResponderUpdateViewModelTester;
	import dk.runtrack.util.ExceptionHelper;
	import dk.runtrack.util.RegularExpressionTester;
	import dk.runtrack.view.components.RunTrackDateFieldTester;
	
	import flexunit.framework.Test;
	import flexunit.framework.TestSuite;
	
	
	
	public class AllTests
	{
		
		private static var _testAreSetup:Boolean;
		
		public function AllTests()
		{
		}
		
		public static function setupTests():void
		{
			if (_testAreSetup)
			{
				return;
			}
			BaseCommand.resolveRemoteService = function() : IRtRemoteService
			{
				return new DummyRemoteService();
			}
			RtCommand.resolveRemoteService = function() : IRtRemoteService
			{
				return new DummyRemoteService();
			}
			EditRunPresentationModel.getClient = function() : IClientModel
			{
				return new DummyClient();
			}			
					
		}
		
		public static function suite(): Test
		{
			setupTests();
			var suite:TestSuite = new TestSuite();
			suite.name = "Suite containing all tests for OnTrack";
			
			suite.addTestSuite(ExceptionHelper);
			suite.addTestSuite(AthleteViewModelTester);
			suite.addTestSuite(DateTimeFormatterTester);
			suite.addTestSuite(TimeFormatterTester);
			suite.addTestSuite(DistanceFormatterTester);
			suite.addTestSuite(SaveRunCommandTester);

			suite.addTestSuite(PagerTester);

			suite.addTestSuite(BaseResponderTester);
			suite.addTestSuite(GetAthleteByUserResponderTester);
			suite.addTestSuite(GetAthleteByUserCommandTester);

			suite.addTestSuite(TimeValidatorTester);
			suite.addTestSuite(DeleteRunCommandTester);
			
			suite.addTestSuite(OnTrackCommandDispatchTester);
			suite.addTestSuite(RegularExpressionTester);
			suite.addTestSuite(SortColumnsTester);

			suite.addTestSuite(GetAthleteShoesResponderTester);
			suite.addTestSuite(GetAthleteShoesCommandTester);

			suite.addTestSuite(SetSelectedDateCommandExecuteTester);
			suite.addTestSuite(RunPageResponderUpdateViewModelTester);

			suite.addTestSuite(EditRunPresentationModelTester);
			
			suite.addTestSuite(RunTrackDateFieldTester);
			
			suite.addTestSuite(CookieAdapterTester);
			
			suite.addTestSuite(EditShoeViewModelSaveTester);
			
			suite.addTestSuite(PersistentObjectTester);
			suite.addTestSuite(ClientShoesTester);
			
			suite.addTestSuite(RunDataGridViewItemStartTester);
			
			suite.addTestSuite(LoginUserCommandExecuteTester);

			suite.addTestSuite(UndoTimerTester);
			
			suite.addTestSuite(ConverterTester);

			suite.addTestSuite(EditTrainingPlanSaveTester);

			suite.addTestSuite(SaveTrainingPlanCommandTester);
	
			suite.addTestSuite(GetAthleteTrainingPlansCommandTester);
			
			suite.addTestSuite(GetAthleteTrainingPlansResponderTester);

			suite.addTestSuite(GetPlannedRunsComandTester);
			
			suite.addTestSuite(GetPlannedRunsResponderTester);
			
			suite.addTestSuite(CreateUserWithAthleteCommandTester);

			suite.addTestSuite(GetBestRunsCommandTester);

			suite.addTestSuite(GetBestRunsResponderTester);

			suite.addTestSuite(GetHealthHistoryCommandTester);

			suite.addTestSuite(GetHealthHistoryResponderTester);
			
			suite.addTestSuite(AthleteHealthHistoryPresentationModelTester);

			suite.addTestSuite(AthleteHealthQueryTester);

			suite.addTestSuite(DegreesConverterTester);
			
			suite.addTestSuite(GetActivitiesCommandTester);
			
			suite.addTestSuite(GetActivitiesForSingleDayResponderTester);

			return suite;
		}

	}
}