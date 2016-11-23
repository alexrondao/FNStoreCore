using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Contracts.Transaction;
using FNStore.Infra.Data.EF;
using FNStore.Infra.Data.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FNStore.Infra.CrossCutting.IoC
{
    public class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped(typeof(FNStoreDataContext));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddTransient(typeof(IUsuarioRepository), typeof(UsuarioRepository));
        }
    }
}
