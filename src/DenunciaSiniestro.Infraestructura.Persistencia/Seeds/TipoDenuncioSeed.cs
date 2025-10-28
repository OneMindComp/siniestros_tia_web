using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Infraestructura.Persistencia.Seeds.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Seeds
{
    internal class TipoDenuncioSeed : ISeed
    {
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<TipoDenuncio>().HasData(
                 TipoDenuncio.Crear
                (
                    nombre: "SOAP",
                    descripcion: "Denuncias relacionadas con accidentes de tránsito SOAP.",
                    urlPath: "accidente-transito",
                    iconoUrl: "https://southbridgeseguros.cl/media/wysiwyg/sb-seguros/soap_icon.png",
                    activo: true
                )
            );
        }
    }
}
