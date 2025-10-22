using Microsoft.JSInterop;

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

    public async Task<string> GetTokenAsync(string action = "form_submit")
    {
        string valor;
        try
        {
            valor = await _jsRuntime.InvokeAsync<string>(
            "recaptchaService.execute",
            _siteKey,
            action);

        }
        catch (Exception ex)
        {
            throw;
        }
        return valor;
    }
}
