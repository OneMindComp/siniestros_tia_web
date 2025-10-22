using DenunciaSiniestro.Api.Controllers.Base;
using DenunciaSiniestro.Aplicacion.Comandos;
using DenunciaSiniestro.Aplicacion.Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Sbins.Comunes.Api.Firmas;
using Sbins.Mediador.Abstracciones;
using System.Text.Json.Serialization;

/// <summary>
/// APIs de gestion de denuncias.
/// </summary>
[Route("[controller]")]
[ApiController]
[ApiConventionType(typeof(SbinsApiConvention))]
public class DenuncioController : CustomControllerBase
{
    private readonly ISender _mediador;

    /// <summary>
    /// Instanciacion de controlador de servicios de denuncios.
    /// </summary>
    /// <param name="mediador"></param>
    public DenuncioController(ISender mediador)
    {
        _mediador = mediador;
    }

    /// <summary>
    /// Crea un denuncio siniestro.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiOkResponse<long>), StatusCodes.Status200OK)]
    public async Task<IActionResult> CrearDenuncio([FromBody] DenuncioRequest request)
    {
        var consulta = new ProcesarDenuncioCommand()
        {
            ProcesarDenuncioRequest = request
        };

        var resultado = await _mediador.Send(consulta);

        return ObtenerRespuesta(resultado);

    }

    public record RecaptchaRequest(string Token);

    public class RecaptchaResponse
    {
        [JsonPropertyName("success")] public bool Success { get; set; }
        [JsonPropertyName("score")] public float Score { get; set; }
        [JsonPropertyName("action")] public string Action { get; set; }
    }
}
