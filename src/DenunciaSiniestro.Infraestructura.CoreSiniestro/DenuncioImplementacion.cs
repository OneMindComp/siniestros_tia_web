using DenunciaSiniestro.Aplicacion.Contratos;
using DenunciaSiniestro.Dominio;
using DenunciaSiniestro.Infraestructura.CoreSiniestro.TransactionBuilder;

namespace DenunciaSiniestro.Infraestructura.CoreSiniestro
{
    public class DenuncioImplementacion : IDenuncioContract
    {
        private readonly ICoreSiniestrosApi _coreSiniestrosApi;
        private readonly TransaccionRequest _poliza = new();

        public DenuncioImplementacion(ICoreSiniestrosApi coreSiniestrosApi)
        {
            _coreSiniestrosApi = coreSiniestrosApi;
        }

        public Task<string> Enviar(Denuncio denuncio)
        {
            var soapBuilder = new SoapBuilder(denuncio.DenuncioSoap)
                    .AgregarNewCustomActionSiniestro(denuncio.DenuncioSoap.Vehiculo, denuncio.DenuncioSoap.Siniestro)
                    .AgregarNewEvent(denuncio.DenuncioSoap.Siniestro)
                    .AgregarNewCase(denuncio.DenuncioSoap.Siniestro, denuncio.DenuncioSoap.Denunciante)
                    .AgregarNewCustomActionLesionado(denuncio.DenuncioSoap.Lesionado);

            var acciones = soapBuilder.Build();

            _poliza.Acciones = acciones;

            _coreSiniestrosApi.ApiTransaccionesAsync(_poliza);

            throw new NotImplementedException();
        }
    }
}
