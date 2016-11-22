using FNStore.Domain.Contracts.Repositories;
using FNStore.Infra.Data.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FNStore.Infra.CrossCutting.IoC
{
    public class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {

            //services.AddScoped(typeof(IRepository<Cliente>), typeof(Repository<Cliente>));
            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));
        }
    }
}
