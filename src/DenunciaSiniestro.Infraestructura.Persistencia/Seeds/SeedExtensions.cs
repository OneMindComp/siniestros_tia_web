using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Seeds
{
    /// <summary>
    /// Extensiones para aplicar los seeders al modelo
    /// </summary>
    internal static class SeedExtensions
    {
        /// <summary>
        /// Aplica todos los seeders al ModelBuilder
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de Entity Framework</param>
        public static void ApplySeeds(this ModelBuilder modelBuilder)
        {
            // Aplicar cada seeder en orden de dependencias
            new TipoDenuncioSeed().Seed(modelBuilder);
            new ConfiguracionFormularioSeed().Seed(modelBuilder);
            new DenuncioSeed().Seed(modelBuilder);
        }
    }
}
