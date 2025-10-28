using System.ComponentModel.DataAnnotations;

namespace DenunciaSiniestro.Web.Components.ViewModel;

public class SiniestroData
{
    // 1 DATOS DEL VEHÍCULO
    [Required(ErrorMessage = "El número de póliza es obligatorio")]
    public string NumeroPoliza { get; private set; } = string.Empty;

    [Required(ErrorMessage = "La patente es obligatoria")]
    public string Patente { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El número de motor es obligatorio")]
    public string NumeroMotor { get; private set; } = string.Empty;

    // 2 DATOS DEL DENUNCIANTE
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string NombreDenunciante { get; private set; } = string.Empty;

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    public string ApellidosDenunciante { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El Rut es obligatorio")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "El Rut debe tener entre 10 y 11 caracteres")]
    public string RutDenunciante { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    public string TelefonoDenunciante { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo inválido")]
    public string CorreoDenunciante { get; private set; } = string.Empty;

    // 3 DATOS DEL CONDUCTOR
    [Required(ErrorMessage = "El nombre del conductor es obligatorio")]
    public string NombreConductor { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El Rut del conductor es obligatorio")]
    public string RutConductor { get; private set; } = string.Empty;

    // 4 DATOS DEL LESIONADO
    [Required(ErrorMessage = "El nombre del lesionado es obligatorio")]
    public string NombreLesionado { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El Rut del lesionado es obligatorio")]
    public string RutLesionado { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono del lesionado es obligatorio")]
    public string TelefonoLesionado { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico del lesionado es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo inválido")]
    public string CorreoLesionado { get; private set; } = string.Empty;

    // 5 DATOS DEL SINIESTRO
    [Required(ErrorMessage = "La ubicación es obligatoria")]
    public string UbicacionAccidente { get; private set; } = string.Empty;

    [Required(ErrorMessage = "La fecha del siniestro es obligatoria")]
    public DateTime? FechaSiniestro { get; private set; } // Nullable DateTime

    [Required(ErrorMessage = "El relato es obligatorio")]
    public string RelatoAccidente { get; private set; } = string.Empty;

    [Required(ErrorMessage = "El número de parte policial es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Número de parte policial inválido")]
    public int? NumeroPartePolicial { get; private set; } // Nullable int

    [Required(ErrorMessage = "La clase de vehículo es requerida.")]
    public string ClaseVehiculo { get; private set; } = default!;

    [Required(ErrorMessage = "El tipo de lesión es requerido.")]
    public string TipoLesion { get; private set; } = default!;
}