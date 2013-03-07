package dk.runtrack.controller
{
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	import dk.runtrack.model.ActivityQuery;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.AthleteHealthQuery;
	import dk.runtrack.model.BestRunsQuery;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.Goal;
	import dk.runtrack.model.MonthQuery;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.RunsPage;
	import dk.runtrack.model.Shoe;
	import dk.runtrack.model.TrainingPlan;
	import dk.runtrack.model.User;
	
	import mx.rpc.AsyncToken;
	
	public class DummyRemoteService implements IRtRemoteService
	{
		public static var calls : Object= {};
		public static var registeredAsyncTokens : Array = new Array();
		
		public static function clearTokens() : void
		{
			registeredAsyncTokens.splice(0);
		}
		
		public static function hasRegisteredOneToken() : Boolean
		{
			return registeredAsyncTokens.length==1;
		}
		
		private function addDummyToken() : AsyncToken
		{
			var token : AsyncToken = new AsyncToken(null); 
			registeredAsyncTokens.push(token);
			return token;
		}
		
		public function DummyRemoteService()
		{
		}
		
		public function athleteExists(email:String, password:String):AsyncToken
		{
			return null;
		}
		
		
		public function getAthlete(email:String, password:String):AsyncToken
		{
			calls.getAthlete = 1;
			return addDummyToken();
		}
		
		public function getAthleteByUser(user: User) : AsyncToken
		{
			calls.getAthleteByUser = 1;
			return addDummyToken();
		}
		
		public function saveRun(run:Run):AsyncToken
		{
			calls.runSaveRunRemote = 1;
			return addDummyToken();
		}
		
		public function deleteRun(run: Run) : AsyncToken
		{
			calls.deleteRun = 1;
			return addDummyToken();			
		}
		
		public function saveShoe(shoe: Shoe) : AsyncToken
		{
			calls.saveShoe = 1;
			return addDummyToken();					
		}
		
		public function saveAthlete(athlete:Athlete):AsyncToken
		{
			return null;
		}
		
		public function getRunsPage(page:RunsPage) : AsyncToken
		{
			calls.getRunsPage = 1;
			return addDummyToken();
		} 
		
		public function saveUser(user:User) : AsyncToken
		{
			return addDummyToken();	
		}
		
		public function getAthleteShoes(athlete:Athlete) : AsyncToken 
		{
			if(!athlete)
			{
				throw new Error(Constants.ATHLETE_NOT_SET + ", DummyRemoteService, getAthleteShoes");
			}
			calls.getAthleteShoes = 1;
			return addDummyToken();	
			
		}
		
		public function saveShoes(shoes : Array) : AsyncToken
		{
			calls.saveShoes = 1;
			return addDummyToken();
		}

		public function deleteAndUpdateShoes(dbOperations : Array) : AsyncToken
		{
			calls.deleteAndUpdateShoes = 1;
			return addDummyToken();
		}

		public function authenticateUser(userName : String, password : String) : AsyncToken
		{
			calls.authenticateUser = 1;
			return addDummyToken();
		} 

		public function downloadMyRuns(athlete: Athlete) : AsyncToken
		{
			calls.downloadMyRuns = 1;
			return addDummyToken();
		}

  		public 	function undoDeleteRun(run: Run) : AsyncToken
 		{
			calls.undoDeleteRun = 1;
			return addDummyToken();
 		}

		public function getMonthQuery(monthQuery : MonthQuery) : AsyncToken
		{
			calls.getMonthQuery = 1;
			return addDummyToken();
		}

		public function saveGoal(goal:Goal) : AsyncToken
		{
			calls.saveGoal = 1;
			return addDummyToken();
		}

		public function saveTrainingPlan(trainingPlan : TrainingPlan) : AsyncToken
		{
			calls.saveTrainingPlan = 1;
			return addDummyToken();
		}

		public function getAthleteTrainingPlans(athlete:Athlete) : AsyncToken
		{
			calls.getAthleteTrainingPlans = 1;
			return addDummyToken();
		}
		
		public function getPlannedRuns(trainingPlan : TrainingPlan) : AsyncToken
		{
			calls.getPlannedRuns = 1;
			return addDummyToken();
		}
		
		public function createUserWithDefaultAthlete(emailAsUsername : String, password : String) : AsyncToken
		{
			calls.createUserWithDefaultAthlete = 1;
			return addDummyToken();
		}

		public function getBestRuns(query: BestRunsQuery) : AsyncToken
		{
			calls.getBestRuns = 1;
			return addDummyToken();
		}

		public function getHealthHistory(query: AthleteHealthQuery) : AsyncToken
		{
			calls.getHealthHistory = 1;
			return addDummyToken();
		}

		public function uploadWatchData(athlete:Athlete, compressedData : String) : AsyncToken
		{
			calls.uploadWatchData = 1;
			return addDummyToken();
		}

		public function getActivities(query: ActivityQuery) : AsyncToken
		{
			calls.getActivities = 1;
			return addDummyToken();
		}
	}
}