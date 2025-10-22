using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces
{
    /// <summary>
    /// Interfaz especifica para el repositorio de TipoDenuncio con operaciones adicionales
    /// </summary>
    public interface ITipoDenuncioRepository : IRepository<TipoDenuncio>
    {
        /// <summary>
        /// Obtiene todos los tipos de denuncio activos
        /// </summary>
        Task<IEnumerable<TipoDenuncio>> ObtenerActivos(CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene un tipo de denuncio por su URL path
        /// </summary>
        Task<TipoDenuncio?> ObtenerPorUrlPath(string urlPath, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene un tipo de denuncio con sus configuraciones
        /// </summary>
        Task<TipoDenuncio?> ObtenerConConfiguraciones(int id, CancellationToken cancellationToken = default);
    }
}
