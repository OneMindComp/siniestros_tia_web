using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces
{
    /// <summary>
    /// Interfaz especifica para el repositorio de Denuncio con operaciones adicionales
    /// </summary>
    public interface IDenuncioRepository : IRepository<Denuncio>
    {
        /// <summary>
        /// Obtiene un denuncio por su numero de siniestro
        /// </summary>
        Task<Denuncio?> ObtenerPorNumeroSiniestro(string numeroSiniestro, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene denuncios por estado
        /// </summary>
        Task<IEnumerable<Denuncio>> ObtenerPorEstado(string estado, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene denuncios por tipo de denuncio
        /// </summary>
        Task<IEnumerable<Denuncio>> ObtenerPorTipoDenuncio(int idTipoDenuncio, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene denuncios por rango de fechas
        /// </summary>
        Task<IEnumerable<Denuncio>> ObtenerPorRangoFechas(DateTime fechaInicio, DateTime fechaFin, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene un denuncio con todas sus relaciones
        /// </summary>
        Task<Denuncio?> ObtenerConRelaciones(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Actualiza el estado de un denuncio
        /// </summary>
        Task ActualizarEstado(int id, string nuevoEstado, CancellationToken cancellationToken = default);

        /// <summary>
        /// Crea un nuevo denuncio
        /// </summary>
        Task<Denuncio> Crear(Denuncio denuncio, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edita un denuncio existente
        /// </summary>
        Task<Denuncio?> Editar(Denuncio denuncio, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina un denuncio por su ID
        /// </summary>
        Task<bool> Eliminar(int id, CancellationToken cancellationToken = default);
    }
}
