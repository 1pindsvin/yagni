package dk.runtrack.presentationmodels
{
	import dk.runtrack.commands.interfaces.IRtCommand;
	
	import flash.events.TimerEvent;
	import flash.utils.Timer;

	public class UndoTimer
	{
		private var _timer : Timer;
		private var _timeOutCommand : IRtCommand;

		public function UndoTimer(timeOutCommand : IRtCommand, delay : int)
		{
			
			const useCapture : Boolean = false;
			const useWeakReference : Boolean = false;
			const priority : int = 0;
			const repeatCount : int = 1;			

			_timer = new Timer(delay, 0);
			_timeOutCommand = timeOutCommand;
			_timer.addEventListener(TimerEvent.TIMER, timeoutHandler, useCapture, priority, useWeakReference);
		}

		public function start() : void
		{
			_timer.start();
		}

		public function stop() : void
		{
			_timer.reset();
		}

		private function timeoutHandler(event : TimerEvent) : void
		{
			stop();
			_timeOutCommand.execute();
		}

 		
	}
}