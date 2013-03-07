package dk.runtrack.presentationmodels
{
	import dk.runtrack.presentationmodels.interfaces.IRunChartPresentationModel;

	
	[Bindable]
	public class RunChartPresentationModel implements IRunChartPresentationModel
	{
		public function RunChartPresentationModel()
		{
			_runs = new Array();
			state = "Off";
		}
		
		private var _switchOnOff : Boolean;
		
		private var _state : String;
		
		public function get state():String
		{
			return _state;
		}
		
		public function set state(value:String):void
		{
			_state = value;
		}

		
		private var _runs:Array;
		
		public function get runs() : Array
		{
			return _runs;
		}
		
		public function set runs(value:Array) : void
		{
			_runs = value;
		}
		
		public function setRuns(runsArray:Array) : void
		{
			runs = runsArray;
			_switchOnOff = !_switchOnOff;
			state = _switchOnOff ? "On" : "Off"; 
		}
	}
}
