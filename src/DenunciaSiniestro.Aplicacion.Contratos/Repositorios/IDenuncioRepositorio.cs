using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Dominio.Filtros;

namespace DenunciaSiniestro.Aplicacion.Contratos.Repositorios
{
    public interface IDenuncioRepositorio : IRepositorio<Denuncio, long>, IRepositorioBusqueda<Denuncio, FiltroDenuncio>
    {
        /// <summary>
        /// Crea un nuevo denuncio
        /// </summary>
        Task<Denuncio> Crear(Denuncio denuncio);

        /// <summary>
        /// Edita un denuncio existente
        /// </summary>
        Task<Denuncio?> Editar(Denuncio denuncio);

        /// <summary>
        /// Obtiene un denuncio existente por numero de seguimiento
        /// </summary>
        Task<Denuncio?> Obtener(string numeroSeguimiento);
    }
}
