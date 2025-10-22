using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using DenunciaSiniestro.Infraestructura.Persistencia.Implementaciones;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sbins.Comunes.Excepciones;
using Sbins.Lib.VaultOc;

namespace DenunciaSiniestro.Infraestructura.Persistencia
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection AddPersistenciaInfraestructura(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<VaultInfraestructuraMySql>(options => configuration.GetSection(nameof(VaultInfraestructuraMySql)).Bind(options));
            //VaultInfraestructuraMySql vaultInfraestructuraMySql = configuration.GetSection(nameof(VaultInfraestructuraMySql)).Get<VaultInfraestructuraMySql>() ?? throw new InfraestructureException($"No se ha podido encontrar {nameof(VaultInfraestructuraMySql)} en appsettings.json");
            //string connectionStringMySql = VaultHelper.ObtenerSecretVault(vaultInfraestructuraMySql!.UrlBase, vaultInfraestructuraMySql.NombreRecurso, vaultInfraestructuraMySql.Secrets.ConnectionString);

            //configuration["connectionStringMySql"] = connectionStringMySql;
            string connectionStringMySql = "Server=localhost;Database=denuncio_siniestro;User=root;Password=your_password;";
            services.AddDbContext<DenuncioDbContext>(options =>
            {
                options.UseMySQL(connectionStringMySql);
            });

            // Registrar repositorios
            services.AddScoped<ITipoDenuncioRepository, TipoDenuncioRepository>();
            services.AddScoped<IConfiguracionFormularioRepository, ConfiguracionFormularioRepository>();
            services.AddScoped<IDenuncioRepository, DenuncioRepository>();

            //Puertos y adaptadores
            services.AddScoped<IConfiguracionFormularioRepositorio, ConfiguracionFormularioImplementacion>();

            // Registrar repositorio generico si es necesario
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }
    }
}
