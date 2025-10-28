using DenunciaSiniestro.Dominio;

namespace DenunciaSiniestro.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioBusqueda<T, F> where T : IAggregateRoot where F : IAggregateFilter
    {
        Task<T> Buscar(F filtro);
        Task<List<T>> Buscarlista(F filtro);
    }
}
