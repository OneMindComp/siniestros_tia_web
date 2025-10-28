using DenunciaSiniestro.Aplicacion.Contratos.Repositorios;
using DenunciaSiniestro.Dominio.Filtros;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Repositorios
{
    /// <summary>
    /// Implementacion del repositorio de Denuncio con operaciones especificas
    /// </summary>
    public class DenuncioRepositorio : IDenuncioRepositorio
    {
        public Task<Dominio.Entidades.Denuncio> Actualizar(Dominio.Entidades.Denuncio aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<Dominio.Entidades.Denuncio> Agregar(Dominio.Entidades.Denuncio aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dominio.Entidades.Denuncio>> Agregar(List<Dominio.Entidades.Denuncio> aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<Dominio.Entidades.Denuncio> Buscar(FiltroDenuncio filtro)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dominio.Entidades.Denuncio>> Buscarlista(FiltroDenuncio filtro)
        {
            throw new NotImplementedException();
        }

        public Task<Dominio.Entidades.Denuncio> Crear(Dominio.Entidades.Denuncio denuncio)
        {
            throw new NotImplementedException();
        }

        public Task<Dominio.Entidades.Denuncio?> Editar(Dominio.Entidades.Denuncio denuncio)
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(Dominio.Entidades.Denuncio aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<Dominio.Entidades.Denuncio?> Obtener(string numeroSeguimiento)
        {
            throw new NotImplementedException();
        }

        public Task<Dominio.Entidades.Denuncio> Obtener(long id)
        {
            throw new NotImplementedException();
        }
    }
}



