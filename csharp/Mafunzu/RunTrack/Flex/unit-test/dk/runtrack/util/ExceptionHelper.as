package dk.runtrack.util
{
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class ExceptionHelper extends TestCase
	{

		public function ExceptionHelper()
		{
		}
		
		private function doesThrow() : void
		{
			throw new Error("Ok, I should throw ");
		}
		
		private function doesNotThrow():void
		{
		
		}
		
		public static function constructorWithArgumentTrowsException(clazz: Class, argument : Object) : Boolean
		{
			var throwsError : Boolean = true;
			try
			{
				var dummy : Object = new clazz(argument);
				throwsError = false;
			}
			catch(error:Error)
			{
			}
			return throwsError;				
			
		}
		
		public static function methodWithArgumentThrowsException(methodCall:Function, argument:Object) : Boolean
		{
			var throwsError : Boolean = true;
			try
			{
				methodCall(argument);
				throwsError = false;
			}
			catch(error:Error)
			{
			}
			return throwsError;				
		}		
		public static function methodThrowsException(methodCall:Function) : Boolean
		{
			var throwsError : Boolean = true;
			try
			{
				methodCall();
				throwsError = false;
			}
			catch(error:Error)
			{
			}
			
			return throwsError;				
		}
		
		public static function throwsException(instance:Object, methodCall:String) : Boolean
		{
			var actualMethod : Function = instance[methodCall];
			Assert.assertNotNull(actualMethod);	
			return methodThrowsException(actualMethod);				
		}

		public function testThrowsExceptionReturnsFalseWhenMethodDoesNotThrow() : void
		{
			var e:ExceptionHelper = new ExceptionHelper();
			var expected :Boolean = throwsException(e,"doesNotThrow");
			Assert.assertFalse(expected); 
		}

		public function testThrowsExceptionReturnsTrueWhenMethodDoesThrow() : void
		{
			var e:ExceptionHelper = new ExceptionHelper();
			var expected :Boolean = throwsException(e,"doesThrow");
			Assert.assertTrue(expected);
 
		}

		public function testThrowsExceptionWithID1069WhenMethodDoesNotExist() : void
		{
			var e:ExceptionHelper = new ExceptionHelper();
			var throwsError : Boolean = true;
			try
			{
				throwsException(e,"NonExstingFunction");
				throwsError = false;
			}
			catch(error:Error)
			{
				var message :String = 
					"Error #1069: Property NonExstingFunction not found on dk.runtrack.util.ExceptionHelper and there is no default value.";
				Assert.assertEquals(1069, error.errorID);
			}
			Assert.assertTrue(throwsError);			
		}
	}
}