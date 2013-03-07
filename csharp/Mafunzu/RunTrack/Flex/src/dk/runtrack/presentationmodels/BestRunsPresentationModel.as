package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.run.GetBestRunsCommand;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.events.RunTrackEvent;
	import dk.runtrack.model.BestRunsQuery;
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.DistanceFormatter;
	import dk.runtrack.presentationmodels.interfaces.IBestRunsPresentationModel;
	
	import mx.collections.IList;
	
	public class BestRunsPresentationModel implements IBestRunsPresentationModel
	{

		private var _query : BestRunsQuery;
		private var _distance : String;
		private var _dateRanges : IList;
		private var _from : Date;
		private var _to : Date;
		
		public function BestRunsPresentationModel()
		{
			_query = new BestRunsQuery();
		}
		
		public function get distance():String
		{
			return _distance;
		}
		
		public function set distance(value:String):void
		{
			_distance = value;
		}
		
		
		public function set from(v:Date) : void
		{
			_from = v;
		}
		
		public function get from() : Date
		{
			return _from;
		}
		
		public function set to(v:Date) : void
		{
			_to = v;
		}
		
		public function get to() : Date
		{
			return _to;
		}
		
		
		public function search():void
		{
			if(!_distance)
			{
				return;
			}
			_query.Athlete = new PresentationModelLocator().editAthletePresentationModel.currentathlete;
			_query.Runs = [];
			_query.After = from;
			_query.Before = to;
			var distanceFormatter : DistanceFormatter = new DistanceFormatter();
			var km : int = distanceFormatter.toDatabaseDistance(_distance);
			_query.DistanceMaximum = km;
			_query.DistanceMinimum = km;
			_query.NumberOfRunsToFetch = 10;
			var findRunsCommand : GetBestRunsCommand = new GetBestRunsCommand(_query);
			new RunTrackEvent(findRunsCommand).dispatch();
		}
		
		public function setQuery(query:BestRunsQuery):void
		{
			_query = query;
		}
	}
}