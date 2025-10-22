namespace DenunciaSiniestro.Infraestructura.Persistencia.Modelo
{
    /// <summary>
    /// Entidad que representa la configuracion JSON del formulario asociado a un tipo de denuncio
    /// </summary>
    public class ConfiguracionFormulario
    {
        public int IdConfiguracion { get; set; }
        public int IdTipoDenuncio { get; set; }
        public string EstructuraJson { get; set; } = string.Empty;
        public int Version { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        // Relaciones
        public virtual TipoDenuncio TipoDenuncio { get; set; } = null!;
        public virtual ICollection<Denuncio> Denuncios { get; set; } = new List<Denuncio>();
    }
}
