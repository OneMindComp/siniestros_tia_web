using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Dominio.Filtros;
using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion del repositorio de ConfiguracionFormulario con operaciones especificas
    /// </summary>
    public class ConfiguracionFormularioRepositorio : IConfiguracionFormularioRepositorio
    {
        private readonly DenuncioDbContext _context;

        public ConfiguracionFormularioRepositorio(DenuncioDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ConfiguracionFormulario> Buscar(FiltroConfiguracionFormulario filtro)
        {
            var query = _context.ConfiguracionesFormulario
                .Include(c => c.TipoDenuncio)
                .AsQueryable();

            if (filtro.Id > 0)
            {
                query = query.Where(c => c.Id == filtro.Id);
            }

            if (filtro.IdTipoDenuncio > 0)
            {
                query = query.Where(c => c.IdTipoDenuncio == filtro.IdTipoDenuncio);
            }

            var resultado = await query.FirstOrDefaultAsync();

            if (resultado == null)
            {
                throw new InvalidOperationException("No se encontro la configuracion de formulario con los criterios especificados");
            }

            return resultado;
        }

        public async Task<List<ConfiguracionFormulario>> Buscarlista(FiltroConfiguracionFormulario filtro)
        {
            var query = _context.ConfiguracionesFormulario
                .Include(c => c.TipoDenuncio)
                .AsQueryable();

            if (filtro.Id > 0)
            {
                query = query.Where(c => c.Id == filtro.Id);
            }

            if (filtro.IdTipoDenuncio > 0)
            {
                query = query.Where(c => c.IdTipoDenuncio == filtro.IdTipoDenuncio);
            }

            return await query.ToListAsync();
        }

       
    }
}