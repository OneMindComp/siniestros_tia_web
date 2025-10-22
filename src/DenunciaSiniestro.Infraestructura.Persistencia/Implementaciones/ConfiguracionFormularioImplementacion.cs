using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Infraestructura.Persistencia.Repositorios.Interfaces;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Implementaciones
{
    public class ConfiguracionFormularioImplementacion : IConfiguracionFormularioRepositorio
    {
        private readonly IConfiguracionFormularioRepository _configuracionFormularioRepository;
        public ConfiguracionFormularioImplementacion(IConfiguracionFormularioRepository configuracionFormularioRepository)
        {
            _configuracionFormularioRepository = configuracionFormularioRepository;
        }
        public async Task<ConfiguracionFormulario?> ObtenerActivaPorTipoDenuncio(int idTipoDenuncio)
        {
            var resultado = await _configuracionFormularioRepository.ObtenerActivaPorTipoDenuncio(idTipoDenuncio);
            var configuracion = ConfiguracionFormulario.Crear(
                idConfiguracion:resultado!.IdConfiguracion,
                idTipoDenuncio:resultado.IdTipoDenuncio,
                estructuraJson:resultado.EstructuraJson,
                version: resultado.Version, 
                activo: resultado.Activo, 
                fechaCreacion: resultado.FechaCreacion, 
                fechaModificacion: resultado.FechaModificacion
                );
            return configuracion;
        }
    }
}
