namespace DenunciaSiniestro.Infraestructura.Persistencia
{
    public class VaultInfraestructuraMySql
    {
        public string UrlBase { get; set; } = default!;
        public string NombreRecurso { get; set; } = default!;
        public SecretsVaultInfraestructuraSybase Secrets { get; set; } = default!;
    }
    public class SecretsVaultInfraestructuraSybase
    {
        public string ConnectionString { get; set; } = default!;
    }
}
