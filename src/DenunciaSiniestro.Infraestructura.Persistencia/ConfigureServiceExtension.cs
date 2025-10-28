using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Lib.VaultOc;

namespace DenunciaSiniestro.Infraestructura.Persistencia
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddPersistenciaInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<VaultInfraestructuraMySql>(options => configuration.GetSection(nameof(VaultInfraestructuraMySql)).Bind(options));

            VaultInfraestructuraMySql vaultInfraestructuraMySql = configuration.GetSection(nameof(VaultInfraestructuraMySql)).Get<VaultInfraestructuraMySql>() ?? throw new Sbins.Comunes.Excepciones.InfraestructureException($"No se ha podido encontrar {nameof(VaultInfraestructuraMySql)} en appsettings.json");
            string connectionStringMySql = VaultHelper.ObtenerSecretVault(vaultInfraestructuraMySql!.UrlBase, vaultInfraestructuraMySql.NombreRecurso, vaultInfraestructuraMySql.Secrets.ConnectionString);

            configuration["connectionStringMySql"] = connectionStringMySql;
            services.AddDbContext<DenuncioDbContext>(options =>
            {
                options.UseMySQL(connectionStringMySql);
            },
            ServiceLifetime.Scoped);


            // Registrar repositorios
            services.AddScoped<IConfiguracionFormularioRepositorio, ConfiguracionFormularioRepositorio>();
            services.AddScoped<IDenuncioRepositorio, DenuncioRepositorio>();

            return services;
        }
    }
}
