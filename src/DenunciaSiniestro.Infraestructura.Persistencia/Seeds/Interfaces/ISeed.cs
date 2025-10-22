using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Seeds.Interfaces
{
    internal interface ISeed
    {
        void Seed(ModelBuilder builder);
    }
}
