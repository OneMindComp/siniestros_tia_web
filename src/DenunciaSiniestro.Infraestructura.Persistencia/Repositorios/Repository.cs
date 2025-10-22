using Microsoft.EntityFrameworkCore;
using DenunciaSiniestro.Infraestructura.Persistencia.Contexto;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces;
using System.Linq.Expressions;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion generica del repositorio que proporciona operaciones CRUD basicas
    /// </summary>
    /// <typeparam name="T">Tipo de entidad</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DenuncioDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DenuncioDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T?> ObtenerPorId(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> ObtenerTodos(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicado).ToListAsync(cancellationToken);
        }

        public virtual async Task<T?> PrimerOPredeterminado(Expression<Func<T, bool>> predicado, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(predicado, cancellationToken);
        }

        public virtual async Task<T> Agregar(T entidad, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entidad, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entidad;
        }

        public virtual async Task AgregarVarios(IEnumerable<T> entidades, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entidades, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Actualizar(T entidad, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entidad);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Eliminar(T entidad, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entidad);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task EliminarPorId(int id, CancellationToken cancellationToken = default)
        {
            var entidad = await ObtenerPorId(id, cancellationToken);
            if (entidad != null)
            {
                await Eliminar(entidad, cancellationToken);
            }
        }

        public virtual async Task<bool> Existe(Expression<Func<T, bool>> predicado, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicado, cancellationToken);
        }

        public virtual async Task<int> Contar(Expression<Func<T, bool>>? predicado = null, CancellationToken cancellationToken = default)
        {
            return predicado == null
                ? await _dbSet.CountAsync(cancellationToken)
                : await _dbSet.CountAsync(predicado, cancellationToken);
        }
    }
}
