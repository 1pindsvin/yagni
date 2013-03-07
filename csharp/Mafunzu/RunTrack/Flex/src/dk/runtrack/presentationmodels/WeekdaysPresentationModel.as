package dk.runtrack.presentationmodels
{
	import dk.runtrack.model.WeekdaySelectionEnumeration;
	import dk.runtrack.presentationmodels.interfaces.IWeekdaysPresentationModel;

	[Bindable]
	public class WeekdaysPresentationModel implements IWeekdaysPresentationModel
	{
		private var _selectedDays : int;
		public function WeekdaysPresentationModel()
		{
			_selectedDays = 
				WeekdaySelectionEnumeration.FirstDayOfWeek |
				WeekdaySelectionEnumeration.SecondDayOfWeek |
				WeekdaySelectionEnumeration.ThirdDayOfWeek |
				WeekdaySelectionEnumeration.FourthDayOfWeek |
				WeekdaySelectionEnumeration.FifthDayOfWeek |
				WeekdaySelectionEnumeration.SixthDayOfWeek |
				WeekdaySelectionEnumeration.SeventhDayOfWeek;
		}

		
		public function get selectedDays() : int
		{
			return _selectedDays;
		} 
		
		
		public function set selectedDays(value:int) : void
		{
			firstDayOfWeekSelected = (value & WeekdaySelectionEnumeration.FirstDayOfWeek) > 0;
			secondDayOfWeekSelected = (value & WeekdaySelectionEnumeration.SecondDayOfWeek) > 0;
			thirdDayOfWeekSelected = (value & WeekdaySelectionEnumeration.ThirdDayOfWeek) > 0;
			fourthDayOfWeekSelected = (value & WeekdaySelectionEnumeration.FourthDayOfWeek) > 0;
			fifthDayOfWeekSelected = (value & WeekdaySelectionEnumeration.FifthDayOfWeek) > 0;
			sixthDayOfWeekSelected = (value & WeekdaySelectionEnumeration.SixthDayOfWeek) > 0;
			seventhDayOfWeekSelected = (value & WeekdaySelectionEnumeration.SeventhDayOfWeek) > 0;
		} 
		
		private function setSelection(weekdayEnumeration : int, value : Boolean) : void
		{
			if(value)
			{
				_selectedDays |= weekdayEnumeration;
			}
			else
			{
				_selectedDays ^= weekdayEnumeration;
			}
		}
		
		private function isSelected(weekdayEnumeration : int) : Boolean
		{
			return  (_selectedDays & weekdayEnumeration) == weekdayEnumeration;
		}
		
		public function get firstDayOfWeekSelected():Boolean
		{
			return isSelected(WeekdaySelectionEnumeration.FirstDayOfWeek);
		}

		public function set firstDayOfWeekSelected(value:Boolean):void
		{
			setSelection(WeekdaySelectionEnumeration.FirstDayOfWeek,value);
		}

		public function get secondDayOfWeekSelected():Boolean
		{
			return isSelected(WeekdaySelectionEnumeration.SecondDayOfWeek);
		}

		public function set secondDayOfWeekSelected(value:Boolean):void
		{
			setSelection(WeekdaySelectionEnumeration.SecondDayOfWeek,value);
		}

		public function get thirdDayOfWeekSelected():Boolean
		{
			return isSelected(WeekdaySelectionEnumeration.ThirdDayOfWeek);
		}

		public function set thirdDayOfWeekSelected(value:Boolean):void
		{
			setSelection(WeekdaySelectionEnumeration.ThirdDayOfWeek,value);
		}

		public function get fourthDayOfWeekSelected():Boolean
		{
			return isSelected(WeekdaySelectionEnumeration.FourthDayOfWeek);
		}
		
		public function set fourthDayOfWeekSelected(value:Boolean):void
		{
			setSelection(WeekdaySelectionEnumeration.FourthDayOfWeek,value);
		}

		public function get fifthDayOfWeekSelected():Boolean
		{
			return isSelected(WeekdaySelectionEnumeration.FifthDayOfWeek);
		}
		
		public function set fifthDayOfWeekSelected(value:Boolean):void
		{
			setSelection(WeekdaySelectionEnumeration.FifthDayOfWeek, value);
		}

		public function get sixthDayOfWeekSelected():Boolean
		{
			return isSelected(WeekdaySelectionEnumeration.SixthDayOfWeek);
		}
		
		public function set sixthDayOfWeekSelected(value:Boolean):void
		{
			setSelection(WeekdaySelectionEnumeration.SixthDayOfWeek, value);
		}

		public function get seventhDayOfWeekSelected():Boolean
		{
			return isSelected(WeekdaySelectionEnumeration.SeventhDayOfWeek);
		}

		public function set seventhDayOfWeekSelected(value:Boolean):void
		{
			setSelection(WeekdaySelectionEnumeration.SeventhDayOfWeek, value);
		}

	
	}
}