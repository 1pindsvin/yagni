package dk.runtrack.model
{
	import dk.runtrack.presentationmodels.Pager;

	[RemoteClass( alias="DataService.Model.AthleteHealthQuery" )]
	public class AthleteHealthQuery
	{
		public function AthleteHealthQuery()
		{
			_pagingData = new dk.runtrack.model.PagingData();
			_pagingData.PageSize = Pager.PAGE_SIZE_DEFAULT;
		}

		private var _pagingData:dk.runtrack.model.PagingData;

		public function get PagingData() : dk.runtrack.model.PagingData
		{
			return _pagingData;
		}

		public function set PagingData(value:dk.runtrack.model.PagingData) : void
		{
			_pagingData = value;
		}

		private var _athlete:dk.runtrack.model.Athlete;

		public function get Athlete() : dk.runtrack.model.Athlete
		{
			return _athlete;
		}

		public function set Athlete(value:dk.runtrack.model.Athlete) : void
		{
			_athlete = value;
		}

		private var _athleteHealthHistory:Array;

		public function get AthleteHealthHistory() : Array
		{
			return _athleteHealthHistory;
		}

		public function set AthleteHealthHistory(value:Array) : void
		{
			_athleteHealthHistory = value;
		}

		public function hasLoadedServerData() : Boolean
		{
			return _pagingData.TotalCount != Constants.ITEM_COUNT_NOT_RESOLVED;	
		}
		
	}
}