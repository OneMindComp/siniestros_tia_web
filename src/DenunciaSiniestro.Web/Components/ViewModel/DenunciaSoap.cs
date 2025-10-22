using System.ComponentModel.DataAnnotations;

namespace DenunciaSiniestro.Web.Components.ViewModel;

public class SiniestroData
{
    // 1 DATOS DEL VEHÍCULO
    [Required(ErrorMessage = "El número de póliza es obligatorio")]
    public string NumeroPoliza { get; set; } = string.Empty;

    [Required(ErrorMessage = "La patente es obligatoria")]
    public string Patente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El número de motor es obligatorio")]
    public string NumeroMotor { get; set; } = string.Empty;

    // 2 DATOS DEL DENUNCIANTE
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string NombreDenunciante { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    public string ApellidosDenunciante { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Rut es obligatorio")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "El Rut debe tener entre 10 y 11 caracteres")]
    public string RutDenunciante { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    public string TelefonoDenunciante { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo inválido")]
    public string CorreoDenunciante { get; set; } = string.Empty;

    // 3 DATOS DEL CONDUCTOR
    [Required(ErrorMessage = "El nombre del conductor es obligatorio")]
    public string NombreConductor { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Rut del conductor es obligatorio")]
    public string RutConductor { get; set; } = string.Empty;

    // 4 DATOS DEL LESIONADO
    [Required(ErrorMessage = "El nombre del lesionado es obligatorio")]
    public string NombreLesionado { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Rut del lesionado es obligatorio")]
    public string RutLesionado { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono del lesionado es obligatorio")]
    public string TelefonoLesionado { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico del lesionado es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo inválido")]
    public string CorreoLesionado { get; set; } = string.Empty;

    // 5 DATOS DEL SINIESTRO
    [Required(ErrorMessage = "La ubicación es obligatoria")]
    public string UbicacionAccidente { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha del siniestro es obligatoria")]
    public DateTime? FechaSiniestro { get; set; } // Nullable DateTime

    [Required(ErrorMessage = "El relato es obligatorio")]
    public string RelatoAccidente { get; set; } = string.Empty;

    [Required(ErrorMessage = "El número de parte policial es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Número de parte policial inválido")]
    public int? NumeroPartePolicial { get; set; } // Nullable int

    [Required(ErrorMessage = "La clase de vehículo es requerida.")]
    public string ClaseVehiculo { get; set; } = default!;

    [Required(ErrorMessage = "El tipo de lesión es requerido.")]
    public string TipoLesion { get; set; } = default!;
}