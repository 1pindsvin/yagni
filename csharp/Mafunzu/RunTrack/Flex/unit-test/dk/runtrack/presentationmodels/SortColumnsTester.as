package dk.runtrack.presentationmodels
{
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class SortColumnsTester extends TestCase
	{
		public function SortColumnsTester(methodName:String=null)
		{
			super(methodName);
		}
		
		private function build() : SortColumns
		{
			return new SortColumns(
				["id", "distance", "time", "((distance*1000/time)*3.6)", "startutc"]);
		}
		
		public function testConstructor() : void
		{
			var e : SortColumns = build();
			Assert.assertNotNull(e.sortColumn);
		}
		
		public function testSortOnCanSetSelectedSortColumn() : void
		{
			var e : SortColumns = build();
			for each(var columnName : String in ["id", "time", "distance"])
			{
				e.setSortColumn(columnName);
				Assert.assertEquals(columnName, e.sortColumn.columnName);				
			} 
		}

		public function testSortOnSwitchesSortDirection() : void
		{
			var e : SortColumns = build();
			var columnName : String = "id";
			e.setSortColumn(columnName);
			var sortIndex : int = e.sortColumn.sortOrder;
			e.setSortColumn(columnName);
			Assert.assertEquals(sortIndex*-1, e.sortColumn.sortOrder);
		}

	}
}