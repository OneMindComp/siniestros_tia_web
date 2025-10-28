using System.Text.Json.Serialization;
using DenunciaSiniestro.Dominio.Enumeradores;

namespace DenunciaSiniestro.Aplicacion.Dtos.Response
{
    public class ProcesarDenuncioResponse
    {
        /// <summary>
        /// Response para procesar denuncio.
        /// </summary>
        public string NumeroSeguimiento { get; set; } = default!;
        public EstadoDenuncio Estado { get; set; }
    }
}
