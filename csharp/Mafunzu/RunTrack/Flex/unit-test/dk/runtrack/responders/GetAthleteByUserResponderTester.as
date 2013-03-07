package dk.runtrack.responders
{
	import dk.runtrack.commands.ResultEventBuilder;
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.User;
	import dk.runtrack.util.ExceptionHelper;
	import dk.runtrack.presentationmodels.RunActivityPresentationModel;
	
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;
	
	import mx.rpc.IResponder;
	import mx.rpc.events.ResultEvent;

	public class GetAthleteByUserResponderTester extends TestCase
	{
		private var _dummyViewModelLocator : DummyPresentationModelLocator; 

		public function GetAthleteByUserResponderTester(methodName:String=null)
		{
			super(methodName);
		}
		
		
		public function testConstructor() : void
		{
			var athleteByUserResponder : GetAthleteByUserResponder = new GetAthleteByUserResponder(new User());
			Assert.assertNotNull(athleteByUserResponder);
		} 
		
		public function testUpdateViewModelWhenUserHasNoRelatedAthleteShouldThrowError() : void
		{
			var athleteByUserResponder : IResponder = buildGetAthleteByUserResponder(new User());
			var resultEvent : ResultEvent = ResultEventBuilder.build(null);

			Assert.assertTrue(ExceptionHelper.methodWithArgumentThrowsException(
				athleteByUserResponder.result, resultEvent));
		}
		
		private function buildGetAthleteByUserResponder(user:User) : GetAthleteByUserResponder
		{
			var athleteByUserResponder : GetAthleteByUserResponder = new GetAthleteByUserResponder(new User());
			return athleteByUserResponder;	
		}
		
		public function testUpdateViewModelShouldSetAthleteViewModelState() : void
		{
			var athlete : Athlete = new Athlete();
			athlete.ID = 2;

			
			var dummyViewModelLocator : DummyPresentationModelLocator= new DummyPresentationModelLocator();
			dummyViewModelLocator.runActivityPresentationModel.updateState("UnKnown");
			 
			var athleteByUserResponder : GetAthleteByUserResponder = buildGetAthleteByUserResponder(new User());
			athleteByUserResponder.presentationModelLocator = dummyViewModelLocator;
			var resultEvent : ResultEvent = ResultEventBuilder.build(athlete);
			
			athleteByUserResponder.result(resultEvent);
			
			Assert.assertEquals(RunActivityPresentationModel.STATE_ATHLETE_CHANGED, dummyViewModelLocator.runActivityPresentationModel.state);
		}
		
		
	}
}