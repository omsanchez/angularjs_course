using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImproveIT.Data
{
    public interface IDataContext
    {
        bool IsInTransaction { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
        IList<T> GetAll<T>() where T : class, new();
        IList<T> GetByCriteria<T>(Query query) where T : class, new();
        IList<T> GetByObject<T>(Query query) where T : class, new();
        T GetById<T>(object id) where T : class, new();
        int GetCount<T>();
        int GetCount<T>(Query query);
        void Add(object item);
        void Add<T>(T item);
        void Delete(object item);
        void Delete<T>(T item);
        void Save(object item);
        void Save<T>(T item);
        void Dispose();
    }
}
