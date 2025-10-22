using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion del repositorio de TipoDenuncio con operaciones especificas
    /// </summary>
    public class TipoDenuncioRepository : Repository<TipoDenuncio>, ITipoDenuncioRepository
    {
        public TipoDenuncioRepository(DenuncioDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TipoDenuncio>> ObtenerActivos(CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(t => t.Activo)
                .OrderBy(t => t.Nombre)
                .ToListAsync(cancellationToken);
        }

        public async Task<TipoDenuncio?> ObtenerPorUrlPath(string urlPath, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .FirstOrDefaultAsync(t => t.UrlPath == urlPath, cancellationToken);
        }

        public async Task<TipoDenuncio?> ObtenerConConfiguraciones(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Include(t => t.ConfiguracionesFormulario)
                .FirstOrDefaultAsync(t => t.IdTipoDenuncio == id, cancellationToken);
        }
    }
}
