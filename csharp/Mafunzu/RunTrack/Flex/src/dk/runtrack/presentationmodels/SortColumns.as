package dk.runtrack.presentationmodels
{
	public class SortColumns
	{

		private var _sortColumns : Array;
		public function SortColumns(sortColumns : Array)
		{
			var map : Function = 
				function(columnName:String, index:int, array:Array) : SortColumn 
				{	
					return new SortColumn(columnName);
				};
			_sortColumns = sortColumns.map(map);
			_sortColumn = _sortColumns[0];
		}
		
		private var _sortColumn : SortColumn;
		public function get sortColumn() : SortColumn
		{
			return _sortColumn;
		}
		
		
		public function setSortColumn(columnName:String) : void
		{
			for each(var column : SortColumn in _sortColumns)
			{
				if(column.columnName==columnName)
				{
					column.sortOrder *= -1;
					_sortColumn = column;
					return;
				}
			}
			throw new Error("Column not found [" + columnName + "]");
		}

	}
}