using DenunciaSiniestro.Aplicacion.Dtos.Request;
using DenunciaSiniestro.Dominio.Denuncios;
using Sbins.Mediador.Abstracciones;
using System.Reflection;
using System.Text.Json.Serialization;

namespace DenunciaSiniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Recibe la.
    /// </summary>
    public class ProcesarDenuncioCommand : IRequest<string>
    {
        public DenuncioRequest ProcesarDenuncioRequest { get; set; } = default!;
    }

    /// <summary>
    /// Maneja la lógica para .
    /// </summary>
    public class ProcesarDenuncioCommandHandler : IRequestHandler<ProcesarDenuncioCommand, string>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cadenaEmisionFactory"></param>
        /// <param name="logger"></param>
        /// <param name="colaTareaBackground"></param>
        /// <param name="correoContract"></param>
        /// <param name="parametros"></param>
        public ProcesarDenuncioCommandHandler()
        {
        }

        /// <summary>
        /// Implementa la lógica para .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Sbins.Comunes.Excepciones.ApplicationException"></exception>
        public async Task<string> Handle(ProcesarDenuncioCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var proceso = request.ProcesarDenuncioRequest;

                var datosVehiculo = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosVehiculo");
                var datosDenunciante = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosDenunciante");
                var datosConductor = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosConductor");
                var datosLesionado = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosLesionado");
                var datosSiniestro = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosSiniestro");

                // Lo convertimos a un diccionario para buscar más fácilmente
                var dict = datosVehiculo?
                    .ToDictionary(k => k.Key.ToLowerInvariant(), v => v.Value?.Valor?.ToString() ?? string.Empty)
                    ?? new Dictionary<string, string>();

                // Creamos dinámicamente los valores esperados
                var props = typeof(Vehiculo).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                // Extraemos por nombre, ignorando mayúsculas/minúsculas
                string GetValue(string name) =>
                    dict.TryGetValue(name.ToLowerInvariant(), out var value) ? value : string.Empty;

                Vehiculo vehiculo = Vehiculo.Crear(
                    numeroPoliza: GetValue(nameof(Vehiculo.NumeroPoliza)),
                    patente: GetValue(nameof(Vehiculo.Patente)),
                    numeroMotor: GetValue(nameof(Vehiculo.NumeroMotor))
                );

                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class RecaptchaResponse
        {
            [JsonPropertyName("success")] public bool Success { get; set; }
            [JsonPropertyName("score")] public float Score { get; set; }
            [JsonPropertyName("action")] public string Action { get; set; }
        }
    }
}
