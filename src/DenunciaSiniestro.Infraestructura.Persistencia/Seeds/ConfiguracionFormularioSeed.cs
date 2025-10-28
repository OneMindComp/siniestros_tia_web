using DenunciaSiniestro.Dominio.Entidades;
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
                ConfiguracionFormulario.Crear(
                    id: 1,
                    idTipoDenuncio: 1,
                    estructuraJson: @"{""Secciones"":[{""Campos"":[{""Tipo"":0,""Nombre"":""NumeroPoliza"",""Requerido"":true,""Descripcion"":""Numero de poliza""},{""Tipo"":0,""Nombre"":""Patente"",""Requerido"":true,""Descripcion"":""Patente""},{""Tipo"":0,""Nombre"":""NumeroMotor"",""Requerido"":true,""Descripcion"":""Numero de motor""}],""Nombre"":""DatosVehiculo"",""Descripcion"":""Informacion del vehiculo involucrado en el accidente""},{""Campos"":[{""Tipo"":0,""Nombre"":""Nombre"",""Requerido"":true,""Descripcion"":""Nombre del denunciante""},{""Tipo"":0,""Nombre"":""Apellidos"",""Requerido"":true,""Descripcion"":""Apellidos del denunciante""},{""Tipo"":1,""Nombre"":""Rut"",""Requerido"":true,""Descripcion"":""Rut del denunciante""},{""Tipo"":0,""Nombre"":""Celular"",""Requerido"":true,""Descripcion"":""Celular / Telefono del denunciante""},{""Tipo"":9,""Nombre"":""Mail"",""Requerido"":true,""Descripcion"":""Correo electronico del denunciante""}],""Nombre"":""DatosDenunciante"",""Descripcion"":""Informacion personal del denunciante""},{""Campos"":[{""Tipo"":0,""Nombre"":""Nombre"",""Requerido"":true,""Descripcion"":""Nombre del conductor""},{""Tipo"":1,""Nombre"":""Rut"",""Requerido"":true,""Descripcion"":""Rut del conductor""}],""Nombre"":""DatosConductor"",""Descripcion"":""Informacion sobre el conductor involucrado""},{""Campos"":[{""Tipo"":0,""Nombre"":""Nombre"",""Requerido"":true,""Descripcion"":""Nombre del lesionado""},{""Tipo"":1,""Nombre"":""Rut"",""Requerido"":true,""Descripcion"":""Rut del lesionado""},{""Tipo"":0,""Nombre"":""Celular"",""Requerido"":true,""Descripcion"":""Celular / Telefono del lesionado""},{""Tipo"":9,""Nombre"":""Mail"",""Requerido"":true,""Descripcion"":""Correo electronico del lesionado""}],""Nombre"":""DatosLesionado"",""Descripcion"":""Informacion sobre el lesionado en el accidente""},{""Campos"":[{""Tipo"":2,""Nombre"":""Ubicacion"",""Requerido"":true,""Descripcion"":""Ubicacion en la que se produjo el accidente""},{""Tipo"":3,""Nombre"":""Fecha"",""Requerido"":true,""Descripcion"":""Fecha siniestro""},{""Tipo"":2,""Nombre"":""Relato"",""Requerido"":true,""Descripcion"":""Relato del accidente""},{""Tipo"":4,""Nombre"":""NumeroPartePolicial"",""Requerido"":true,""Descripcion"":""Numero Parte Policial""},{""Tipo"":9,""Nombre"":""recordType"",""Opciones"":[{""Etiqueta"":""--Ninguno--"",""Valor"":""""},{""Etiqueta"":""Caso General"",""Valor"":""012Uf0000003ixO""},{""Etiqueta"":""Caso Glia"",""Valor"":""012Uf000003cYuz""},{""Etiqueta"":""Caso Proteccion Patrimonial"",""Valor"":""012Uf000000JYHJ""},{""Etiqueta"":""Caso Siniestro"",""Valor"":""0124T00000054Ym""}],""Requerido"":false,""Descripcion"":""Tipo de registro del caso""}],""Nombre"":""DatosSiniestro"",""Descripcion"":""Informacion del siniestro reportado""}]}",
                    version: 1,
                    activo: true,
                    fechaCreacion: new System.DateTime(2025, 10, 23, 0, 0, 0, System.DateTimeKind.Utc),
                    fechaModificacion: new System.DateTime(2025, 10, 23, 0, 0, 0, System.DateTimeKind.Utc)
                )
            );
        }
    }
}