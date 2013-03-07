using System;
using System.Collections;
using System.Collections.Generic;

namespace DataService.Model
{
    public class SimpleGoaledSequencer<T> : ISequencer<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly T _goalDistance;
        private readonly ISequencer<T> _innerSequencer;
        private readonly int _repeatTrainingDistance;
        private readonly T _restituteDistance;

        private Action _advanceAction;
        private int _count;
        private T _current;
        private bool _isMore;
        private T _lastTrainingDistance;

        public SimpleGoaledSequencer(
            T goalDistance,
            T lastTrainingDistance,
            T restituteDistance,
            int repeat,
            IComparer<T> comparer,
            ISequencer<T> sequencer)
        {
            if (sequencer == null)
            {
                throw new ArgumentNullException("sequencer");
            }
            if (repeat <= 0)
            {
                throw new InvalidOperationException("repeat<=0");
            }
            var compare = comparer.Compare(goalDistance, lastTrainingDistance);
            if (compare < 0)
            {
                throw new InvalidOperationException("goalDistance<=lastTrainingDistance");
            }
            _goalDistance = goalDistance;
            _lastTrainingDistance = lastTrainingDistance;
            _restituteDistance = restituteDistance;
            _repeatTrainingDistance = repeat;
            _comparer = comparer;
            _innerSequencer = sequencer;
            Reset();
        }

        #region ISequencer<T> Members

        public void Reset()
        {
            _innerSequencer.Reset();
            _advanceAction = AdvanceByInnerSequence;
            _isMore = true;
            _count = 0;
            _current = default(T);
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            _advanceAction();
            return _isMore;
        }

        public T Current
        {
            get { return _current; }
        }

        public void Dispose()
        {
        }

        #endregion

        private void AdvanceByInnerSequence()
        {
            _innerSequencer.MoveNext();
            _current = _innerSequencer.Current;

            var compare = _comparer.Compare(_current, _lastTrainingDistance);
            var switchAdvanceStrategy = compare >= 0;
            if (!switchAdvanceStrategy)
            {
                return;
            }
            _lastTrainingDistance = _current;
            _advanceAction = AdvanceByLastTrainingDistance;
            _advanceAction();
        }

        private void AdvanceByLastTrainingDistance()
        {
            _count += 1;
            if (_count <= _repeatTrainingDistance)
            {
                _current = _lastTrainingDistance;
            }
            else if (_count == _repeatTrainingDistance + 1)
            {
                _current = _goalDistance;
            }
            else
            {
                _isMore = false;
            }
        }
    }
}