using System;
using System.Linq;

namespace DataService.Model
{
    public interface IDataContext : IDisposable
    {
        IQueryable<T> Queryable<T>() where T : class;

        void InsertOnSubmit<T>(T instance) where T : class;

        void DeleteOnSubmit<T>(T instance) where T : class;

        void RollbackAndAttach<T>(T instance) where T : class;

        void UpdateAndAttach<T>(T instance) where T : class;

        T GetExisting<T>(T instance) where T : class;

        void Commit();
    }
}