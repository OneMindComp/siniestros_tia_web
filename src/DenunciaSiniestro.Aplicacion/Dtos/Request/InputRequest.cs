using System.ComponentModel.DataAnnotations;

namespace DenunciaSiniestro.Aplicacion.Dtos.Request;

public class InputRequest
{
    public string TipoDenuncio { get; set; } = string.Empty;
    public string NombreSeccion { get; set; } = string.Empty;
    public object Valor { get; set; } = string.Empty;

}