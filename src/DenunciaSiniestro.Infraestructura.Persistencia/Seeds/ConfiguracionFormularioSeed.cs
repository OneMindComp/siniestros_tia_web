using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;
using DenunciaSiniestro.Infraestructura.Persistencia.Seeds.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Seeds
{
    /// <summary>
    /// Seeder para ConfiguracionFormulario - Crea una configuracion para Accidente de Transito
    /// </summary>
    internal class ConfiguracionFormularioSeed : ISeed
    {
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<ConfiguracionFormulario>().HasData(
                new ConfiguracionFormulario
                {
                    IdConfiguracion = 1,
                    IdTipoDenuncio = 1,
                    EstructuraJson = @"{""campos"":[{""id"":""fechaHora"",""tipo"":""datetime"",""etiqueta"":""Fecha y hora del accidente"",""requerido"":true},{""id"":""lugar"",""tipo"":""text"",""etiqueta"":""Lugar del accidente"",""requerido"":true,""placeholder"":""Dirección exacta""},{""id"":""descripcion"",""tipo"":""textarea"",""etiqueta"":""Descripción del accidente"",""requerido"":true,""maxLength"":500},{""id"":""huboDaniosPersonales"",""tipo"":""boolean"",""etiqueta"":""¿Hubo daños personales?"",""requerido"":true},{""id"":""vehiculosInvolucrados"",""tipo"":""number"",""etiqueta"":""Número de vehículos involucrados"",""requerido"":true,""min"":1}]}",
                    Version = 1,
                    Activo = true,
                    FechaCreacion = new System.DateTime(2024, 1, 1, 0, 0, 0, System.DateTimeKind.Utc),
                    FechaModificacion = new System.DateTime(2024, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)
                }
            );
        }
    }
}
