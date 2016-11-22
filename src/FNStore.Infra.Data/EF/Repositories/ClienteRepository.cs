using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FNStore.Infra.Data.EF.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(FNStoreDataContext context) : base(context)
        { }

        public IEnumerable<Cliente> GetByName(string nome)
        {
            return _context.Clientes.Where(c => c.Nome.Contains(nome));
        }
    }
}
