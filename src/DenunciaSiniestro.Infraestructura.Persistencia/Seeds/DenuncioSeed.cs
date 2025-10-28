using DenunciaSiniestro.Dominio.Entidades;
using DenunciaSiniestro.Infraestructura.Persistencia.Seeds.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Seeds
{
    /// <summary>
    /// Seeder para Denuncio - Crea un denuncio de ejemplo de Accidente de Transito
    /// </summary>
    internal class DenuncioSeed : ISeed
    {
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<Denuncio>().HasData(
                Denuncio.Crear(
                    idTipoDenuncio : 1,
                    idConfiguracion : 1,
                    fechaDenuncio : new System.DateTime(2024, 9, 15, 14, 30, 0, System.DateTimeKind.Utc),
                    nombreDenunciante : "Juan Carlos Pérez García",
                    telefonoDenunciante : "+591-70123456"
                )
            );
        }
    }
}