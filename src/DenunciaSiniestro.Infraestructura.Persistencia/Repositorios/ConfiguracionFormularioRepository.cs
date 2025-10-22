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

        public async Task<ConfiguracionFormulario> Crear(ConfiguracionFormulario configuracion, CancellationToken cancellationToken = default)
        {
            configuracion.FechaCreacion = DateTime.UtcNow;
            configuracion.FechaModificacion = DateTime.UtcNow;

            await _dbSet.AddAsync(configuracion, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return configuracion;
        }

        public async Task<ConfiguracionFormulario?> Editar(ConfiguracionFormulario configuracion, CancellationToken cancellationToken = default)
        {
            var existe = await _dbSet.FindAsync(new object[] { configuracion.IdConfiguracion }, cancellationToken);

            if (existe == null)
                return null;

            configuracion.FechaModificacion = DateTime.UtcNow;

            _dbSet.Update(configuracion);
            await _context.SaveChangesAsync(cancellationToken);

            return configuracion;
        }

        public async Task<bool> Eliminar(int id, CancellationToken cancellationToken = default)
        {
            var configuracion = await _dbSet.FindAsync(new object[] { id }, cancellationToken);

            if (configuracion == null)
                return false;

            _dbSet.Remove(configuracion);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}



