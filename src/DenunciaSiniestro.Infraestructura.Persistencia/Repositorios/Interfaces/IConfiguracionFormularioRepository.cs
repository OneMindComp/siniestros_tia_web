using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces
{
    /// <summary>
    /// Interfaz especifica para el repositorio de ConfiguracionFormulario con operaciones adicionales
    /// </summary>
    public interface IConfiguracionFormularioRepository : IRepository<ConfiguracionFormulario>
    {
        /// <summary>
        /// Obtiene la configuracion activa de un tipo de denuncio
        /// </summary>
        Task<ConfiguracionFormulario?> ObtenerActivaPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene todas las versiones de configuracion de un tipo de denuncio
        /// </summary>
        Task<IEnumerable<ConfiguracionFormulario>> ObtenerVersionesPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene una version especifica de configuracion
        /// </summary>
        Task<ConfiguracionFormulario?> ObtenerPorTipoDenuncioYVersion(int idTipoDenuncio, int version, CancellationToken cancellationToken = default);

        /// <summary>
        /// Desactiva todas las configuraciones de un tipo de denuncio
        /// </summary>
        Task DesactivarConfiguracionesPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default);
    }
}
