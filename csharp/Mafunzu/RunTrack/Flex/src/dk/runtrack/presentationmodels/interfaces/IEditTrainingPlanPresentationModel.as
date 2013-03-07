package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.TrainingPlan;
	
	import mx.collections.IList;

	[Bindable]
	public interface IEditTrainingPlanPresentationModel
	{
		function get intensity() : int;
		function set intensity(value:int) : void;
		
		function get skill() : int;
		function set skill(value:int) : void;
		
		function get goalKilometers() : String;
		function set goalKilometers(value:String) : void;
		
		function get preferredWeekdays() : int;
		function set preferredWeekdays(value:int) : void;
		
		function get start() : Date;
		function set start(value:Date) : void;
		
		function get workload() : int;
		function set workload(value:int) : void;
		
		function get startDistance() : String;
		function set startDistance(value:String) : void;
		
		function get selectedIndex() : int;
		function set selectedIndex(value:int) : void;
		
		function get canSave() : Boolean;
		function set canSave(value:Boolean) : void;
		
		function get trainingPlan() : TrainingPlan;
		function set trainingPlan(value:TrainingPlan) : void;
		
		function get trainingPlans() : IList;
		function set trainingPlans(value:IList) : void;

		function setTrainingPlans(plans:Array) : void;
		
		function save() : void;

	} 
}