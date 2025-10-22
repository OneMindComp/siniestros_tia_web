using System.Globalization;
using DenunciaSiniestro.Dominio.Denuncios;
using DenunciaSiniestro.Infraestructura.CoreSiniestro.Enumeradores;

namespace DenunciaSiniestro.Infraestructura.CoreSiniestro.TransactionBuilder
{
    public class SoapBuilder
    {
        private readonly Soap _denuncio;
        private readonly List<AccionRequest> _transacciones = [];

        public SoapBuilder(Soap denuncio) {
            _denuncio = denuncio;

        }
        private SoapBuilder(
            AccionRequest accionRequest,
            List<AccionRequest> transacciones
            )
        {
            _transacciones = transacciones;
            _transacciones[^1] = accionRequest;
        }

        public SoapBuilder AgregarNewCustomActionSiniestro(Vehiculo vehiculo, Siniestro siniestro)
        {

            return NuevaTransaccion()
                .AddPropiedad("action", "PRE_OP.LOOKUP_OBJECT")
                .AddPropiedad("policyNoAlt", vehiculo.NumeroPoliza)
                .AddPropiedad("objectId", vehiculo.Patente)
                .AddPropiedad("incidentDate", siniestro.Fecha)
                .AddNombre(AccionTia.CustomAction);
        }

        public SoapBuilder AgregarNewEvent(Siniestro siniestro)
        {

            return NuevaTransaccion()
                .AddPropiedad("eventType", "ACC")
                .AddPropiedad("causeType", "OTR")
                .AddPropiedad("incidentDate", siniestro.Fecha)
                .AddPropiedad("isExactIncidentDate", "N")
                .AddPropiedad("address", siniestro.Ubicacion)
                .AddPropiedad("placeType", "ROA")
                .AddNombre(AccionTia.NewEvent);
        }
        public SoapBuilder AgregarNewCase(Siniestro siniestro, Denunciante denunciante)
        {

            return NuevaTransaccion()
                .AddPropiedad("informerType", "IP")
                .AddPropiedad("informerName", String.Format("{0} {1}", denunciante.Nombre, denunciante.Apellidos))
                .AddPropiedad("notificationDate", siniestro.Fecha)
                .AddPropiedad("status", "NO")
                .AddPropiedad("lossOfBonus", "N")
                .AddPropiedad("description", siniestro.RelatoAccidente)
                .AddPropiedad("riskNo", "105") //REVISAR
                .AddPropiedad("subriskNo", "0")
                .AddPropiedad("filedBy", "INT")
                .AddPropiedad("c08", String.IsNullOrWhiteSpace(siniestro.NumeroPartePolicial) ? "N" : "Y") //REVISAR
                .AddPropiedad("c27", siniestro.NumeroPartePolicial)
                .AddPropiedad("c24", denunciante.Rut)
                .AddPropiedad("c25", denunciante.Mail)
                .AddPropiedad("c26", denunciante.Celular)
                .AddNombre(AccionTia.NewCase);
        }
        public SoapBuilder AgregarNewCustomActionLesionado(Lesionado lesionado)
        {

            return NuevaTransaccion()
                .AddPropiedad("action", "CUSTOM.ADD_THIRD_PARTY")
                .AddPropiedad("civilRegistrationCode", lesionado.Rut)
                .AddPropiedad("name", lesionado.Nombre)
                .AddPropiedad("type", "INJ")
                .AddNombre(AccionTia.CustomAction);
        }
        private SoapBuilder NuevaTransaccion()
        {
            var nuevaAccionRequest = new AccionRequest
            {
                Propiedades = []
            };

            _transacciones.Add(nuevaAccionRequest);

            return new SoapBuilder(nuevaAccionRequest, _transacciones);
        }

        /// <summary>
        /// Metodo para agregar una propiedad.
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public SoapBuilder AddPropiedad(string clave, object? valor)
        {
            var propiedad = Propiedad(clave, valor);
            _transacciones[^1].Propiedades.Add(propiedad);

            return this;
        }

        /// <summary>
        /// Metodo para agregar el nombre de accion.
        /// </summary>
        /// <param name="accion"></param>
        /// <returns></returns>
        public SoapBuilder AddNombre(string accion)
        {
            _transacciones[^1].Nombre = accion;

            return this;
        }

        public static PropiedadRequest Propiedad(string clave, object? valor)
        {
            string valorStr = valor?.ToString() ?? string.Empty;

            if (valor is DateTime fecha)
            {
                valorStr = fecha.ToString("yyyy-MM-ddTHH:mm:ssZ");
            }

            if (valor is decimal monto)
            {
                valorStr = monto.ToString("0.00", CultureInfo.InvariantCulture);
            }

            return new PropiedadRequest
            {
                Clave = clave,
                Valor = valorStr
            };
        }

        /// <summary>
        /// Metodo para construir la transaccion.
        /// </summary>
        /// <returns></returns>
        public List<AccionRequest> Build()
        {
            return _transacciones;
        }
    }
}
