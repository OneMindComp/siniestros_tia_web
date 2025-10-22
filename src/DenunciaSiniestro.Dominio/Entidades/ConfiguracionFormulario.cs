namespace DenunciaSiniestro.Dominio.Entidades
{
    public class ConfiguracionFormulario
    {
        public int IdConfiguracion { get; private set; }
        public int IdTipoDenuncio { get; private set; }
        public string EstructuraJson { get; private set; } = string.Empty;
        public int Version { get; private set; }
        public bool Activo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaModificacion { get; private set; }

        // Constructor vacio requerido por EF Core
        public ConfiguracionFormulario()
        {
        }

        // Constructor privado con todos los parametros
        private ConfiguracionFormulario(
            int idConfiguracion,
            int idTipoDenuncio,
            string estructuraJson,
            int version,
            bool activo,
            DateTime fechaCreacion,
            DateTime fechaModificacion)
        {
            IdConfiguracion = idConfiguracion;
            IdTipoDenuncio = idTipoDenuncio;
            EstructuraJson = estructuraJson;
            Version = version;
            Activo = activo;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
        }

        // Metodo estatico para crear una nueva instancia
        public static ConfiguracionFormulario Crear(
            int idConfiguracion,
            int idTipoDenuncio,
            string estructuraJson,
            int version,
            bool activo,
            DateTime fechaCreacion,
            DateTime fechaModificacion)
        {
            return new ConfiguracionFormulario(
                idConfiguracion: idConfiguracion,
                idTipoDenuncio: idTipoDenuncio,
                estructuraJson: estructuraJson ?? string.Empty,
                version: version,
                activo: activo,
                fechaCreacion: fechaCreacion,
                fechaModificacion: fechaModificacion);
        }
    }
}
