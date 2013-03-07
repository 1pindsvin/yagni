using System;
using System.Collections;

namespace DataService.Model
{
    public class Sequencer<T> : ISequencer<T>
    {
        private readonly int _pauseAfter;
        private readonly Func<T, T> _progressionCalculator;
        private readonly int _repeat;
        private readonly T _start;

        private int _advance;
        private int _count;
        private T _current;
        private T _currentPause;
        private T _next;
        private T _nextAdvance;

        public Sequencer(T start, int repeat, int pauseAfter, Func<T, T> progressionCalculator)
        {
            if (repeat <= 0)
            {
                throw new InvalidOperationException("int repeat");
            }
            _start = start;
            _repeat = repeat;
            _pauseAfter = pauseAfter;
            _progressionCalculator = progressionCalculator;

            Reset();
        }

        #region ISequencer<T> Members

        public void Reset()
        {
            _next = _start;
            _current = _start;
            _nextAdvance = _start;
            _currentPause = _start;
            _count = 0;
            _advance = 1;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            Advance();
            return true;
        }

        public T Current
        {
            get { return _current; }
        }

        public void Dispose()
        {
        }

        #endregion

        private void Advance()
        {
            _count++;
            _current = _next;

            var doAdvance = _count%_repeat == 0;
            if (!doAdvance)
            {
                return;
            }

            _advance++;
            var nextAdvance = _progressionCalculator(_nextAdvance);

            var isPause = _advance%(_pauseAfter + 1) == 0;
            if (isPause)
            {
                _next = _currentPause;
                _currentPause = nextAdvance;
            }
            else
            {
                _next = nextAdvance;
                _nextAdvance = nextAdvance;
            }
        }
    }
}