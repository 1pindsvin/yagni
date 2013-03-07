package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.ActivityQuery" )]
	public class ActivityQuery
	{
		public function ActivityQuery()
		{
			Items = new Array();
		}

		private var _after:Date;

		public function get After() : Date
		{
			return _after;
		}

		public function set After(value:Date) : void
		{
			_after = value;
		}

		private var _before:Date;

		public function get Before() : Date
		{
			return _before;
		}

		public function set Before(value:Date) : void
		{
			_before = value;
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

		private var _items:Array;

		public function get Items() : Array
		{
			return _items;
		}

		public function set Items(value:Array) : void
		{
			_items = value;
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

	}
}
