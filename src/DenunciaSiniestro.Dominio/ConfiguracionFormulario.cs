namespace DenunciaSiniestro.Dominio
{
    public class ConfiguracionFormulario
    {
        public int Id { get; set; }
        public TipoDenuncio TipoDenuncio { get; set; } = default!;
        public string EstructuraJson { get; set; } = default!;
        public int Version { get; set; } = default!;
        public bool Activo { get; set; } = default!;
        public DateTime FechaCreacion { get; set; } = default!;
        public DateTime FechaModificacion { get; set; } = default!;
        public List<Seccion> Secciones { get; set; } = new List<Seccion>();
    }
}
