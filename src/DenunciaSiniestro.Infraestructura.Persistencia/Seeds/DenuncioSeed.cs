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
            var denuncio = Denuncio.Crear(
                idTipoDenuncio: 1,
                idConfiguracion: 1,
                fechaDenuncio: new System.DateTime(2024, 9, 15, 14, 30, 0, System.DateTimeKind.Utc),
                nombreDenunciante: "Juan Carlos Perez Garcia",
                telefonoDenunciante: "+591-70123456"
            );

            // Establecer propiedades requeridas para el seed
            denuncio.EstablecerIdDenuncio(1);
            denuncio.EstablecerContenidoFormulario(
                respuestasFormulario: @"{""DatosVehiculo"":{""NumeroPoliza"":""123456"",""Patente"":""ABC123"",""NumeroMotor"":""MOT123""}}",
                numeroSeguimiento: "SEED-2024-0001"
            );
            denuncio.EstablecerEstadoYFechaIngreso(
                estado: "Ingresado",
                fechaCreacion: new System.DateTime(2024, 9, 15, 14, 30, 0, System.DateTimeKind.Utc)
            );

            builder.Entity<Denuncio>().HasData(denuncio);
        }
    }
}