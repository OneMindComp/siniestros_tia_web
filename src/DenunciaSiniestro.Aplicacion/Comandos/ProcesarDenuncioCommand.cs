using System.Reflection;
using System.Text.Json.Serialization;
using DenunciaSiniestro.Aplicacion.Contratos;
using DenunciaSiniestro.Aplicacion.Dtos.Request;
using DenunciaSiniestro.Aplicacion.Utils;
using DenunciaSiniestro.Dominio;
using DenunciaSiniestro.Dominio.Denuncios;
using Sbins.Mediador.Abstracciones;

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
        private readonly IDenuncioContract _denuncioContract;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cadenaEmisionFactory"></param>
        /// <param name="logger"></param>
        /// <param name="colaTareaBackground"></param>
        /// <param name="correoContract"></param>
        /// <param name="parametros"></param>
        public ProcesarDenuncioCommandHandler(IDenuncioContract denuncioContract)
        {
            _denuncioContract = denuncioContract;
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

                // 1. Obtener las colecciones de la sección (esto sigue siendo necesario)
                var datosVehiculo = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosVehiculo");
                var datosDenunciante = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosDenunciante");
                var datosConductor = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosConductor");
                var datosLesionado = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosLesionado");
                var datosSiniestro = proceso.Valores.Where(x => x.Value.NombreSeccion == "DatosSiniestro");

                // 2. Convertir cada colección a un diccionario (Lógica Reutilizable 1)
                var dictVehiculo = ExtractorDatos.ConvertirADiccionario(datosVehiculo);
                var dictDenunciante = ExtractorDatos.ConvertirADiccionario(datosDenunciante);
                var dictConductor = ExtractorDatos.ConvertirADiccionario(datosConductor);
                var dictLesionado = ExtractorDatos.ConvertirADiccionario(datosLesionado);
                var dictSiniestro = ExtractorDatos.ConvertirADiccionario(datosSiniestro);

                // 3. Mapear los objetos usando el diccionario (Lógica Reutilizable 2)

                // Vehiculo
                Vehiculo vehiculo = ExtractorDatos.MapearObjeto(dictVehiculo, GetValue =>
                    Vehiculo.Crear(
                        numeroPoliza: GetValue(nameof(Vehiculo.NumeroPoliza)),
                        patente: GetValue(nameof(Vehiculo.Patente)),
                        numeroMotor: GetValue(nameof(Vehiculo.NumeroMotor))
                    )
                );

                // Denunciante
                Denunciante denunciante = ExtractorDatos.MapearObjeto(dictDenunciante, GetValue =>
                    Denunciante.Crear(
                        nombre: GetValue(nameof(Denunciante.Nombre)),
                        apellidos: GetValue(nameof(Denunciante.Apellidos)),
                        rut: GetValue(nameof(Denunciante.Rut)),
                        celular: GetValue(nameof(Denunciante.Celular)),
                        mail: GetValue(nameof(Denunciante.Mail))
                    )
                );

                // Conductor
                Conductor conductor = ExtractorDatos.MapearObjeto(dictConductor, GetValue =>
                    Conductor.Crear(
                        nombre: GetValue(nameof(Conductor.Nombre)),
                        rut: GetValue(nameof(Conductor.Rut))
                    )
                );

                // Lesionado
                Lesionado lesionado = ExtractorDatos.MapearObjeto(dictLesionado, GetValue =>
                    Lesionado.Crear(
                        nombre: GetValue(nameof(Lesionado.Nombre)),
                        rut: GetValue(nameof(Lesionado.Rut)),
                        celular: GetValue(nameof(Lesionado.Celular)),
                        mail: GetValue(nameof(Lesionado.Mail))
                    )
                );

                // Siniestro
                Siniestro siniestro = ExtractorDatos.MapearObjeto(dictSiniestro, GetValue =>
                    Siniestro.Crear(
                        ubicacion: GetValue(nameof(Siniestro.Ubicacion)),
                        // NOTA: Es importante que el valor para la fecha sea una string válida para DateTime.Parse
                        fecha: DateTime.Parse(GetValue(nameof(Siniestro.Fecha))),
                        relatoAccidente: GetValue(nameof(Siniestro.RelatoAccidente)),
                        numeroPartePolicial: GetValue(nameof(Siniestro.NumeroPartePolicial))
                    )
                );
                Soap soap = Soap.Crear(vehiculo, denunciante, conductor, lesionado, siniestro);

                Denuncio denuncio = Denuncio.Crear(proceso.TipoDenuncio.ToString(), soap);

                var result = await _denuncioContract.Enviar(denuncio);

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
