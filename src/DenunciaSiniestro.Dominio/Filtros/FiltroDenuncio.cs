namespace DenunciaSiniestro.Dominio.Filtros
{
    public class FiltroDenuncio : FiltroBase<long>
    {
        public string NumeroSeguimiento { get; set; } = string.Empty;
    }
}
