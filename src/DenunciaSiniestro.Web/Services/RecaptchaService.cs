using System.Text.Json;
using DenunciaSiniestro.Aplicacion.Dtos.Response;
using Microsoft.JSInterop;

public class RecaptchaService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly string _siteKey;
    private readonly string _secretKey;

    public RecaptchaService(IJSRuntime jsRuntime, IConfiguration configuration)
    {
        _jsRuntime = jsRuntime;
        _siteKey = configuration["Recaptcha:SiteKey"]!;
        _secretKey = configuration["Recaptcha:SecretKey"]!;
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

            using var http = new HttpClient();
            var response = await http.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={_secretKey}&response={valor}",
                null);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RecaptchaResponse>(json);

            return result?.Success == true && result.Score >= 0.5;
      
        }
        catch (Exception)
        {
            throw;
        }
    }
}
