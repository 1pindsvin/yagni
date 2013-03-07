package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.DateTimeFormatter;
	import dk.runtrack.model.DistanceFormatter;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.TimeFormatter;
	
	public class RunDataGridViewItem
	{
		private var _run : Run;
		
		private static var _timeFormatter : TimeFormatter = new TimeFormatter();
		private static var _distanceFormatter : DistanceFormatter =  new DistanceFormatter();
		
		
		private static const TRAILING_DIGITS : uint = 2;

		
		public function RunDataGridViewItem(runDataSourceItem:Run)
		{
			_run = runDataSourceItem;
		}

		public function get id() : String
		{
			return _run.ID.toString();
		} 


		public function get time() : String
		{
			return   _timeFormatter.fromDatabaseTime(_run.Time);
		} 


		public function get distance() : String
		{
			var asNumber : Number = _distanceFormatter.fromDatabaseDistance(_run.Distance);
			var numberStr : String = _distanceFormatter.localeFormat(asNumber.toFixed(TRAILING_DIGITS)); 
			return numberStr; 
		} 
		
		public function get start() : String
		{
			return new DateTimeFormatter().toDateTimeString( _run.Start);			
		}
		
		public function get averageSpeed() : String
		{
			var runKm : Number = run.Distance/1000;
			var runMinuttes : Number = run.Time/60;
			var minutesPrKm : Number = runMinuttes/runKm;
			
			var wholeMinuttes : int = Math.floor(minutesPrKm);
			
			var fractionSeconds : int = Math.floor( 60 * (minutesPrKm - wholeMinuttes));
			
			var average : String = _distanceFormatter.toMinutesPrKilometer(wholeMinuttes, fractionSeconds);
			
 			return average;
 		}

		public function get run() : Run
		{
			return _run;
		}
	}
}