using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion del repositorio de ConfiguracionFormulario con operaciones especificas
    /// </summary>
    public class ConfiguracionFormularioRepository : Repository<ConfiguracionFormulario>, IConfiguracionFormularioRepository
    {
        public ConfiguracionFormularioRepository(DenuncioDbContext context) : base(context)
        {
        }

        public async Task<ConfiguracionFormulario?> ObtenerActivaPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(c => c.TipoDenuncio)
                .FirstOrDefaultAsync(c => c.IdTipoDenuncio == idTipoDenuncio && c.Activo, cancellationToken);
        }

        public async Task<IEnumerable<ConfiguracionFormulario>> ObtenerVersionesPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(c => c.IdTipoDenuncio == idTipoDenuncio)
                .OrderByDescending(c => c.Version)
                .ToListAsync(cancellationToken);
        }

        public async Task<ConfiguracionFormulario?> ObtenerPorTipoDenuncioYVersion(int idTipoDenuncio, int version, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(c => c.TipoDenuncio)
                .FirstOrDefaultAsync(c => c.IdTipoDenuncio == idTipoDenuncio && c.Version == version, cancellationToken);
        }

        public async Task DesactivarConfiguracionesPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default)
        {
            var configuraciones = await _dbSet
                .Where(c => c.IdTipoDenuncio == idTipoDenuncio && c.Activo)
                .ToListAsync(cancellationToken);

            foreach (var config in configuraciones)
            {
                config.Activo = false;
                config.FechaModificacion = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
