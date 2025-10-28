namespace DenunciaSiniestro.Aplicacion.Contratos.Repositorios
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
