namespace DenunciaSiniestro.Infraestructura.Persistencia.Modelo
{
    /// <summary>
    /// Entidad que representa un denuncio de siniestro registrado en el sistema
    /// </summary>
    public class Denuncio
    {
        public int IdDenuncio { get; set; }
        public int IdTipoDenuncio { get; set; }
        public int IdConfiguracion { get; set; }
        public string NumeroSiniestro { get; set; } = string.Empty;
        public DateTime FechaDenuncio { get; set; }
        public string NombreDenunciante { get; set; } = string.Empty;
        public string TelefonoDenunciante { get; set; } = string.Empty;
        public string DatosBasicos { get; set; } = string.Empty;
        public string RespuestasFormulario { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Relaciones
        public virtual TipoDenuncio TipoDenuncio { get; set; } = null!;
        public virtual ConfiguracionFormulario ConfiguracionFormulario { get; set; } = null!;
    }
}
