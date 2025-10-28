using DenunciaSiniestro.Dominio.Entidades;

namespace DenunciaSiniestro.Dominio
{
    public class TipoDenuncio
    {
        public long Id { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public string UrlPath { get; set; } = default!;
        public string IconoUrl { get; set; } = default!;
        public bool Activo { get; set; } = default!;

        private TipoDenuncio(
            long id,
            string nombre,
            string descripcion,
            string urlPath,
            string iconoUrl,
            bool activo)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            UrlPath = urlPath;
            IconoUrl = iconoUrl;
            Activo = activo;
        }

        public static TipoDenuncio Crear(
            long id,
            string nombre,
            string descripcion,
            string urlPath,
            string iconoUrl,
            bool activo)
        {
            return new TipoDenuncio(id, nombre, descripcion, urlPath, iconoUrl, activo);
        }
    }
}