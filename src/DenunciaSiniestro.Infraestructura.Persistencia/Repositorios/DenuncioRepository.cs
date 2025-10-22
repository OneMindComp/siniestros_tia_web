using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion del repositorio de Denuncio con operaciones especificas
    /// </summary>
    public class DenuncioRepository : Repository<Denuncio>, IDenuncioRepository
    {
        public DenuncioRepository(DenuncioDbContext context) : base(context)
        {
        }

        public async Task<Denuncio?> ObtenerPorNumeroSiniestro(string numeroSiniestro, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(d => d.TipoDenuncio)
                .Include(d => d.ConfiguracionFormulario)
                .FirstOrDefaultAsync(d => d.NumeroSiniestro == numeroSiniestro, cancellationToken);
        }

        public async Task<IEnumerable<Denuncio>> ObtenerPorEstado(string estado, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(d => d.TipoDenuncio)
                .Where(d => d.Estado == estado)
                .OrderByDescending(d => d.FechaDenuncio)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Denuncio>> ObtenerPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(d => d.TipoDenuncio)
                .Include(d => d.ConfiguracionFormulario)
                .Where(d => d.IdTipoDenuncio == idTipoDenuncio)
                .OrderByDescending(d => d.FechaDenuncio)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Denuncio>> ObtenerPorRangoFechas(DateTime fechaInicio, DateTime fechaFin, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(d => d.TipoDenuncio)
                .Where(d => d.FechaDenuncio >= fechaInicio && d.FechaDenuncio <= fechaFin)
                .OrderByDescending(d => d.FechaDenuncio)
                .ToListAsync(cancellationToken);
        }

        public async Task<Denuncio?> ObtenerConRelaciones(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(d => d.TipoDenuncio)
                .Include(d => d.ConfiguracionFormulario)
                    .ThenInclude(c => c.TipoDenuncio)
                .FirstOrDefaultAsync(d => d.IdDenuncio == id, cancellationToken);
        }

        public async Task ActualizarEstado(int id, string nuevoEstado, CancellationToken cancellationToken = default)
        {
            var denuncio = await ObtenerPorId(id, cancellationToken);
            if (denuncio != null)
            {
                denuncio.Estado = nuevoEstado;
                denuncio.FechaActualizacion = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
