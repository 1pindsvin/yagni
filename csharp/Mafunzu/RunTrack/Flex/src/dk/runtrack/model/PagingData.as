package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.PagingData" )]
	public class PagingData
	{
		public function PagingData()
		{
			_totalCount = Constants.ITEM_COUNT_NOT_RESOLVED;
		}

		private var _pageSize:int;

		public function get PageSize() : int
		{
			return _pageSize;
		}

		public function set PageSize(value:int) : void
		{
			_pageSize = value;
		}

		private var _pageOffset:int;

		public function get PageOffset() : int
		{
			return _pageOffset;
		}

		public function set PageOffset(value:int) : void
		{
			_pageOffset = value;
		}

		private var _totalCount:int;

		public function get TotalCount() : int
		{
			return _totalCount;
		}

		public function set TotalCount(value:int) : void
		{
			_totalCount = value;
		}

		private var _requestsLastPage:Boolean;

		public function get RequestsLastPage() : Boolean
		{
			return _requestsLastPage;
		}

		public function set RequestsLastPage(value:Boolean) : void
		{
			_requestsLastPage = value;
		}

	}
}