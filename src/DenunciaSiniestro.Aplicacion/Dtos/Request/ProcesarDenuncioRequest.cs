namespace DenunciaSiniestro.Aplicacion.Dtos.Request
{
    public class ProcesarDenuncioRequest
    {
        public long TipoDenuncio { get; set; }
        /// <summary>
        /// Valores
        /// </summary>
        public Dictionary<string, InputRequest> Valores { get; set; } = default!;
    }
}
