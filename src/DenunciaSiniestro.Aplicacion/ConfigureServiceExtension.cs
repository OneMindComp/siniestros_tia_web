using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Mediador.DependencyInjection;

namespace DenunciaSiniestro.Aplicacion
{
    /// <summary>
    /// Configura servicios de la capa aplicacion.
    /// </summary>
    public static class ConfigureServiceExtension
    {
        /// <summary>
        /// Agrega servicios de aplicacion al contenedor de servicios.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddAplicacion(this IServiceCollection services)
        {
            services.AddMediador(config =>
            {

                // Obtener el ensamblado actual
                var assembly = Assembly.GetExecutingAssembly();

                // Registrar handlers de un ensamblado específico
                config.AddHandlersFromAssembly(assembly);
            });

            return services;
        }
    }
}
