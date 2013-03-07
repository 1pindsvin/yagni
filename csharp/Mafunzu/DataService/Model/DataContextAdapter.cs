using System;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;

namespace DataService.Model
{
    public class DataContextAdapter : IDataContext
    {
        private DbDataContext _context;
        private bool _disposed;

        public DataContextAdapter(DbDataContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (_context == null)
            {
                _context = context;
            }
            if (_context.Connection.State != ConnectionState.Open)
            {
                _context.Connection.Open();
            }
        }

        public static string ConnectionString { get; set; }

        public static DataContextAdapter Default
        {
            get { return new DataContextAdapter(new DbDataContext(ConnectionString)); }
        }

        #region IDataContext Members

        public IQueryable<T> Queryable<T>() where T : class
        {
            return _context.GetTable<T>();
        }

        public void InsertOnSubmit<T>(T instance) where T : class
        {
            _context.GetTable<T>().InsertOnSubmit(instance);
        }

        public void DeleteOnSubmit<T>(T instance) where T : class
        {
            _context.GetTable<T>().DeleteOnSubmit(instance);
        }

        public void RollbackAndAttach<T>(T instance) where T : class
        {
            _context.GetTable<T>().Attach(instance, false);
        }

        public void UpdateAndAttach<T>(T instance) where T : class
        {
            _context.GetTable<T>().Attach(instance, true);
        }

        public T GetExisting<T>(T instance) where T : class
        {
            return Queryable<T>().Where(x => x.Equals(instance)).Single();
        }

        public void Commit()
        {
            _context.SubmitChanges();
        }

        #endregion

        ~DataContextAdapter()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (_disposed)
            {
                return;
            }
            if (disposeManagedResources)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}