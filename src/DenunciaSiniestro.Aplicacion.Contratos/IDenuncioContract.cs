using DenunciaSiniestro.Dominio.Entidades;

namespace DenunciaSiniestro.Aplicacion.Contratos
{
    public interface IDenuncioContract
    {
        Task<Denuncio> Enviar(Denuncio denuncio);
    }
}
