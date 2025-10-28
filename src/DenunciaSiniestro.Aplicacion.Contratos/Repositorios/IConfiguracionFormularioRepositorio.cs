using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Dominio.Filtros;

namespace DenunciaSiniestro.Aplicacion.Contratos.Repositorios
{
    public interface IConfiguracionFormularioRepositorio : IRepositorioBusqueda<ConfiguracionFormulario, FiltroConfiguracionFormulario>
    {
        /// <summary>
        /// Obtiene la configuracion activa de un tipo de denuncio
        /// </summary>
        Task<ConfiguracionFormulario?> ObtenerActivaPorTipoDenuncio(int idTipoDenuncio);
    }
}
