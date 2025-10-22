namespace DenunciaSiniestro.Aplicacion.Contratos
{
    public interface IDenuncioContract
    {
        Task<string> Enviar(string numero, string suscripcionDeprecada, string suscripcionVigente);
    }
}
