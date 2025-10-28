using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Dominio.Filtros;
using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion del repositorio de Denuncio con operaciones especificas
    /// </summary>
    public class DenuncioRepositorio : IDenuncioRepositorio
    {
        private readonly DenuncioDbContext _context;

        public DenuncioRepositorio(DenuncioDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Denuncio> Actualizar(Denuncio aggregate)
        {
            _context.Denuncios.Update(aggregate);
            await _context.SaveChangesAsync();
            return aggregate;
        }

        public async Task<Denuncio> Agregar(Denuncio aggregate)
        {
            await _context.Denuncios.AddAsync(aggregate);
            await _context.SaveChangesAsync();
            return aggregate;
        }

        public async Task<List<Denuncio>> Agregar(List<Denuncio> aggregate)
        {
            await _context.Denuncios.AddRangeAsync(aggregate);
            await _context.SaveChangesAsync();
            return aggregate;
        }

        public async Task<Denuncio> Buscar(FiltroDenuncio filtro)
        {
            var query = _context.Denuncios
                .Include(d => d.TipoDenuncio)
                .Include(d => d.ConfiguracionFormulario)
                .AsQueryable();

            if (filtro.Id > 0)
            {
                query = query.Where(d => d.Id == filtro.Id);
            }

            if (!string.IsNullOrEmpty(filtro.NumeroSeguimiento))
            {
                query = query.Where(d => d.NumeroSeguimiento == filtro.NumeroSeguimiento);
            }

            var resultado = await query.FirstOrDefaultAsync();

            if (resultado == null)
            {
                throw new InvalidOperationException("No se encontro el denuncio con los criterios especificados");
            }

            return resultado;
        }

        public async Task<List<Denuncio>> Buscarlista(FiltroDenuncio filtro)
        {
            var query = _context.Denuncios
                .Include(d => d.TipoDenuncio)
                .Include(d => d.ConfiguracionFormulario)
                .AsQueryable();

            if (filtro.Id > 0)
            {
                query = query.Where(d => d.Id == filtro.Id);
            }

            return await query.ToListAsync();
        }
   
        public async Task Eliminar(Denuncio aggregate)
        {
            _context.Denuncios.Remove(aggregate);
            await _context.SaveChangesAsync();
        }

        public async Task<Denuncio> Obtener(long id)
        {
            var denuncio = await _context.Denuncios
                .Include(d => d.TipoDenuncio)
                .Include(d => d.ConfiguracionFormulario)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (denuncio == null)
            {
                throw new InvalidOperationException($"No se encontro el denuncio con Id: {id}");
            }

            return denuncio;
        }
    }
}