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
            CoreSiniestroSettings coreSiniestroSettings = configuration.GetSection(nameof(CoreSiniestroSettings)).Get<CoreSiniestroSettings>() 
                ?? throw new Sbins.Comunes.Excepciones.InfraestructureException("No se ha podido realizar AddCoreSiniestroInfraestructura");

            services.AddScoped<IDenuncioContract, DenuncioImplementacion>();
            services.AddHttpClient<ICoreSiniestrosApi, CoreSiniestrosApi>(cliente =>
            {
                cliente.BaseAddress = new Uri(coreSiniestroSettings.BasePath);
            });

            return services;
        }
    }
}
