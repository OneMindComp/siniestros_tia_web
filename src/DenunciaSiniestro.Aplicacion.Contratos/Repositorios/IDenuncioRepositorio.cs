using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Dominio.Filtros;

namespace DenunciaSiniestro.Aplicacion.Contratos.Repositorios
{
    public interface IDenuncioRepositorio : IRepositorio<Denuncio, long>, IRepositorioBusqueda<Denuncio, FiltroDenuncio>
    {

    }
}
