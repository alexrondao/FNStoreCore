using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FNStore.Infra.Data.EF.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly FNStoreDataContext _context;
        public Repository(FNStoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>();
        }

        public T Get(Guid key)
        {
            return _context.Set<T>().Find(key);
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
