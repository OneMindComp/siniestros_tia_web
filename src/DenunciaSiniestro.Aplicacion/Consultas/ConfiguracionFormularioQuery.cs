using System.Text.Json;
using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Dominio.Entidades;
using Sbins.Mediador.Abstracciones;

namespace PasarelaPago.Aplicacion.Consultas
{
    /// <summary>
    /// Obtiene configuracion de formulario web.
    /// </summary>
    public class ConfiguracionFormularioQuery : IRequest<ConfiguracionFormulario>
    {
        /// <summary>
        /// Establece el parametro de consulta para obtener configuracion.
        /// </summary>
        public int TipoDenuncio { get; set; } = default!;

    }

    /// <summary>
    /// Maneja la logica para obtener configuracion de formulario web.
    /// </summary>
    public class ConfiguracionFormularioQueryHandler : IRequestHandler<ConfiguracionFormularioQuery, ConfiguracionFormulario>
    {
        private readonly IConfiguracionFormularioRepositorio _formularioRepositorio;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="formularioRepositorio"></param>
        public ConfiguracionFormularioQueryHandler(
            IConfiguracionFormularioRepositorio formularioRepositorio)
        {
            _formularioRepositorio = formularioRepositorio;
        }

        /// <summary>
        /// Implementa la logica para obtener configuracion de formulario web.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ConfiguracionFormulario> Handle(
            ConfiguracionFormularioQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var formulario = await _formularioRepositorio.Buscar(new DenunciaSiniestro.Dominio.Filtros.FiltroConfiguracionFormulario() {IdTipoDenuncio= request.TipoDenuncio });

                if (formulario == null || formulario.EstructuraJson == null)
                {
                    throw new Sbins.Comunes.Excepciones.ApplicationException("No se ha podido obtener configuracion de formulario web de Base de Datos");
                }

                ConfiguracionFormulario? formularioSecciones  = JsonSerializer.Deserialize<ConfiguracionFormulario>(formulario!.EstructuraJson!);
                formulario!.AsignarSecciones(formularioSecciones!.Secciones);

                return formulario!;
            }
            catch (Exception ex)
            {
                throw new Sbins.Comunes.Excepciones.ApplicationException(ex.Message, ex);
            }
        }
    }
}
