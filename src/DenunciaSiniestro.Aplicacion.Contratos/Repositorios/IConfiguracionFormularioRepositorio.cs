namespace DenunciaSiniestro.Aplicacion.Contratos.Repositorios
{
    public interface IConfiguracionFormularioRepositorio
    {
        /// <summary>
        /// Obtiene la configuracion activa de un tipo de denuncio
        /// </summary>
        Task<Dominio.Entidades.ConfiguracionFormulario?> ObtenerActivaPorTipoDenuncio(int idTipoDenuncio);
    }
}
