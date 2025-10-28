using DenunciaSiniestro.Dominio;

namespace DenunciaSiniestro.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorio<T, TKey> where T : IAggregateRoot
    {
        Task<T> Obtener(TKey id);

        Task<T> Agregar(T aggregate);

        Task<List<T>> Agregar(List<T> aggregate);

        Task<T> Actualizar(T aggregate);

        Task Eliminar(T aggregate);
    }
}
