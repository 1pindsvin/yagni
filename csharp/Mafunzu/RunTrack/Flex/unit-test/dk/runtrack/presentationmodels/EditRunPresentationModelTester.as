package dk.runtrack.presentationmodels
{
	import dk.runtrack.io.CookieAdapter;
	import dk.runtrack.model.DummyClient;
	import dk.runtrack.model.interfaces.IClientModel;
	import dk.runtrack.model.Athlete;
	import dk.runtrack.model.Run;
	import dk.runtrack.model.Shoe;
	import dk.runtrack.resources.Resources;
	
	import flexunit.framework.TestCase;
	
	import mx.collections.ArrayList;

	public class EditRunPresentationModelTester extends TestCase
	{
		public function EditRunPresentationModelTester(methodName:String=null)
		{
			super(methodName);
			EditRunPresentationModel.getClient = function() : IClientModel
			{
				return new DummyClient();
			}			

		}
		
		override public function setUp():void
		{
			Resources.setup();
			super.setUp();
		}
		
		override public function tearDown():void
		{
			super.tearDown();
			Resources.tearDown();
		}
		
		public function testConstructorShouldSetLoadingState() : void
		{
			var e : EditRunPresentationModel = new EditRunPresentationModel();
			assertEquals(EditRunPresentationModel.STATE_LOADING, e.state);
		} 

		private static const SAVED_ATHLETE_ID : int = 1;
		private var _testAthlete : Athlete;
		private function resolveTestAthlete() : Athlete
		{
			if(!_testAthlete)
			{
				var athlete : Athlete =  new Athlete();
				athlete.ID = SAVED_ATHLETE_ID;
				_testAthlete = athlete;				
			}
			return _testAthlete;			
		}


		private function buildEditRunPresentaionModelWithAthleteAndEmptyShoes() : EditRunPresentationModel
		{
			var e : EditRunPresentationModel = new EditRunPresentationModel();
			e.currentathlete = resolveTestAthlete();
			e.setAthleteShoes( new Array());
			return e;			
		}

		
		public function testSetAthleteAndShoesShouldSetReadyState() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			assertEquals(EditRunPresentationModel.STATE_READY, e.state);
		} 
		
		public function testWhenRequriedDataSetShouldSetCanSaveRunState() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			e.startDate = new Date();
			e.kilometers = "10";
			
			assertEquals(EditRunPresentationModel.STATE_CAN_SAVE_RUN, e.state);
		} 

		private function buildValidPersistentRun() : Run
		{
			var run : Run = new Run();
			run.ID = SAVED_ATHLETE_ID;
			run.Athlete = resolveTestAthlete();
			return run;
		} 
		
		public function testWhenEditRunSetShouldSetCanSaveRunState() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();

			e.editRun = buildValidPersistentRun();
			
			assertEquals(EditRunPresentationModel.STATE_CAN_SAVE_RUN, e.state);
		} 

		public function testSaveShouldSetTrySaveRunState() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			e.startDate = new Date();
			e.kilometers = "10";
			assertEquals(EditRunPresentationModel.STATE_CAN_SAVE_RUN, e.state);
			
			e.save();			
			
			assertEquals(EditRunPresentationModel.STATE_TRY_SAVE_RUN, e.state);
		} 

		public function testSaveExistingRunShouldSetTrySaveExistingRunState() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			e.editRun = buildValidPersistentRun();
			

			e.save();			
			
			assertEquals(EditRunPresentationModel.STATE_TRY_SAVE_EXISTING_RUN, e.state);
		} 

		public function testWhenDefaultShoesAreSetSetsSelectedIndex() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			assertEquals(0, e.selectedIndex);
			var selectedShoe : Shoe = e.athleteShoes.getItemAt(e.selectedIndex) as Shoe;
			assertEquals(Shoe.NULL_SHOE_ID, selectedShoe.ID);			
		}

		private function createShoe(id : int, brand : String)  : Shoe
		{
			var shoe : Shoe = new Shoe()
			shoe.ID = id;
			shoe.Brand = brand;
			shoe.Active = true;
			return shoe;			
		}

		private function createEditRun(id : int, meter : int, shoe : Shoe) : Run
		{
			var run : Run = new Run();
			run.ID = id;
			run.Distance = meter;
			run.Shoe = shoe;
			run.Athlete = _testAthlete;
			return run;
		}
		
		public function testWhenEditRunIsSetSetsSelectedIndex() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			var shoe : Shoe = createShoe(1, "gryffe");
			e.athleteShoes.addItem(shoe);
			var editRun : Run = createEditRun(1, 1, shoe);
						
			assertEquals(0, e.selectedIndex);
			
			e.editRun = editRun;
			
						
			assertEquals(1, e.selectedIndex);
		}

		public function testContainsShoe() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			var shoe : Shoe = createShoe(1, "gryffe");
			e.athleteShoes.addItem(shoe);
			
			assertTrue(e.containsShoe(shoe));
		}
		
		public function testWhenShoeIsSelectedAndShoesUpdatedShouldSetSelectedShoeIndex() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			var shoe : Shoe = createShoe(1, "gryffe");
			e.athleteShoes.addItem(shoe);
			e.selectedIndex = 1;

			var shoesFromServer : Array = new Array();
			shoesFromServer.push(shoe);

			e.setAthleteShoes(shoesFromServer);
			assertEquals(1, e.selectedIndex);
		}

		public function testWhenAthleteShoesAreSetSetsSelectedIndex() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			var shoe : Shoe = createShoe(1, "gryffe");
			e.athleteShoes.addItem(shoe);
			var editRun : Run = createEditRun(1, 1, shoe);
			
			e.editRun = editRun;

			
			var shoesFromServer : Array = new Array();
			shoesFromServer.push(shoe);
			
			assertEquals(1, e.selectedIndex) 
			e.athleteShoes = new ArrayList(shoesFromServer);
			assertEquals(1, e.selectedIndex) 
			
		}
		
		public function testWhenSelectedShoeHasBeenDeletedShouldSelectNullShoe() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();
			var shoe : Shoe = createShoe(1, "gryffe");
			e.athleteShoes.addItem(shoe);

			e.selectedIndex = 1;
			
			var shoesFromServer : Array = new Array();
			
			assertEquals(1, e.selectedIndex) 

			e.setAthleteShoes(shoesFromServer);

			assertEquals(0, e.selectedIndex) 
		}
		
		public function testWhenPreferedShoeExistsShouldFindPreferedShoe() : void
		{
			var e : EditRunPresentationModel = buildEditRunPresentaionModelWithAthleteAndEmptyShoes();

			var preferedShoeID : int = 1;
			var preferedShoe : Shoe = createShoe(preferedShoeID, "gryffe");
			var shoesFromServer : Array = new Array();
			shoesFromServer.push(preferedShoe);

			new CookieAdapter().lastSavedShoeID = preferedShoeID; 
			e.setAthleteShoes(shoesFromServer);
			
			var findShoe : Shoe = e.findPreferedShoe();
			
			assertNotNull(findShoe);
		}

		
		
	}
}