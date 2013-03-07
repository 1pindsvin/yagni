package dk.runtrack.presentationmodels
{
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class PagerTester extends TestCase
	{
		public function PagerTester(methodName:String=null)
		{
			super(methodName);
		}
		
		public function testConstructor() : void
		{
			var e : Pager = new Pager(10);
			Assert.assertEquals(0, e.start);
			Assert.assertEquals(10, e.numberOfItems);
		} 

		public function testNextPageExpectsIncrementStartWithPageSize() : void
		{
			var e : Pager = new Pager(10);
			e.moveNext();
			Assert.assertEquals(10, e.start);
			Assert.assertEquals(10, e.numberOfItems);
		} 

		public function testPreviousPageDecrementStartWithPageSize() : void
		{
			var e : Pager = new Pager(10);
			e.moveNext();
			e.moveNext();
			Assert.assertEquals(20, e.start);
			Assert.assertEquals(10, e.numberOfItems);
			
			e.movePrevious();
			Assert.assertEquals(10, e.start);
			Assert.assertEquals(10, e.numberOfItems);
			
		} 
		
		public function testPreviousPageCannotGoBelowZero() : void
		{
			var e : Pager = new Pager(10);
			e.movePrevious();
			Assert.assertEquals(0, e.start);
			Assert.assertEquals(10, e.numberOfItems);
		} 
		
		
	}
}