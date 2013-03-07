using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using NUnit.Framework;

namespace DataService.Model
{


    public class InMemoryDataContext : IDataContext
    {
        class CommitableObject
        {
            public bool Deleted;
            public bool Commited;
            public Object Instance;
        }

        private readonly List<CommitableObject> _inMemoryDataStore = new List<CommitableObject>();

        private int _nextID;
        private bool _disposed;

        public InMemoryDataContext()
        {
            _nextID = 1;
        }

        public int NextID
        {
            get { return _nextID++; }
        }

        private IQueryable GetQueryableFor(Type type)
        {

            var result = (_inMemoryDataStore.
                Where(obj => type.IsAssignableFrom(obj.Instance.GetType())).
                Select(obj => obj.Instance)).
                AsQueryable();

            return result;
        }

        public IQueryable<T> Queryable<T>() where T : class
        {
            return GetQueryableFor(typeof(T)).Cast<T>();
        }

        public void InsertOnSubmit<T>(T instance) where T : class
        {
            _inMemoryDataStore.Add(new CommitableObject {Instance = instance });
        }

        public void DeleteOnSubmit<T>(T instance) where T : class
        {
            var searchedItem = _inMemoryDataStore.Where(x => x.Instance.Equals(instance)).FirstOrDefault();
            searchedItem.Deleted = true;
            Assert.IsNotNull(searchedItem);
        }

        public void RollbackAndAttach<T>(T instance) where T : class
        {
            ResolveExistingItemByIDOrObjectEquality(instance);
        }

        public void UpdateAndAttach<T>(T instance) where T : class
        {
            ResolveExistingItemByIDOrObjectEquality(instance);
        }

        public T GetExisting<T>(T instance) where T : class
        {
            return ResolveExistingItemByIDOrObjectEquality(instance);
        }

        private T ResolveExistingItemByIDOrObjectEquality<T>(T instance) where T : class
        {
            var itemsOfType = GetQueryableFor(typeof(T));
            T searchedItem = null;
            foreach (var item in itemsOfType)
            {
                if (HasSameIDOrObjectEquals(item, instance))
                {
                    searchedItem = (T)item;
                    break;
                }
            }
            if (searchedItem == null)
            {
                var message = string.Format("Searched type [{0}]. ResolveExistingItemByIDOrObjectEquality<T>(T instance) could not find an existing item.", typeof(T));
                throw new InstanceNotFoundException(message);
            }
            return searchedItem;
        }

        private static bool HasSameIDOrObjectEquals(object item, object other)
        {
            var itemIDPropertyInfo = item.GetType().GetProperty("ID");
            var otherIDpropertyInfo = other.GetType().GetProperty("ID");

            var itemID = (int)itemIDPropertyInfo.GetValue(item, null);
            var otherID = (int)otherIDpropertyInfo.GetValue(other, null);

            if (itemID == otherID && itemID != 0)
            {
                return true;
            }
            return item.Equals(other);
        }

        public void Commit()
        {
            _inMemoryDataStore.RemoveAll(x => x.Deleted);
            _inMemoryDataStore.ForEach(x => x.Commited = true);
            CommitCallCount++;
        }

        public int CommitCallCount { get; set; }

        public bool IsEmpty
        {
            get { return _inMemoryDataStore.Count == 0; }
        }

        public bool IsCommited<T>(T instance)
        {
            var searchedItem = _inMemoryDataStore.Where(x => HasSameIDOrObjectEquals(x.Instance, instance)).FirstOrDefault();
            return searchedItem.Commited;
        }

        public void Clear()
        {
            _inMemoryDataStore.Clear();
            CommitCallCount = 0;
        }

        public void Add<T>(T instance) where T : class
        {
            InsertOnSubmit(instance);
            Commit();
        }

        ~InMemoryDataContext()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            // process only if mananged and unmanaged resources have
            // not been disposed of.
            if (this._disposed)
            {
                return;
            }
            if (disposeManagedResources)
            {

            }
            _disposed = true;
        }



        public void Dispose()
        {
            Dispose(true);

            // tell the GC that the Finalize process no longer needs
            // to be run for this object.
            GC.SuppressFinalize(this);

        }


    }
}
