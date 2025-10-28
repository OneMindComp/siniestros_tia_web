using DenunciaSiniestro.Dominio.Denuncios;

namespace DenunciaSiniestro.Dominio.Entidades
{
    /// <summary>
    /// Entidad que representa un denuncio de siniestro
    /// </summary>
    public class Denuncio : Entidad<long>, IAggregateRoot
    {
        public long IdTipoDenuncio { get; private set; }
        public long IdConfiguracion { get; private set; }
        public string? NumeroSiniestro { get; private set; }
        public DateTime FechaDenuncio { get; private set; }
        public string NombreDenunciante { get; private set; } = default!;
        public string TelefonoDenunciante { get; private set; } = default!;
        public string DatosBasicos { get; private set; } = default!;
        public string RespuestasFormulario { get; private set; } = default!;
        public string Estado { get; private set; } = default!;
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaActualizacion { get; private set; }
        
        public TipoDenuncio TipoDenuncio { get; private set; } = default!;
        public ConfiguracionFormulario ConfiguracionFormulario { get; private set; } = default!;

        public string Producto { get; private set; } = default!;
        public Soap DenuncioSoap { get; private set; } = default!;
        public string NumeroSeguimiento { get; private set; } = string.Empty;

        private Denuncio()
        {
        }

        private Denuncio(string producto, Soap denuncioSoap)
        {
            Producto = producto;
            DenuncioSoap = denuncioSoap;
        }

        private Denuncio(
            long idTipoDenuncio,
            long idConfiguracion,
            DateTime fechaDenuncio,
            string nombreDenunciante,
            string telefonoDenunciante)
        {
            IdTipoDenuncio = idTipoDenuncio;
            IdConfiguracion = idConfiguracion;
            FechaDenuncio = fechaDenuncio;
            NombreDenunciante = nombreDenunciante;
            TelefonoDenunciante = telefonoDenunciante;
        }

        public static Denuncio Crear(
            long idTipoDenuncio,
            long idConfiguracion,
            DateTime fechaDenuncio,
            string nombreDenunciante,
            string telefonoDenunciante)
        {
            return new Denuncio(
                idTipoDenuncio,
                idConfiguracion,
                fechaDenuncio,
                nombreDenunciante,
                telefonoDenunciante);
        }

        public static Denuncio Crear()
        {
            return new Denuncio();
        }

        public static Denuncio Crear(string producto, Soap denuncioSoap)
        {
            return new Denuncio(producto, denuncioSoap);
        }

        public void EstablecerDenuncioSoap(Soap denuncioSoap)
        {
            DenuncioSoap = denuncioSoap;
        }

        public void EstablecerContenidoFormulario(
            string respuestasFormulario,
            string numeroSeguimiento
            )
        {
            RespuestasFormulario = respuestasFormulario;
            NumeroSeguimiento = numeroSeguimiento;
        }

        public void EstablecerEstadoYFechaIngreso(
            string estado,
            DateTime fechaCreacion)
        {
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }

        public void EstablecerEstadoYFechaActualizacion(
            string estado,
            DateTime fechaActualizacion)
        {
            Estado = estado;
            FechaActualizacion = fechaActualizacion;
        }

        public void EstablecerIdDenuncio(
            long id)
        {
            Id= id;
        }

        public void EstablecerNumeroSiniestro(
            string? numeroSiniestro)
        {
            NumeroSiniestro=numeroSiniestro;
        }
    }
}
