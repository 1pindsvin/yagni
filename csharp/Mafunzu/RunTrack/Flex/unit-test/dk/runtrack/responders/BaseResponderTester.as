package dk.runtrack.responders
{
	import dk.runtrack.controller.DummyPresentationModelLocator;
	import dk.runtrack.controller.PresentationModelLocator;
	import dk.runtrack.controller.interfaces.IPresentationModelLocator;
	
	import flexunit.framework.Assert;
	import flexunit.framework.TestCase;

	public class BaseResponderTester extends TestCase
	{
		public function BaseResponderTester(methodName:String=null)
		{
			super(methodName);
			PresentationModelLocator.resolveInnerViewModelLocator = 
				function() : IPresentationModelLocator
				{
					return new DummyPresentationModelLocator();
				}
		}
		
		
		public function testConstructor() : void
		{
			var e : BaseResponder = new BaseResponder();
			Assert.assertNotNull(e);
		}		
	}
}