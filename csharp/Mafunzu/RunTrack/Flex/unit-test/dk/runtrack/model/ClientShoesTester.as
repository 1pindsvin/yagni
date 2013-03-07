package dk.runtrack.model
{
	
	import dk.runtrack.io.PersistentObjectEvent;
	
	import flexunit.framework.TestCase;

	public class ClientShoesTester extends TestCase
	{
		public function ClientShoesTester(methodName:String=null)
		{
			super(methodName);
		}
		
		public function shoesUpdatedHandler(event:PersistentObjectEvent, extraData:Object) : void
		{
			assertEquals(1, extraData.count);
		}
		
		public function testWhenShoesAreLoadedShouldFireShoesUpdatedEvent() : void
		{
			var e : ClientModel = ClientModel.data;
			e.clear();
			
			e.addEventListener
				(
					PersistentObjectEvent.EVENT_SHOES_UPDATED, 
					addAsync(shoesUpdatedHandler, 2, {count:1}),
					false, 0, true
				);
			e.loadedShoes = [];
				
		}
		
		public function testLoadedshoesEqualsShoes() : void
		{
			var e : ClientModel = ClientModel.data;
			e.clear();
			
			e.loadedShoes = [];
			assertEquals(0, e.shoes.length);
			
			var shoe : Shoe = new Shoe();
			shoe.ID = 1;
			
			e.loadedShoes = [shoe];	
			
			assertEquals(1, e.shoes.length);
			
			var loadedShoe : Shoe;
			loadedShoe = e.shoes.pop() as Shoe;
			assertEquals(1, loadedShoe.ID);						
		}
		
		
	}
}