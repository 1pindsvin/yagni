package dk.runtrack.presentationmodels.interfaces
{
	import dk.runtrack.model.BestRunsQuery;
	
	import mx.collections.IList;

	[Bindable]
	public interface IBestRunsPresentationModel
	{
		function get distance() : String;
		function set distance(value:String) : void;
		
		function set from(v:Date) : void;
		function get from() : Date;
		
		function set to(v:Date) : void;
		function get to() : Date;
		
		function search() : void;

		function setQuery(query : BestRunsQuery) : void;
	}
}
