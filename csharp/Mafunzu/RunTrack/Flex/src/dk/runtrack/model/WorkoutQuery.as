package dk.runtrack.model
{
	[RemoteClass( alias="DataService.Model.WorkoutQuery" )]
	public class WorkoutQuery
	{
		public function WorkoutQuery()
		{
		}

		private var _pagingData:dk.runtrack.model.PagingData;
		public function get PagingData() : dk.runtrack.model.PagingData;
		{
			return _pagingData;
		}

		public function set PagingData(value:dk.runtrack.model.PagingData;) : void
		{
			_pagingData = value;
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

		private var _after:Date;

		public function get After() : Date
		{
			return _after;
		}

		public function set After(value:Date) : void
		{
			_after = value;
		}

		private var _athlete: dk.runtrack.model.Athlete;

		public function get Athlete() : dk.runtrack.model.Athlete
		{
			return _athlete;
		}

		public function set Athlete(value:dk.runtrack.model.Athlete) : void
		{
			_athlete = value;
		}

		private var _workoutTypes:int;

		public function get WorkoutTypes() : int
		{
			return _workoutTypes;
		}

		public function set WorkoutTypes(value:int) : void
		{
			_workoutTypes = value;
		}

		private var _workouts:Array;

		public function get Workouts() : Array
		{
			return _workouts;
		}

		public function set Workouts(value:Array) : void
		{
			_workouts = value;
		}

	}
}