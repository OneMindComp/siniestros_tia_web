using DenunciaSiniestro.Dominio;

namespace DenunciaSiniestro.Aplicacion.Contratos
{
    public interface IDenuncioContract
    {
        Task<string> Enviar(Denuncio denuncio);
    }
}
