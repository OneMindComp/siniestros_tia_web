using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Sbins.Comunes.Api.Firmas;
using Sbins.Comunes.Excepciones;

namespace DenunciaSiniestro.Api.Controllers.Base
{
    /// <summary>
    /// Controlador personalizado para códigos de respuesta API.
    /// </summary>
    public class CustomControllerBase : ControllerBase
    {
        /// <summary>
        /// Entrega código de búsqueda OK.
        /// </summary>        
        /// <typeparam name="T"></typeparam>
        /// <param name="resultado"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public OkObjectResult ObtenerRespuesta<T>(T resultado)
        {
            if (EqualityComparer<T>.Default.Equals(resultado, default) || EsColeccionVacia(resultado))
                throw new NotFoundException();

            return Ok(new ApiOkResponse<T>(resultado));
        }

        private static bool EsColeccionVacia<T>(T valor)
        {
            bool esColeccion = typeof(ICollection).IsAssignableFrom(typeof(T));
            if (esColeccion)
            {
                var coleccion = valor as ICollection;
                return coleccion!.Count == 0;
            }
            return false;
        }
    }

    /// <summary>
    /// Convención de documentación de API, de acuerdo a los códigos de excepción y tipos de respuesta.
    /// </summary>    
    public static class SbinsApiConvention
    {
        /// <summary>
        /// Inicializa default para tipos de respuestas admitidas por controladores.
        /// </summary>
        [ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]

        public static void Default()
        {
            //Metodo dejado vacio a proposito.
        }

    }
}
