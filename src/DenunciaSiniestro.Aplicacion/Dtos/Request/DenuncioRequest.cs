namespace DenunciaSiniestro.Aplicacion.Dtos.Request
{
    public class DenuncioRequest
    {
        public int TipoDenuncio { get; set; }
        /// <summary>
        /// Valores
        /// </summary>
        public Dictionary<string, InputRequest> Valores { get; set; } = default!;
    }
}
