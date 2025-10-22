using DenunciaSiniestro.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// APIs de gestion de denuncias.
/// </summary>
[Route("[controller]")]
[ApiController]
[ApiConventionType(typeof(SbinsApiConvention))]
public class RecaptchaController : ControllerBase
{
    [HttpPost("validate")]
    public async Task<IActionResult> ValidateRecaptcha([FromBody] RecaptchaRequest request)
    {
        var secretKey = "6LcPvesrAAAAAGO9bpiw_sHFnG9Flg9usmKQY-oY"; // clave secreta

        using var http = new HttpClient();
        var response = await http.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={request.Token}",
            null);

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<RecaptchaResponse>(json);

        if (result?.Success == true && result.Score >= 0.5)
            return Ok(new { success = true, score = result.Score });

        return BadRequest(new { success = false, score = result?.Score });
    }

    public record RecaptchaRequest(string Token);

    public class RecaptchaResponse
    {
        [JsonPropertyName("success")] public bool Success { get; set; }
        [JsonPropertyName("score")] public float Score { get; set; }
        [JsonPropertyName("action")] public string Action { get; set; }
    }
}
