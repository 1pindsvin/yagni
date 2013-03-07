package dk.runtrack.layouts
{
	import mx.core.ILayoutElement;
	
	import spark.components.supportClasses.GroupBase;
	import spark.layouts.TileLayout;
	
	
	public class MonthViewLayout extends TileLayout
	{
		private static const HORISONTAL_GAB: int = 0;
		private static const COLUMN_COUNT : int = 7;
		private static const ROW_COUNT : int = 6;

		public function MonthViewLayout()
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
			if(count < COLUMN_COUNT * ROW_COUNT)
			{
				return ;
			}

			var columnWidth : Number = (containerWidth -(COLUMN_COUNT*HORISONTAL_GAB)) / COLUMN_COUNT;
			var rowHeight : Number = containerHeight / ROW_COUNT;
			
			var x:Number = 0;
			var y:Number = 0;
			
			var current : int = 0;
			for(var row: int = 0;row < ROW_COUNT; row++)
			{
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
				y += rowHeight;
				x=0;
			}
		}
		
		
	}
}