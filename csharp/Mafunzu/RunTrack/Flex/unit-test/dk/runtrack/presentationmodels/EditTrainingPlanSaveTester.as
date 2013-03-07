package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.trainingplanning.GetAthleteTrainingPlansCommand;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.DistanceFormatter;
	import dk.runtrack.model.WeekdaySelectionEnumeration;
	
	import flexunit.framework.TestCase;
	
	public class EditTrainingPlanSaveTester extends TestCase
	{
		private var _athlete : Athlete;

		public function EditTrainingPlanSaveTester(methodName:String=null)
		{
			super(methodName);
			_athlete = new Athlete();
			GetAthleteTrainingPlansCommand.resolveAthlete = function() : Athlete
			{
				return _athlete;
			}

		}
		
		public function testSaveShouldSetPropertiesOnTrainingplan() : void
		{
			var e : EditTrainingPlanPresentationModel = new EditTrainingPlanPresentationModel();
			var startDistance : String  = "1";
			var goalKilometers : int = 10;
			var skill : int = 50;
			e.goalKilometers = goalKilometers.toString();
			e.startDistance = startDistance;
			e.intensity = skill;
			e.preferredWeekdays = WeekdaySelectionEnumeration.FifthDayOfWeek | WeekdaySelectionEnumeration.FirstDayOfWeek;
			e.skill = skill;
			
			e.save();
			
			assertEquals(goalKilometers, new DistanceFormatter().fromDatabaseDistance(e.trainingPlan.Goal.Distance));
			assertEquals(skill, e.trainingPlan.Intensity);
			assertEquals(skill, e.trainingPlan.Skill);
			assertEquals(1000, e.trainingPlan.StartDistance);
			
			assertEquals(WeekdaySelectionEnumeration.FifthDayOfWeek | WeekdaySelectionEnumeration.FirstDayOfWeek, e.trainingPlan.PreferredWeekdays);
			
		}

	}
}