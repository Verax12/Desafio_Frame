using LIBs.Infra.Context;
using LIBs.Repository.IRepositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIBs.Repository
{
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        private readonly ProjetoContext _context;

        public RepositoryBase(ProjetoContext context)
        {
            _context = context;
        }

        /// Verifico se foi salvo com sucesso
        public virtual void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public virtual async void AddAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
                    _context.SaveChanges();
        }


        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual void DetachLocal(Func<T,bool> predicate)
        {
            var local = _context.Set<T>().Local.Where(predicate).FirstOrDefault();
            if(local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

        }
    }
}
