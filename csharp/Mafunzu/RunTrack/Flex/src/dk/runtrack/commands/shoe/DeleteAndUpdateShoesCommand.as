package dk.runtrack.commands.shoe
{
	import dk.runtrack.commands.RtCommand;
	import dk.runtrack.responders.SaveShoesResponder;
	
	import mx.rpc.IResponder;

	public class DeleteAndUpdateShoesCommand extends RtCommand
	{
		public static var resolveResponder : Function = function() : IResponder
		{
			return new SaveShoesResponder();
		}

		private var _dbShoeOperations : Array;
		public function DeleteAndUpdateShoesCommand(dbShoeOperations : Array)
		{
			super();
			_dbShoeOperations = dbShoeOperations;
		}
		
		
		public override function execute():void
		{
			this.responder = resolveResponder();
			dispatch(remoteService.deleteAndUpdateShoes(_dbShoeOperations));
		}
	}
}