using System.ComponentModel.DataAnnotations;

namespace DenunciaSiniestro.Web.Components.ViewModel;

public class Input
{
    public string TipoDenuncio { get; set; } = string.Empty;
    public string NombreSeccion { get; set; } = string.Empty;
    public object Valor { get; set; } = string.Empty;

}