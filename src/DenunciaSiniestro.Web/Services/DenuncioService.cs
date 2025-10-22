using DenunciaSiniestro.Aplicacion.Comandos;
using DenunciaSiniestro.Aplicacion.Dtos.Request;
using Sbins.Mediador.Abstracciones;

public class DenuncioService
{
    private readonly ISender _mediador;

    public DenuncioService(ISender mediador)
    {
        _mediador = mediador;
    }

    public async Task<string> CrearDenuncio(DenuncioRequest request)
    {
        var consulta = new ProcesarDenuncioCommand()
        {
            ProcesarDenuncioRequest = request
        };

        var resultado = await _mediador.Send(consulta);
        return resultado;
    }
}
