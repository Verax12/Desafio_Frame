using System;
using System.Collections.Generic;
using System.Text;

namespace LIBs.Repository.IRepositoy
{
    public interface IRepositoryBase<T> where T : class
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
