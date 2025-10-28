namespace DenunciaSiniestro.Dominio.Entidades
{
    public class ConfiguracionFormulario : Entidad<long>, IAggregateRoot
    {
        public long IdTipoDenuncio { get; private set; }
        public string EstructuraJson { get; private set; } = string.Empty;
        public int Version { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaModificacion { get; private set; }
        public List<Seccion> Secciones { get; private set; } = new List<Seccion>();

        public TipoDenuncio TipoDenuncio { get; private set; } = default!;
        public List<Denuncio> Denuncios { get; private set; } = new List<Denuncio>();
        public ConfiguracionFormulario(){}

        public ConfiguracionFormulario(
            long id,
            long idTipoDenuncio,
            string estructuraJson,
            int version,
            bool activo,
            DateTime fechaCreacion,
            DateTime fechaModificacion)
        {
            Id = id;
            IdTipoDenuncio = idTipoDenuncio;
            EstructuraJson = estructuraJson;
            Version = version;
            Activo = activo;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
        }

        public static ConfiguracionFormulario Crear(
            long id,
            long idTipoDenuncio,
            string estructuraJson,
            int version,
            bool activo,
            DateTime fechaCreacion,
            DateTime fechaModificacion)
        {
            return new ConfiguracionFormulario(
                id: id,
                idTipoDenuncio: idTipoDenuncio,
                estructuraJson: estructuraJson ?? string.Empty,
                version: version,
                activo: activo,
                fechaCreacion: fechaCreacion,
                fechaModificacion: fechaModificacion);
        }

        public void AsignarTipoDenuncio(
            TipoDenuncio tipoDenuncio)
        {
            TipoDenuncio = tipoDenuncio;
        }

        public void AsignarSecciones(
           List<Seccion> secciones)
        {
            Secciones = secciones;
        }
        public void AsignarDenuncios(
           List<Denuncio> denuncios)
        {
            Denuncios = denuncios;
        }
    }
}
