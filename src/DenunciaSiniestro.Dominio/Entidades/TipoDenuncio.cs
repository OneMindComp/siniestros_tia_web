namespace DenunciaSiniestro.Dominio.Entidades
{
    public class TipoDenuncio : Entidad<long>, IAggregateRoot
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string UrlPath { get; set; } = string.Empty;
        public string IconoUrl { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public List<ConfiguracionFormulario> ConfiguracionesFormulario { get; private set; } = new List<ConfiguracionFormulario>();
        public List<Denuncio> Denuncios { get; private set; } = new List<Denuncio>();

        private TipoDenuncio()
        {
        }

        private TipoDenuncio(string nombre, string descripcion, string urlPath, string iconoUrl, bool activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            UrlPath = urlPath;
            IconoUrl = iconoUrl;
            Activo = activo;
        }

        // Método estático público para crear instancias
        public static TipoDenuncio Crear(string nombre, string descripcion, string urlPath, string iconoUrl, bool activo)
        {
            return new TipoDenuncio(nombre, descripcion, urlPath, iconoUrl, activo);
        }

        public void AsignarId(long id)
        {
            Id = id;
        }

        public void ActualizarNombre(string nombre)
        {
            Nombre = nombre;
        }

        public void ActualizarDescripcion(string descripcion)
        {
            Descripcion = descripcion;
        }

        public void ActualizarUrlPath(string urlPath)
        {
            UrlPath = urlPath;
        }

        public void ActualizarIconoUrl(string iconoUrl)
        {
            IconoUrl = iconoUrl;
        }

        public void CambiarEstado(bool activo)
        {
            Activo = activo;
        }

        public void AgregarConfiguracionFormulario(ConfiguracionFormulario configuracion)
        {
            ConfiguracionesFormulario.Add(configuracion);
        }

        public void AgregarDenuncio(Denuncio denuncio)
        {
            Denuncios.Add(denuncio);
        }
    }
}
