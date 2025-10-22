using System.Text.Json;
using Microsoft.JSInterop;
using Sbins.Mediador.Abstracciones;
using static DenunciaSiniestro.Aplicacion.Comandos.ProcesarDenuncioCommandHandler;

public class RecaptchaService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly string _siteKey;

    public RecaptchaService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        // Puedes mover esta key a appsettings.json si prefieres
        _siteKey = "";
    }

    public async Task<bool> ValidateToken(string action = "form_submit")
    {
        string valor;
        try
        {
            valor = await _jsRuntime.InvokeAsync<string>(
            "recaptchaService.execute",
            _siteKey,
            action);

            var secretKey = ""; // clave secreta

            using var http = new HttpClient();
            var response = await http.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={valor}",
                null);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RecaptchaResponse>(json);

            return result?.Success == true && result.Score >= 0.5;
      
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
