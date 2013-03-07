package dk.runtrack.model.validator
{
	import dk.runtrack.model.Constants;
	import dk.runtrack.model.Run;
	
	public class RunGraphValidator
	{
		private var _run : Run;
		public function RunGraphValidator(run:Run)
		{
			_run = run;
		}

		public function Validate() : void
		{
			if(operation==ObjectGraphValidator.CREATE)
			{
				if(_run.Athlete==null)
				{
					throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
				}
				if(_run.Shoe!=null)
				{
					if(_run.Shoe.Athlete==null)
					{
						throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
					}
				}
				return;
			}
						
		}
		
		private var _operation:String;

		public function get operation() : String
		{
			return _operation;
		} 

		public function set operation(value:String) : void
		{
			_operation = value;
		} 

	}
}