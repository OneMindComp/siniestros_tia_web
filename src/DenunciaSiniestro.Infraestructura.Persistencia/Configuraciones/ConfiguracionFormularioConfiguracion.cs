using DenunciaSiniestro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Configuraciones
{
    /// <summary>
    /// Configuracion de Entity Framework para la entidad ConfiguracionFormularioModelo
    /// </summary>
    public class ConfiguracionFormularioConfiguracion : IEntityTypeConfiguration<ConfiguracionFormulario>
    {
        public void Configure(EntityTypeBuilder<ConfiguracionFormulario> builder)
        {
            builder.ToTable("ConfiguracionFormulario");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.IdTipoDenuncio)
                .HasColumnName("IdTipoDenuncio")
                .IsRequired();

            builder.Property(c => c.EstructuraJson)
                .HasColumnName("EstructuraJson")
                .HasColumnType("json")
                .IsRequired();

            builder.Property(c => c.Version)
                .HasColumnName("Version")
                .IsRequired();

            builder.Property(c => c.Activo)
                .HasColumnName("Activo")
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(c => c.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.FechaModificacion)
                .HasColumnName("FechaModificacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");
            // Ignorar propiedad Secciones (no se persiste, solo se usa en memoria)
            builder.Ignore(c => c.Secciones);
            // Relaciones
            builder.HasOne(c => c.TipoDenuncio)
                .WithMany(t => t.ConfiguracionesFormulario)
                .HasForeignKey(c => c.IdTipoDenuncio)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Denuncios)
                .WithOne(d => d.ConfiguracionFormulario)
                .HasForeignKey(d => d.IdConfiguracion)
                .OnDelete(DeleteBehavior.Restrict);

            // Indices
            builder.HasIndex(c => new { c.IdTipoDenuncio, c.Version }).IsUnique();
            builder.HasIndex(c => new { c.IdTipoDenuncio, c.Activo });
        }
    }
}
