package dk.runtrack.io
{
	import dk.runtrack.model.Shoe;
	
	import flexunit.framework.TestCase;

	public class PersistentObjectTester extends TestCase
	{
		public function PersistentObjectTester(methodName:String=null)
		{
			super(methodName);
		}
		
		public function  testItemEqualsItemSetFromConstructor() : void
		{
			var shoe : Shoe = new Shoe();
			shoe.ID = 1;
			var e : PersistentObject = new PersistentObject(shoe);
			
			var shoeItem : Shoe = e.item as Shoe;
			assertEquals(shoe.ID, shoeItem.ID);
		}
		
		private static function constructorThrowsException(argument:Object) : Boolean
		{
			var throwsError : Boolean = true;
			try
			{
				var foo : PersistentObject = new PersistentObject(argument);
				throwsError = false;
			}
			catch(error:Error)
			{
			}
			return throwsError;				
		}		
		
		public function testWhenItemIsInvalidShouldThrowException() : void
		{
			var item : Object = null;
			assertTrue(constructorThrowsException(item));
			var itemWithNoID : Object = new Object();
			assertTrue(constructorThrowsException(itemWithNoID));
			var itemWithZeroID : Object = {ID:0}
			assertTrue(constructorThrowsException(itemWithZeroID));
			var itemWithNegativeID : Object = {ID:-1}
			assertTrue(constructorThrowsException(itemWithZeroID));
		}
		
		public function testConstructorWithValidItem() : void
		{
			var itemWithValidID : Object = {ID:1}
			var e : PersistentObject = new PersistentObject(itemWithValidID);
			assertNotNull(e);				
		}		
	}
}