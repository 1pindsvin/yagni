package dk.runtrack.view.components
{
	import spark.components.HGroup;
	import mx.events.CalendarLayoutChangeEvent;

	[Event(name="change", type="mx.events.CalendarLayoutChangeEvent")]
	public class DateTimeGroup extends HGroup
	{
		public function DateTimeGroup()
		{
			super();
		}
	}
}