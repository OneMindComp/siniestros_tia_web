using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Infraestructura.Persistencia.Seeds;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Contexto
{
    /// <summary>
    /// Contexto de base de datos para la gestion de denuncias de siniestros
    /// </summary>
    public class DenuncioDbContext : DbContext
    {
        public DenuncioDbContext(DbContextOptions<DenuncioDbContext> options) : base(options)
        {
        }

        public DbSet<TipoDenuncio> TiposDenuncio { get; private set; } = null!;
        public DbSet<ConfiguracionFormulario> ConfiguracionesFormulario { get; private set; } = null!;
        public DbSet<Denuncio> Denuncios { get; private set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar todas las configuraciones de entidades
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DenuncioDbContext).Assembly);
            modelBuilder.ApplySeeds();
        }
    }
}
