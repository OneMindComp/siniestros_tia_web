using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Dominio.Filtros;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion del repositorio de ConfiguracionFormularioModelo con operaciones especificas
    /// </summary>
    public class ConfiguracionFormularioRepositorio : IConfiguracionFormularioRepositorio
    {
        public Task<Dominio.Entidades.ConfiguracionFormulario> Buscar(FiltroConfiguracionFormulario filtro)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dominio.Entidades.ConfiguracionFormulario>> Buscarlista(FiltroConfiguracionFormulario filtro)
        {
            throw new NotImplementedException();
        }

        public Task<Dominio.Entidades.ConfiguracionFormulario?> ObtenerActivaPorTipoDenuncio(int idTipoDenuncio)
        {
            throw new NotImplementedException();
        }
    }
}



