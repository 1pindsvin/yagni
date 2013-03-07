package dk.runtrack.controller.interfaces
{
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
	
	public interface IRtRemoteService
	{
		function getAthleteByUser(user: User) : AsyncToken;
		function saveRun(run: Run) : AsyncToken;
		function saveShoe(shoe: Shoe) : AsyncToken;
		function deleteRun(run: Run) : AsyncToken;
		function undoDeleteRun(run: Run) : AsyncToken;
		function saveAthlete(athlete: Athlete) : AsyncToken;
		function getRunsPage(page:RunsPage) : AsyncToken; 
		function saveUser(user:User) : AsyncToken;
		function getAthleteShoes(athlete:Athlete) : AsyncToken ;
		function saveShoes(shoes : Array) : AsyncToken;
		function deleteAndUpdateShoes(shoes : Array) : AsyncToken;
		function authenticateUser(userName : String, password : String) :AsyncToken ;
		function downloadMyRuns(athlete: Athlete) : AsyncToken;
		function getMonthQuery(monthQuery : MonthQuery) : AsyncToken;
		function saveGoal(goal:Goal) : AsyncToken;
		function saveTrainingPlan(trainingPlan : TrainingPlan) : AsyncToken;
		function getAthleteTrainingPlans(athlete:Athlete) : AsyncToken ;
		function getPlannedRuns(trainingPlan : TrainingPlan) : AsyncToken;
		function createUserWithDefaultAthlete(emailAsUsername : String, password : String)  : AsyncToken;
		function getBestRuns(query: BestRunsQuery) : AsyncToken;
		function getHealthHistory(query: AthleteHealthQuery) : AsyncToken;
		function uploadWatchData(athlete:Athlete, compressedData : String) : AsyncToken;
		function getActivities(query: ActivityQuery) : AsyncToken;
	}
}