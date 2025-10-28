using DenunciaSiniestro.Aplicacion.Contratos;
using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Aplicacion.Dtos.Request;
using DenunciaSiniestro.Aplicacion.Dtos.Response;
using DenunciaSiniestro.Aplicacion.Utils;
using DenunciaSiniestro.Dominio.Denuncios;
using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Dominio.Enumeradores;
using Microsoft.Extensions.Logging;
using Sbins.Mediador.Abstracciones;
using System.Text.Json;

namespace DenunciaSiniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Procesa un denuncio.
    /// </summary>
    public class ProcesarDenuncioCommand : IRequest<ProcesarDenuncioResponse>
    {
        public ProcesarDenuncioRequest DenuncioRequest { get; set; } = default!;
    }

    /// <summary>
    /// Maneja la logica para procesar un denuncio.
    /// </summary>
    public class ProcesarDenuncioCommandHandler : IRequestHandler<ProcesarDenuncioCommand, ProcesarDenuncioResponse>
    {
        private readonly IDenuncioContract _denuncioContract;
        private readonly ILogger<ProcesarDenuncioCommandHandler> _logger;
        private readonly IDenuncioRepositorio _denuncioRepositorio;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="denuncioContract"></param>
        /// <param name="denuncioRepositorio"></param>
        public ProcesarDenuncioCommandHandler(ILogger<ProcesarDenuncioCommandHandler> logger, IDenuncioContract denuncioContract, IDenuncioRepositorio denuncioRepositorio)
        {
            _logger = logger;
            _denuncioContract = denuncioContract;
            _denuncioRepositorio = denuncioRepositorio;
        }

        /// <summary>
        /// Implementa la logica para procesar un denuncio.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Sbins.Comunes.Excepciones.ApplicationException"></exception>
        public async Task<ProcesarDenuncioResponse> Handle(ProcesarDenuncioCommand request, CancellationToken cancellationToken)
        {
            string numeroSeguimiento = "";
            Denuncio? denuncio = Denuncio.Crear();

            try
            {
                _logger.LogInformation("Iniciando proceso de denuncio de siniestro.");

                var proceso = request.DenuncioRequest;

                var datosVehiculo = proceso.Valores.Where(x => x.Value.NombreSeccion.Replace(" ", string.Empty) == "DatosVehiculo");
                var datosDenunciante = proceso.Valores.Where(x => x.Value.NombreSeccion.Replace(" ", string.Empty) == "DatosDenunciante");
                var datosConductor = proceso.Valores.Where(x => x.Value.NombreSeccion.Replace(" ", string.Empty) == "DatosConductor");
                var datosLesionado = proceso.Valores.Where(x => x.Value.NombreSeccion.Replace(" ", string.Empty) == "DatosLesionado");
                var datosSiniestro = proceso.Valores.Where(x => x.Value.NombreSeccion.Replace(" ", string.Empty) == "DatosSiniestro");

                var dictVehiculo = ExtractorDatos.ConvertirADiccionario(datosVehiculo);
                var dictDenunciante = ExtractorDatos.ConvertirADiccionario(datosDenunciante);
                var dictConductor = ExtractorDatos.ConvertirADiccionario(datosConductor);
                var dictLesionado = ExtractorDatos.ConvertirADiccionario(datosLesionado);
                var dictSiniestro = ExtractorDatos.ConvertirADiccionario(datosSiniestro);

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
                        fecha: DateTime.Parse(GetValue(nameof(Siniestro.Fecha))),
                        relatoAccidente: GetValue(nameof(Siniestro.RelatoAccidente)),
                        numeroPartePolicial: GetValue(nameof(Siniestro.NumeroPartePolicial))
                    )
                );

                _logger.LogInformation("Datos extraidos para siniestro asociado a poliza {NumeroPoliza}", vehiculo.NumeroPoliza);

                numeroSeguimiento = GeneradorCodigoSeguimiento.Generar();

                denuncio = await _denuncioRepositorio.Obtener(numeroSeguimiento);

                while (denuncio != null)
                {
                    numeroSeguimiento = GeneradorCodigoSeguimiento.Generar();
                    denuncio = await _denuncioRepositorio.Obtener(numeroSeguimiento);
                }

                Soap soap = Soap.Crear(vehiculo, denunciante, conductor, lesionado, siniestro);
                string jsonRespuestas = JsonSerializer.Serialize(soap);

                denuncio = Denuncio.Crear((int)Dominio.Enumeradores.TipoDenuncio.SOAP, 1, DateTime.Now, $"{denunciante.Nombre} {denunciante.Apellidos}",
                    denunciante.Celular);
                denuncio.EstablecerEstadoYFechaIngreso(EstadoDenuncio.Ingresado.ToString(), DateTime.Now);
                denuncio.EstablecerContenidoFormulario(jsonRespuestas, numeroSeguimiento);

                denuncio = await _denuncioRepositorio.Agregar(denuncio);

                denuncio.EstablecerDenuncioSoap(soap);
                denuncio = await _denuncioContract.Enviar(denuncio);
                denuncio.EstablecerEstadoYFechaActualizacion(EstadoDenuncio.SiniestroGenerado.ToString(), DateTime.Now);

                await _denuncioRepositorio.Actualizar(denuncio);

                ProcesarDenuncioResponse procesarDenuncioResponse = new ProcesarDenuncioResponse()
                {
                    Estado = EstadoDenuncio.Ingresado,
                    NumeroSeguimiento = denuncio.NumeroSeguimiento
                };

                return procesarDenuncioResponse;
            }
            catch (Exception ex)
            {

                if (denuncio != null)
                {
                    denuncio.EstablecerEstadoYFechaActualizacion(EstadoDenuncio.ErrorAlGenerarSiniestro.ToString(), DateTime.Now);
                    await _denuncioRepositorio.Actualizar(denuncio);
                }

                throw new Sbins.Comunes.Excepciones.ApplicationException(ex.Message);
            }
        }
    }
}
