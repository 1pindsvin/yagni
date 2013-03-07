package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.BestRunsQuery;
	import dk.runtrack.presentationmodels.interfaces.IBestRunsPresentationModel;
	
	import mx.collections.ArrayList;
	import mx.collections.IList;
	
	public class DummyBestRunsPresentationModel implements IBestRunsPresentationModel
	{
		public static var calls : Object= {};

		private var _from : Date;
		private var _to : Date;

		public function DummyBestRunsPresentationModel()
		{
		}
		
		public function get distance():String
		{
			return null;
		}
		
		public function set distance(value:String):void
		{
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
		
		public function get dateRanges():IList
		{
			return null;
		}
		
		public function set dateRanges(value:IList):void
		{
		}
		
		public function search():void
		{
		}
		
		public function setQuery(query:BestRunsQuery):void
		{
			calls.setQuery = 1;
		}
	}
}