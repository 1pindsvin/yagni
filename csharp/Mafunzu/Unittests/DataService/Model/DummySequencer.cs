using System.Collections;

namespace DataService.Model
{
    public class DummySequencer : ISequencer<int>
    {
        private int _current;

        public DummySequencer()
        {
            Reset();
        }

        #region ISequencer<int> Members

        public void Reset()
        {
            _current = 0;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            _current = GetNext();
            return true;
        }

        public int Current
        {
            get { return _current; }
        }

        public void Dispose()
        {
        }

        #endregion

        private int GetNext()
        {
            _current += 1;
            return _current;
        }
    }
}