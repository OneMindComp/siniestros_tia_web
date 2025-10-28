using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DenunciaSiniestro.Infraestructura.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class DenuncioSiniestroInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDenuncio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    UrlPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    IconoUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDenuncio", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfiguracionFormulario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTipoDenuncio = table.Column<long>(type: "bigint", nullable: false),
                    EstructuraJson = table.Column<string>(type: "json", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionFormulario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracionFormulario_TipoDenuncio_IdTipoDenuncio",
                        column: x => x.IdTipoDenuncio,
                        principalTable: "TipoDenuncio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Denuncio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTipoDenuncio = table.Column<long>(type: "bigint", nullable: false),
                    IdConfiguracion = table.Column<long>(type: "bigint", nullable: false),
                    NumeroSiniestro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FechaDenuncio = table.Column<DateTime>(type: "datetime", nullable: false),
                    NombreDenunciante = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TelefonoDenunciante = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DatosBasicos = table.Column<string>(type: "json", nullable: false),
                    RespuestasFormulario = table.Column<string>(type: "json", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "pendiente"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"),
                    NumeroSeguimiento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denuncio_ConfiguracionFormulario_IdConfiguracion",
                        column: x => x.IdConfiguracion,
                        principalTable: "ConfiguracionFormulario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Denuncio_TipoDenuncio_IdTipoDenuncio",
                        column: x => x.IdTipoDenuncio,
                        principalTable: "TipoDenuncio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TipoDenuncio",
                columns: new[] { "Id", "Activo", "Descripcion", "IconoUrl", "Nombre", "UrlPath" },
                values: new object[] { 1L, true, "Denuncias relacionadas con accidentes de transito SOAP.", "https://southbridgeseguros.cl/media/wysiwyg/sb-seguros/soap_icon.png", "SOAP", "accidente-transito" });

            migrationBuilder.InsertData(
                table: "ConfiguracionFormulario",
                columns: new[] { "Id", "Activo", "EstructuraJson", "FechaCreacion", "FechaModificacion", "IdTipoDenuncio", "Version" },
                values: new object[] { 1L, true, "{\"Secciones\":[{\"Campos\":[{\"Tipo\":0,\"Nombre\":\"NumeroPoliza\",\"Requerido\":true,\"Descripcion\":\"Numero de poliza\"},{\"Tipo\":0,\"Nombre\":\"Patente\",\"Requerido\":true,\"Descripcion\":\"Patente\"},{\"Tipo\":0,\"Nombre\":\"NumeroMotor\",\"Requerido\":true,\"Descripcion\":\"Numero de motor\"}],\"Nombre\":\"DatosVehiculo\",\"Descripcion\":\"Informacion del vehiculo involucrado en el accidente\"},{\"Campos\":[{\"Tipo\":0,\"Nombre\":\"Nombre\",\"Requerido\":true,\"Descripcion\":\"Nombre del denunciante\"},{\"Tipo\":0,\"Nombre\":\"Apellidos\",\"Requerido\":true,\"Descripcion\":\"Apellidos del denunciante\"},{\"Tipo\":1,\"Nombre\":\"Rut\",\"Requerido\":true,\"Descripcion\":\"Rut del denunciante\"},{\"Tipo\":0,\"Nombre\":\"Celular\",\"Requerido\":true,\"Descripcion\":\"Celular / Telefono del denunciante\"},{\"Tipo\":9,\"Nombre\":\"Mail\",\"Requerido\":true,\"Descripcion\":\"Correo electronico del denunciante\"}],\"Nombre\":\"DatosDenunciante\",\"Descripcion\":\"Informacion personal del denunciante\"},{\"Campos\":[{\"Tipo\":0,\"Nombre\":\"Nombre\",\"Requerido\":true,\"Descripcion\":\"Nombre del conductor\"},{\"Tipo\":1,\"Nombre\":\"Rut\",\"Requerido\":true,\"Descripcion\":\"Rut del conductor\"}],\"Nombre\":\"DatosConductor\",\"Descripcion\":\"Informacion sobre el conductor involucrado\"},{\"Campos\":[{\"Tipo\":0,\"Nombre\":\"Nombre\",\"Requerido\":true,\"Descripcion\":\"Nombre del lesionado\"},{\"Tipo\":1,\"Nombre\":\"Rut\",\"Requerido\":true,\"Descripcion\":\"Rut del lesionado\"},{\"Tipo\":0,\"Nombre\":\"Celular\",\"Requerido\":true,\"Descripcion\":\"Celular / Telefono del lesionado\"},{\"Tipo\":9,\"Nombre\":\"Mail\",\"Requerido\":true,\"Descripcion\":\"Correo electronico del lesionado\"}],\"Nombre\":\"DatosLesionado\",\"Descripcion\":\"Informacion sobre el lesionado en el accidente\"},{\"Campos\":[{\"Tipo\":2,\"Nombre\":\"Ubicacion\",\"Requerido\":true,\"Descripcion\":\"Ubicacion en la que se produjo el accidente\"},{\"Tipo\":3,\"Nombre\":\"Fecha\",\"Requerido\":true,\"Descripcion\":\"Fecha siniestro\"},{\"Tipo\":2,\"Nombre\":\"Relato\",\"Requerido\":true,\"Descripcion\":\"Relato del accidente\"},{\"Tipo\":4,\"Nombre\":\"NumeroPartePolicial\",\"Requerido\":true,\"Descripcion\":\"Numero Parte Policial\"},{\"Tipo\":9,\"Nombre\":\"recordType\",\"Opciones\":[{\"Etiqueta\":\"--Ninguno--\",\"Valor\":\"\"},{\"Etiqueta\":\"Caso General\",\"Valor\":\"012Uf0000003ixO\"},{\"Etiqueta\":\"Caso Glia\",\"Valor\":\"012Uf000003cYuz\"},{\"Etiqueta\":\"Caso Proteccion Patrimonial\",\"Valor\":\"012Uf000000JYHJ\"},{\"Etiqueta\":\"Caso Siniestro\",\"Valor\":\"0124T00000054Ym\"}],\"Requerido\":false,\"Descripcion\":\"Tipo de registro del caso\"}],\"Nombre\":\"DatosSiniestro\",\"Descripcion\":\"Informacion del siniestro reportado\"}]}", new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), 1L, 1 });

            migrationBuilder.InsertData(
                table: "Denuncio",
                columns: new[] { "Id", "DatosBasicos", "Estado", "FechaCreacion", "FechaDenuncio", "IdConfiguracion", "IdTipoDenuncio", "NombreDenunciante", "NumeroSeguimiento", "NumeroSiniestro", "RespuestasFormulario", "TelefonoDenunciante" },
                values: new object[] { 1L, "{}", "Ingresado", new DateTime(2024, 9, 15, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 15, 14, 30, 0, 0, DateTimeKind.Utc), 1L, 1L, "Juan Carlos Perez Garcia", "SEED-2024-0001", null, "{\"DatosVehiculo\":{\"NumeroPoliza\":\"123456\",\"Patente\":\"ABC123\",\"NumeroMotor\":\"MOT123\"}}", "+591-70123456" });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionFormulario_IdTipoDenuncio_Activo",
                table: "ConfiguracionFormulario",
                columns: new[] { "IdTipoDenuncio", "Activo" });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionFormulario_IdTipoDenuncio_Version",
                table: "ConfiguracionFormulario",
                columns: new[] { "IdTipoDenuncio", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Denuncio_Estado",
                table: "Denuncio",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncio_FechaDenuncio",
                table: "Denuncio",
                column: "FechaDenuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncio_IdConfiguracion",
                table: "Denuncio",
                column: "IdConfiguracion");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncio_IdTipoDenuncio_Estado",
                table: "Denuncio",
                columns: new[] { "IdTipoDenuncio", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_Denuncio_NumeroSeguimiento",
                table: "Denuncio",
                column: "NumeroSeguimiento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Denuncio_NumeroSiniestro",
                table: "Denuncio",
                column: "NumeroSiniestro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDenuncio_Activo",
                table: "TipoDenuncio",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDenuncio_UrlPath",
                table: "TipoDenuncio",
                column: "UrlPath",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denuncio");

            migrationBuilder.DropTable(
                name: "ConfiguracionFormulario");

            migrationBuilder.DropTable(
                name: "TipoDenuncio");
        }
    }
}
