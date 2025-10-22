using DenunciaSiniestro.Infraestructura.CoreSiniestro;
using DenunciaSiniestro.Infraestructura.Persistencia;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DenunciaSiniestro.Infraestructura
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenciaInfraestructura(configuration);
            services.AddCoreSiniestroInfraestructura(configuration);

            return services;
        }
    }
}
