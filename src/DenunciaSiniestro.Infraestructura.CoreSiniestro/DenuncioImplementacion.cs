using DenunciaSiniestro.Aplicacion.Contratos;
using DenunciaSiniestro.Dominio;
using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Infraestructura.CoreSiniestro.TransactionBuilder;
using Microsoft.Extensions.Logging;

namespace DenunciaSiniestro.Infraestructura.CoreSiniestro
{
    public class DenuncioImplementacion : IDenuncioContract
    {
        private readonly ICoreSiniestrosApi _coreSiniestrosApi;
        private readonly CrearTransaccionRequest _poliza = new();
        private readonly ILogger<DenuncioImplementacion> _logger;

        public DenuncioImplementacion(ICoreSiniestrosApi coreSiniestrosApi, ILogger<DenuncioImplementacion> logger)
        {
            _coreSiniestrosApi = coreSiniestrosApi;
            _logger = logger;
        }

        public async Task<Denuncio> Enviar(Denuncio denuncio)
        {
            try
            {
                _logger.LogInformation("Construyendo y enviando denuncio a integracion para siniestro asociado a poliza {Poliza}", denuncio.DenuncioSoap.Vehiculo.NumeroPoliza);

                var soapBuilder = new SoapBuilder(denuncio.DenuncioSoap)
                                    .AgregarNewCustomActionSiniestro(denuncio.DenuncioSoap.Vehiculo, denuncio.DenuncioSoap.Siniestro)
                                    .AgregarNewEvent(denuncio.DenuncioSoap.Siniestro)
                                    .AgregarNewCase(denuncio.DenuncioSoap.Siniestro, denuncio.DenuncioSoap.Denunciante)
                                    .AgregarNewCustomActionLesionado(denuncio.DenuncioSoap.Lesionado);

                var acciones = soapBuilder.Build();

                _poliza.Acciones = acciones;

                var respuesta = await _coreSiniestrosApi.TransaccionesAsync(_poliza);

                if (respuesta.StatusCode == 200)
                {
                    denuncio.EstablecerNumeroSiniestro(respuesta.Result.NumeroSiniestro);
                    _logger.LogInformation($"Siniestro notificado correctamente, id siniestro obtenido: {respuesta.Result.NumeroSiniestro}");
                }
                else
                {
                    _logger.LogError($"Error: Integracion ha respondido con un codigo {respuesta.StatusCode}");
                }

                return denuncio;
            }
            catch (Exception ex)
            {
                throw new Sbins.Comunes.Excepciones.InfraestructureException(ex.Message);
            }
        }
    }
}
