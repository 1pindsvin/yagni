using System;
using System.Linq;

namespace DataService.DataAccess
{
    public class Pager<T>
    {
        private readonly IQueryable<T> _items;
        private readonly int _page;
        private readonly int _itemCount;
        private readonly int _start;

        private bool _resolveLastPage;
        public int PageOffset { get; private set; }

        public int TotalCount
        {
            get { return _itemCount; }
        }

        public Pager(IQueryable<T> items, int proposedStart, int page)
            : this(items, proposedStart, page, false)
        {

        }

        public Pager(IQueryable<T> items, int proposedStart, int page, bool resolveLastPage)
        {
            _items = items;
            _itemCount = items.Count();
            _start = proposedStart;
            _page = page;
            _resolveLastPage = resolveLastPage;
        }

        public IQueryable<T> GetPagedItems()
        {
            var count = _itemCount;
            if (count==0)
            {
                //Hack: Error in LINQ actually this if statement is only needed when IQueryable is SQL-table
                PageOffset = 0;
                return new T []{}.AsQueryable();
            }
            PageOffset = _start;
            if (PageOffset >= count)
            {
                _resolveLastPage = true;
            }
            if (_resolveLastPage)
            {
                PageOffset = (count / _page) * _page;
                if (PageOffset == count)
                {
                    PageOffset = count - _page;
                }
            }
            return _items.Skip(PageOffset).Take(_page);
        }

    }
}