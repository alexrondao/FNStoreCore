using FNStore.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FNStore.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    //var resolver = opt.SerializerSettings.ContractResolver;
                    //if (resolver != null)
                    //{
                    //    var res = resolver as DefaultContractResolver;
                    //    res.NamingStrategy = null;  // <<!-- this removes the camelcasing
                    //}

                    var jsonSettings = opt.SerializerSettings;
                    jsonSettings.Formatting = Formatting.Indented;
                    jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddSingleton(Configuration);
            IoCConfiguration.Configure(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = ctx => ctx.Response.WriteAsync("Algo errado")
                });
            }

            app.UseMvcWithDefaultRoute();
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Página não encontrada!");
            });

        }
    }
}
