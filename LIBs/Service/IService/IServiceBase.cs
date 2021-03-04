using System;
using System.Collections.Generic;

namespace LIBs.Service.IService
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T obj);
        void AddAsync(T obj);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
        void Dispose();
        void DetachLocal(Func<T, bool> predicate);
    }
}
