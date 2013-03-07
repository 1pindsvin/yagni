package dk.runtrack.presentationmodels
{
	public class Pager
	{
		public static const PAGE_SIZE_DEFAULT : uint = 10; 

		private var _pageSize : uint;
		private var _start : int;
		public function Pager(pageSize: uint)
		{
			_pageSize = pageSize;
			_start = 0;
		}
		
		public function get numberOfItems() : uint
		{
			return _pageSize;
		}
		
		public function get start() : uint
		{
			return _start;
		}
		
		public function setStartFromServer(startResolvedServerside : uint) : void
		{
			_start = startResolvedServerside;
		}
		
		public function moveNext() : void
		{
			_start+=_pageSize;
		}
		
		public function movePrevious() : void
		{
			_start-=_pageSize;
			if(_start < 0)
			{
				_start = 0;
			} 
		}
		
		public function moveFirst() : void
		{
			_start = 0;
		}

		public static const MAGIC_LAST_PAGE : int = int.MAX_VALUE;
		public function moveLast() : void
		{
			_start = MAGIC_LAST_PAGE;
		}
	}
}