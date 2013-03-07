package dk.runtrack.presentationmodels
{
	import dk.runtrack.presentationmodels.interfaces.IRunChartPresentationModel;
	
	public dynamic class DummyRunChartPresentationModel implements IRunChartPresentationModel
	{
		public static var calls : Object= {};
		
		public function DummyRunChartPresentationModel()
		{
		}
		
		public function get state():String
		{
			return null;
		}
		
		public function set state(value:String):void
		{
		}
		
		public function get runs():Array
		{
			return null;
		}
		
		public function set runs(value:Array):void
		{
		}
		
		public function setRuns(runs:Array):void
		{
			calls.setRuns = 1;			
		}
		
	}
}