package dk.runtrack.presentationmodels
{
	public class SortColumn
	{
		public var columnName : String;
		public var sortOrder : int; 
		public function SortColumn(columnName: String)
		{
			this.columnName = columnName;
			sortOrder = -1;
		}

	}
}