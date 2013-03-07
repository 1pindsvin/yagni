package dk.runtrack.commands.shoe
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.model.Constants;
	import dk.runtrack.responders.SaveShoesResponder;
	
	import mx.rpc.IResponder;

	public class SaveShoesCommand extends RtCommand
	{
		public static var resolveResponder : Function = function() : IResponder
		{
			return new SaveShoesResponder();
		}
		
		private var _shoes : Array;
		public function SaveShoesCommand(shoes : Array)
		{
			super();
			if(shoes.length==0)
			{
				throw new Error(Constants.INVALIDOPERATIONEXCEPTION);
			}
			_shoes = shoes;
		}
		
		public override function execute():void
		{
			this.responder = resolveResponder();
			dispatch(remoteService.saveShoes(_shoes));
		}
	}
}