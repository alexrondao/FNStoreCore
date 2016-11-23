using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;

namespace FNStore.Infra.Data.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FNStoreDataContext context) : base(context)
        { }
    }
}
