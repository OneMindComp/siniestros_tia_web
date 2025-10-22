using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Configuraciones
{
    /// <summary>
    /// Configuracion de Entity Framework para la entidad Denuncio
    /// </summary>
    public class DenuncioConfiguracion : IEntityTypeConfiguration<Denuncio>
    {
        public void Configure(EntityTypeBuilder<Denuncio> builder)
        {
            builder.ToTable("Denuncio");

            builder.HasKey(d => d.IdDenuncio);
            builder.Property(d => d.IdDenuncio)
                .HasColumnName("IdDenuncio")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.IdTipoDenuncio)
                .HasColumnName("IdTipoDenuncio")
                .IsRequired();

            builder.Property(d => d.IdConfiguracion)
                .HasColumnName("IdConfiguracion")
                .IsRequired();

            builder.Property(d => d.NumeroSiniestro)
                .HasColumnName("NumeroSiniestro")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.FechaDenuncio)
                .HasColumnName("FechaDenuncio")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(d => d.NombreDenunciante)
                .HasColumnName("NombreDenunciante")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.TelefonoDenunciante)
                .HasColumnName("TelefonoDenunciante")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.DatosBasicos)
                .HasColumnName("DatosBasicos")
                .HasColumnType("json");

            builder.Property(d => d.RespuestasFormulario)
                .HasColumnName("RespuestasFormulario")
                .HasColumnType("json")
                .IsRequired();

            builder.Property(d => d.Estado)
                .HasColumnName("Estado")
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("pendiente");

            builder.Property(d => d.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(d => d.FechaActualizacion)
                .HasColumnName("FechaActualizacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

            // Relaciones
            builder.HasOne(d => d.TipoDenuncio)
                .WithMany(t => t.Denuncios)
                .HasForeignKey(d => d.IdTipoDenuncio)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ConfiguracionFormulario)
                .WithMany(c => c.Denuncios)
                .HasForeignKey(d => d.IdConfiguracion)
                .OnDelete(DeleteBehavior.Restrict);

            // Indices
            builder.HasIndex(d => d.NumeroSiniestro).IsUnique();
            builder.HasIndex(d => d.Estado);
            builder.HasIndex(d => d.FechaDenuncio);
            builder.HasIndex(d => new { d.IdTipoDenuncio, d.Estado });
        }
    }
}
