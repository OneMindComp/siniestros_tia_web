using System.Linq.Expressions;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces
{
    /// <summary>
    /// Interfaz generica que define las operaciones CRUD basicas para los repositorios
    /// </summary>
    /// <typeparam name="T">Tipo de entidad</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene una entidad por su identificador
        /// </summary>
        Task<T?> ObtenerPorId(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        Task<IEnumerable<T>> ObtenerTodos(CancellationToken cancellationToken = default);

        /// <summary>
        /// Busca entidades que cumplan con un criterio
        /// </summary>
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene una unica entidad que cumpla con un criterio
        /// </summary>
        Task<T?> PrimerOPredeterminado(Expression<Func<T, bool>> predicado, CancellationToken cancellationToken = default);

        /// <summary>
        /// Agrega una nueva entidad
        /// </summary>
        Task<T> Agregar(T entidad, CancellationToken cancellationToken = default);

        /// <summary>
        /// Agrega multiples entidades
        /// </summary>
        Task AgregarVarios(IEnumerable<T> entidades, CancellationToken cancellationToken = default);

        /// <summary>
        /// Actualiza una entidad existente
        /// </summary>
        Task Actualizar(T entidad, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        Task Eliminar(T entidad, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina una entidad por su identificador
        /// </summary>
        Task EliminarPorId(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Verifica si existe una entidad que cumpla con un criterio
        /// </summary>
        Task<bool> Existe(Expression<Func<T, bool>> predicado, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cuenta las entidades que cumplen con un criterio
        /// </summary>
        Task<int> Contar(Expression<Func<T, bool>>? predicado = null, CancellationToken cancellationToken = default);
    }
}
