package dk.runtrack.io
{
	import flexunit.framework.TestCase;

	public class CookieAdapterTester extends TestCase
	{
		
		private var _fakeCookie : Object;
		private var _flushCallCount : int;
		
		private var _fakeCookieAdapterCreator : Function = function() : Object
		{
			 var fakeCookie : Object = new Object();
			fakeCookie.data = new Object();
			fakeCookie.flush = function() : void
			{
				_flushCallCount++;		
			}
			return fakeCookie;
		}
		
		public function CookieAdapterTester(methodName:String=null)
		{
			super(methodName);
		}

		private function doSetUp() : void
		{
			_fakeCookie = new Object();
			_fakeCookie.data = new Object();
			_fakeCookie.flush = function() : void
			{
				_flushCallCount++;		
			}
			_flushCallCount=0;
			CookieAdapter.cookie = _fakeCookie;
		}
				
		override public function setUp():void
		{
			super.setUp();
			doSetUp();
		}
		
		override public function tearDown():void
		{
			super.tearDown();
			CookieAdapter.cookie = null;
		}

		
		public function testConstructor() : void
		{
			var e : CookieAdapter = new CookieAdapter();
			assertNotNull(e);	
			assertEquals("", e.userName);
			assertEquals("", e.password);
			assertEquals(0, e.lastSavedShoeID);
		}
	
		public function testGetSetPassword() : void
		{
			var e : CookieAdapter = new CookieAdapter();
			_flushCallCount=0;
			var password : String = "gryffe";
			
			e.password = password;
			
			assertEquals(password, e.password)
			assertEquals(password, _fakeCookie.data.password)
			assertEquals(1, _flushCallCount);			
		}	

		public function testGetSetUserName() : void
		{
			var e : CookieAdapter = new CookieAdapter();
			_flushCallCount=0;
			var userName : String = "gryffe";
			
			e.userName = userName;
			
			assertEquals(userName, e.userName)
			assertEquals(userName, _fakeCookie.data.userName)
			assertEquals(1, _flushCallCount);			
		}	

		public function testGetSetlastSavedShoeID() : void
		{
			var e : CookieAdapter = new CookieAdapter();
			_flushCallCount=0;
			var lastSavedShoeID : int = 1;
			
			e.lastSavedShoeID = lastSavedShoeID;
			
			assertEquals(lastSavedShoeID, e.lastSavedShoeID)
			assertEquals(lastSavedShoeID, _fakeCookie.data.lastSavedShoeID)
			assertEquals(1, _flushCallCount);			
		}	

		public function subsequentCallsWithSameValueDoesNotCallFlush() : void
		{
			var e : CookieAdapter = new CookieAdapter();
			_flushCallCount=0;
			assertEquals(0, _flushCallCount);			
			
			e.lastSavedShoeID = 1;
			e.lastSavedShoeID = 1;
			
			assertEquals(1, _flushCallCount);			
		}
		
	}
}