using System.Text.Json;
using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Dominio.Entidades;
using Sbins.Mediador.Abstracciones;

namespace PasarelaPago.Aplicacion.Consultas
{
    /// <summary>
    /// Obtiene denuncios.
    /// </summary>
    public class DenuncioQuery : IRequest<Denuncio?>
    {
        /// <summary>
        /// Establece el parametro de consulta para obtener un denuncio.
        /// </summary>
        public string NumeroSeguimiento { get; set; } = default!;

    }

    /// <summary>
    /// Maneja la logica para obtener denuncios.
    /// </summary>
    public class DenuncioQueryHandler : IRequestHandler<DenuncioQuery, Denuncio?>
    {
        private readonly IDenuncioRepositorio _denuncioRepositorio;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="denuncioRepositorio"></param>
        public DenuncioQueryHandler(
            IDenuncioRepositorio denuncioRepositorio)
        {
            _denuncioRepositorio = denuncioRepositorio;
        }

        /// <summary>
        /// Implementa la logica para obtener denuncios.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Denuncio?> Handle(
            DenuncioQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var denuncio = await _denuncioRepositorio.Obtener(request.NumeroSeguimiento);
                return denuncio;
            }
            catch (Exception)
            {
                throw new Sbins.Comunes.Excepciones.ApplicationException("No se ha podido obtener productos suscritos");
            }
        }
    }
}
