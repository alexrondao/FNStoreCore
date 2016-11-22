using FNStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FNStore.Domain.Contracts.Repositories
{
    public interface IRepository<T> : 
        IDisposable where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Save();

        IEnumerable<T> Get();
        T Get(Guid key);
    }
}