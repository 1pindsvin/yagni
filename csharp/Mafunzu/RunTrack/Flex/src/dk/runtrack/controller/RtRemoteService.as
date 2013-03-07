package dk.runtrack.controller
{
	import com.adobe.cairngorm.business.ServiceLocator;
	
	import dk.runtrack.controller.interfaces.IRtRemoteService;
	import dk.runtrack.model.ActivityQuery;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.AthleteHealthQuery;
	import dk.runtrack.model.BestRunsQuery;
	import dk.runtrack.model.Goal;
	import dk.runtrack.model.MonthQuery;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.RunsPage;
	import dk.runtrack.model.Shoe;
	import dk.runtrack.model.TrainingPlan;
	import dk.runtrack.model.User;
	
	import mx.rpc.AsyncToken;

	public class RtRemoteService implements IRtRemoteService
	{
		private var _athleteService : Object;
		private var _userService : Object;
		private var _shoeService : Object;
		private var _runService : Object;
		private var _securityService : Object;		
		private var _downloadService : Object;
		
		public function RtRemoteService()
		{
			_athleteService=null;
			_userService=null;
			_shoeService=null;
			_runService=null;
			_securityService=null;
			_downloadService = null;
		}
		private function get downloadService() : Object
		{
			if(_downloadService==null)
			{
				_downloadService = ServiceLocator.getInstance().getRemoteObject("downloadService");
			}
			return _downloadService;
		}

		private function get securityService() : Object
		{
			if(_securityService==null)
			{
				_securityService = ServiceLocator.getInstance().getRemoteObject("securityService");
			}
			return _securityService;
		}

		private function get shoeService() : Object
		{
			if(_shoeService==null)
			{
				_shoeService = ServiceLocator.getInstance().getRemoteObject("shoeService");
			}
			return _shoeService;
		}

		private function get athleteService() : Object
		{
			if(_athleteService==null)
			{
				_athleteService = ServiceLocator.getInstance().getRemoteObject("athleteService");
			}
			return _athleteService;
		}

		private function get userService() : Object
		{
			if(_userService==null)
			{
				_userService = ServiceLocator.getInstance().getRemoteObject("userService");
			}
			return _userService;
		}

		private function get runService() : Object
		{
			if(_runService==null)
			{
				_runService = ServiceLocator.getInstance().getRemoteObject("runService");
			}
			return _runService;
		}

		private function get workoutService() : Object
		{
			if(_runService==null)
			{
				_runService = ServiceLocator.getInstance().getRemoteObject("workoutService");
			}
			return _runService;
		}

		public function getAthleteByUser(user: User) : AsyncToken
		{
			return athleteService.GetAthlete(user);
		}
		
		public function saveRun(run: Run) : AsyncToken
		{
			return runService.SaveRun(run);
		}
		
		public function deleteRun(run: Run) : AsyncToken
		{
			return runService.DeleteRun(run);			
		}

		public function saveAthlete(athlete: Athlete) : AsyncToken
		{
			return athleteService.SaveAthlete(athlete);
		}
		
		public function getRunsPage(page:RunsPage) : AsyncToken
		{
			return runService.GetRuns(page);
		} 
		
		public function saveUser(user:User) : AsyncToken
		{
			return userService.Save(user);	
		}
		
		public function getAthleteShoes(athlete:Athlete) : AsyncToken 
		{
			return shoeService.GetShoes(athlete);	
		}

		public function saveShoe(shoe: Shoe) : AsyncToken
		{
			return shoeService.SaveShoe(shoe);			
		}

		public function saveShoes(shoes : Array) : AsyncToken
		{
			return shoeService.SaveShoes(shoes);
		}
		
		public function deleteAndUpdateShoes(dbOperations : Array) : AsyncToken
		{
			return shoeService.DeleteAndUpdateShoes(dbOperations);
		}

		public function authenticateUser(userName : String, password : String) : AsyncToken
		{
			return securityService.AuthenticateUser(userName, password);			
		}
		
		public function downloadMyRuns(athlete: Athlete) : AsyncToken
		{
			return downloadService.DownloadMyRuns(athlete);
		}
 
 		public 	function undoDeleteRun(run: Run) : AsyncToken
 		{
 			return runService.UndoDeleteRun(run);	
 		}

		public function getMonthQuery(monthQuery : MonthQuery) : AsyncToken
		{
			return runService.GetMonthQuery(monthQuery);
		}

		public function saveGoal(goal:Goal) : AsyncToken
		{
			return athleteService.SaveGoal(goal);
		}

		public function saveTrainingPlan(trainingPlan : TrainingPlan) : AsyncToken
		{
			return athleteService.SaveTrainingPlan(trainingPlan);
		}

		public function getAthleteTrainingPlans(athlete:Athlete) : AsyncToken
		{
			return athleteService.GetAthleteTrainingPlans(athlete);
		}
		
		public function getPlannedRuns(trainingPlan : TrainingPlan) : AsyncToken
		{
			return runService.GetPlannedRuns(trainingPlan);
		}
		
		public function createUserWithDefaultAthlete(emailAsUsername : String, password : String) : AsyncToken
		{
			return userService.CreateUserWithDefaultAthlete(emailAsUsername, password);	
		}
		
		public function getBestRuns(query: BestRunsQuery) : AsyncToken
		{
			return runService.GetBestRuns(query);	
		}

		public function getHealthHistory(query: AthleteHealthQuery) : AsyncToken
		{
			return athleteService.GetHealthHistory(query);
		}
		
		public function uploadWatchData(athlete:Athlete, compressedData : String) : AsyncToken
		{
			return workoutService.UploadWatchData(athlete, compressedData);
		}
		
		public function getActivities(query: ActivityQuery) : AsyncToken
		{
			return workoutService.GetActivities(query);
		}


	}
}