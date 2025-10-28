using System.ComponentModel;

namespace DenunciaSiniestro.Dominio.Enumeradores
{
    public enum EstadoDenuncio
    {
        [Description("Ingresado")]
        Ingresado = 1,

        [Description("Siniestro generado con exito")]
        SiniestroGenerado = 2,

        [Description("Error al generar siniestro")]
        ErrorAlGenerarSiniestro = 3
    }
}
