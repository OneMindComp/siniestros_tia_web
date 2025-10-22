using DenunciaSiniestro.Dominio.Denuncios;

namespace DenunciaSiniestro.Dominio
{
    public class Denuncio
    {
        public string Producto { get; set; } = default!;
        public TipoDenuncio TipoDenuncio { get; set; } = default!;
        public ConfiguracionFormulario Configuracion { get; set; } = default!;
        public string NumeroSiniestro { get; set; } = default!;
        public DateTime FechaDenuncio { get; set; } = default!;
        public string NombreDenunciante { get; set; } = default!;
        public string TelefonoDenunciante { get; set; } = default!;
        public string RespuestasFormulario { get; set; } = default!;
        public Estado Estado { get; set; } = default!; 
        public List<Seccion> Secciones { get; set; } = new List<Seccion>();
        public DateTime FechaCreacion { get; set; } = default!;
        public DateTime FechaActualizacion { get; set; } = default!;
        public Soap DenuncioSoap { get; set; } = default!;

        public Denuncio() { }

        public Denuncio(string producto, Soap denuncioSoap) {
            Producto = producto;
            DenuncioSoap = denuncioSoap;
        }

        public static Denuncio Crear(string producto, Soap denuncioSoap)
        {
            return new Denuncio(producto, denuncioSoap);
        }
    }
}
