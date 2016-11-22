using FNStore.Domain.Entities;
using System.Collections.Generic;

namespace FNStore.Domain.Contracts.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> GetByName(string nome);
    }
}