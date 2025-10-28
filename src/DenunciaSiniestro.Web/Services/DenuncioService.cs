using DenunciaSiniestro.Aplicacion.Comandos;
using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Aplicacion.Dtos.Request;
using DenunciaSiniestro.Aplicacion.Dtos.Response;
using DenunciaSiniestro.Dominio.Entidades;
using PasarelaPago.Aplicacion.Consultas;
using Sbins.Mediador.Abstracciones;

public class DenuncioService
{
    private readonly ISender _mediador;
    private readonly IConfiguracionFormularioRepositorio _configuracionFormulario;

    public DenuncioService(ISender mediador, IConfiguracionFormularioRepositorio configuracionFormulario)
    {
        _mediador = mediador;
        _configuracionFormulario = configuracionFormulario;
    }

    public async Task<ProcesarDenuncioResponse> CrearDenuncio(ProcesarDenuncioRequest request)
    {
        var consulta = new ProcesarDenuncioCommand()
        {
            DenuncioRequest = request
        };

        var resultado = await _mediador.Send(consulta);
        return resultado;
    }

    public async Task<ConfiguracionFormulario> ObtenerConfiguracion(int idConfiguracionFormulario)
    {
        var consulta = new ConfiguracionFormularioQuery
        {
            TipoDenuncio = idConfiguracionFormulario
        };

        var resultado = await _mediador.Send(consulta);
        return resultado;
    }
}
