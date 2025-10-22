using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;
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
                new Denuncio
                {
                    IdDenuncio = 1,
                    IdTipoDenuncio = 1,
                    IdConfiguracion = 1,
                    NumeroSiniestro = "SIN-2024-000001",
                    FechaDenuncio = new System.DateTime(2024, 9, 15, 14, 30, 0, System.DateTimeKind.Utc),
                    NombreDenunciante = "Juan Carlos Pérez García",
                    TelefonoDenunciante = "+591-70123456",
                    DatosBasicos = @"{""email"":""juan.perez@email.com"",""direccion"":""Av. 6 de Agosto #1234, La Paz"",""ci"":""1234567 LP""}",
                    RespuestasFormulario = @"{""fechaHora"":""2024-09-15T14:30:00"",""lugar"":""Cruce Av. Arce y Calle 20 de Octubre"",""descripcion"":""Colisión en intersección, el otro vehículo no respetó el semáforo en rojo"",""huboDaniosPersonales"":false,""vehiculosInvolucrados"":2}",
                    Estado = "pendiente",
                    FechaCreacion = new System.DateTime(2024, 9, 15, 14, 30, 0, System.DateTimeKind.Utc),
                    FechaActualizacion = new System.DateTime(2024, 9, 15, 14, 30, 0, System.DateTimeKind.Utc)
                }
            );
        }
    }
}