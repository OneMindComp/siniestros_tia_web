using System.Text.Json.Serialization;

namespace DenunciaSiniestro.Aplicacion.Dtos.Response
{
    public class RecaptchaResponse
    {
        [JsonPropertyName("success")] public bool Success { get; set; }
        [JsonPropertyName("score")] public float Score { get; set; }
        [JsonPropertyName("action")] public string Action { get; set; }
    }
}
