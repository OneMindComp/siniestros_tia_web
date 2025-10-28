namespace DenunciaSiniestro.Dominio.Filtros
{
    public class FiltroDenuncio : FiltroBase<long>
    {
        public string NumeroSeguimiento { get; private set; } = string.Empty;
    }
}
