namespace DenunciaSiniestro.Dominio
{
    public class TipoDenuncio
    {
        public int Id { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public string UrlPath { get; set; } = default!;
        public string IconoUrl { get; set; } = default!;
        public bool Activo { get; set; } = default!;

    }
}
