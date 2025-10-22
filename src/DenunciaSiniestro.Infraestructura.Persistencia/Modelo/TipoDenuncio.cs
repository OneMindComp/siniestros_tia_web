namespace DenunciaSiniestro.Infraestructura.Persistencia.Modelo
{
    /// <summary>
    /// Entidad que representa el catalogo de tipos de siniestros disponibles en el sistema
    /// </summary>
    public class TipoDenuncio
    {
        public int IdTipoDenuncio { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string UrlPath { get; set; } = string.Empty;
        public string IconoUrl { get; set; } = string.Empty;
        public bool Activo { get; set; }

        // Relaciones
        public virtual ICollection<ConfiguracionFormulario> ConfiguracionesFormulario { get; set; } = new List<ConfiguracionFormulario>();
        public virtual ICollection<Denuncio> Denuncios { get; set; } = new List<Denuncio>();
    }
}
