package dk.runtrack.layouts
{
	import mx.core.ILayoutElement;
	
	import spark.components.supportClasses.GroupBase;
	import spark.layouts.TileLayout;
	
	public class WeekDayLayout extends TileLayout
	{
		private static const HORISONTAL_GAB: int = 0;
		private static const COLUMN_COUNT : int = 7;
		private static const ROW_COUNT : int = 1;
		
		public function WeekDayLayout()
		{
			super();
			requestedColumnCount = COLUMN_COUNT;
			requestedRowCount = ROW_COUNT;
		}
		
		override public function updateDisplayList(containerWidth:Number,
												   containerHeight:Number):void
		{
			var layoutTarget:GroupBase = target;
			var count:int = layoutTarget.numElements;
			if(count< COLUMN_COUNT)
			{
				return ;
			}

			var columnWidth : Number = (containerWidth -(COLUMN_COUNT*HORISONTAL_GAB)) / COLUMN_COUNT;
			var x:Number = 0;
			const y:Number = 0;

			var current : int = 0;
			for (var column:int = 0; column < COLUMN_COUNT; column++)
			{
				var element:ILayoutElement = useVirtualLayout ? 
					layoutTarget.getVirtualElementAt(current) :
					layoutTarget.getElementAt(current);
				
				current++;
				
				element.setLayoutBoundsSize(NaN, NaN);
				
				element.setLayoutBoundsPosition(x, y);
				
				element.setLayoutBoundsSize(columnWidth, rowHeight);
				
				x += columnWidth + HORISONTAL_GAB;
			}
		}
		
		
		
	}
}