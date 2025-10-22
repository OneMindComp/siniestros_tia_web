using DenunciaSiniestro.Aplicacion.Contratos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DenunciaSiniestro.Infraestructura.CoreSiniestro
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddCoreSiniestroInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDenuncioContract, DenuncioImplementacion>();
            services.AddHttpClient<ICoreSiniestrosApi, CoreSiniestrosApi>(cliente =>
            {
                cliente.BaseAddress = new Uri("https://localhost/4200");
            });

            return services;
        }
    }
}
