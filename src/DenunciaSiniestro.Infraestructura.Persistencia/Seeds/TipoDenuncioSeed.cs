using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Infraestructura.Persistencia.Seeds.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Seeds
{
    /// <summary>
    /// Seeder para TipoDenuncio - Crea tipo de denuncia SOAP
    /// </summary>
    internal class TipoDenuncioSeed : ISeed
    {
        public void Seed(ModelBuilder builder)
        {
            var tipoDenuncio = TipoDenuncio.Crear(
                nombre: "SOAP",
                descripcion: "Denuncias relacionadas con accidentes de transito SOAP.",
                urlPath: "accidente-transito",
                iconoUrl: "https://southbridgeseguros.cl/media/wysiwyg/sb-seguros/soap_icon.png",
                activo: true
            );

            // Asignar el Id explicitamente para el seed
            tipoDenuncio.AsignarId(1);

            builder.Entity<TipoDenuncio>().HasData(tipoDenuncio);
        }
    }
}