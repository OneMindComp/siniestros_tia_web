using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DenunciaSiniestro.Infraestructura.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
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
                    IdTipoDenuncio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    UrlPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    IconoUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDenuncio", x => x.IdTipoDenuncio);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfiguracionFormulario",
                columns: table => new
                {
                    IdConfiguracion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTipoDenuncio = table.Column<int>(type: "int", nullable: false),
                    EstructuraJson = table.Column<string>(type: "json", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionFormulario", x => x.IdConfiguracion);
                    table.ForeignKey(
                        name: "FK_ConfiguracionFormulario_TipoDenuncio_IdTipoDenuncio",
                        column: x => x.IdTipoDenuncio,
                        principalTable: "TipoDenuncio",
                        principalColumn: "IdTipoDenuncio",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Denuncio",
                columns: table => new
                {
                    IdDenuncio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdTipoDenuncio = table.Column<int>(type: "int", nullable: false),
                    IdConfiguracion = table.Column<int>(type: "int", nullable: false),
                    NumeroSiniestro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FechaDenuncio = table.Column<DateTime>(type: "datetime", nullable: false),
                    NombreDenunciante = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TelefonoDenunciante = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DatosBasicos = table.Column<string>(type: "json", nullable: false),
                    RespuestasFormulario = table.Column<string>(type: "json", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "pendiente"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncio", x => x.IdDenuncio);
                    table.ForeignKey(
                        name: "FK_Denuncio_ConfiguracionFormulario_IdConfiguracion",
                        column: x => x.IdConfiguracion,
                        principalTable: "ConfiguracionFormulario",
                        principalColumn: "IdConfiguracion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Denuncio_TipoDenuncio_IdTipoDenuncio",
                        column: x => x.IdTipoDenuncio,
                        principalTable: "TipoDenuncio",
                        principalColumn: "IdTipoDenuncio",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TipoDenuncio",
                columns: new[] { "IdTipoDenuncio", "Descripcion", "IconoUrl", "Nombre", "UrlPath" },
                values: new object[] { 1, "", "", "Accidente de Tránsito", "" });

            migrationBuilder.InsertData(
                table: "ConfiguracionFormulario",
                columns: new[] { "IdConfiguracion", "Activo", "EstructuraJson", "FechaCreacion", "FechaModificacion", "IdTipoDenuncio", "Version" },
                values: new object[] { 1, true, "{\"campos\":[{\"id\":\"fechaHora\",\"tipo\":\"datetime\",\"etiqueta\":\"Fecha y hora del accidente\",\"requerido\":true},{\"id\":\"lugar\",\"tipo\":\"text\",\"etiqueta\":\"Lugar del accidente\",\"requerido\":true,\"placeholder\":\"Dirección exacta\"},{\"id\":\"descripcion\",\"tipo\":\"textarea\",\"etiqueta\":\"Descripción del accidente\",\"requerido\":true,\"maxLength\":500},{\"id\":\"huboDaniosPersonales\",\"tipo\":\"boolean\",\"etiqueta\":\"¿Hubo daños personales?\",\"requerido\":true},{\"id\":\"vehiculosInvolucrados\",\"tipo\":\"number\",\"etiqueta\":\"Número de vehículos involucrados\",\"requerido\":true,\"min\":1}]}", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1 });

            migrationBuilder.InsertData(
                table: "Denuncio",
                columns: new[] { "IdDenuncio", "DatosBasicos", "Estado", "FechaActualizacion", "FechaCreacion", "FechaDenuncio", "IdConfiguracion", "IdTipoDenuncio", "NombreDenunciante", "NumeroSiniestro", "RespuestasFormulario", "TelefonoDenunciante" },
                values: new object[] { 1, "{\"email\":\"juan.perez@email.com\",\"direccion\":\"Av. 6 de Agosto #1234, La Paz\",\"ci\":\"1234567 LP\"}", "pendiente", new DateTime(2024, 9, 15, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 15, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2024, 9, 15, 14, 30, 0, 0, DateTimeKind.Utc), 1, 1, "Juan Carlos Pérez García", "SIN-2024-000001", "{\"fechaHora\":\"2024-09-15T14:30:00\",\"lugar\":\"Cruce Av. Arce y Calle 20 de Octubre\",\"descripcion\":\"Colisión en intersección, el otro vehículo no respetó el semáforo en rojo\",\"huboDaniosPersonales\":false,\"vehiculosInvolucrados\":2}", "+591-70123456" });

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
