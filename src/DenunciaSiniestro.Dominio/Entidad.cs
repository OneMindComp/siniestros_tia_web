namespace DenunciaSiniestro.Dominio
{
    public abstract class Entidad<TId>
    {
        public TId Id { get; set; } = default!;
    }
}
