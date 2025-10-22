using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Configuraciones
{
    /// <summary>
    /// Configuracion de Entity Framework para la entidad TipoDenuncio
    /// </summary>
    public class TipoDenuncioConfiguracion : IEntityTypeConfiguration<TipoDenuncio>
    {
        public void Configure(EntityTypeBuilder<TipoDenuncio> builder)
        {
            builder.ToTable("TipoDenuncio");

            builder.HasKey(t => t.IdTipoDenuncio);
            builder.Property(t => t.IdTipoDenuncio)
                .HasColumnName("IdTipoDenuncio")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("text");

            builder.Property(t => t.UrlPath)
                .HasColumnName("UrlPath")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.IconoUrl)
                .HasColumnName("IconoUrl")
                .HasMaxLength(500);

            builder.Property(t => t.Activo)
                .HasColumnName("Activo")
                .IsRequired()
                .HasDefaultValue(true);

            // Relaciones
            builder.HasMany(t => t.ConfiguracionesFormulario)
                .WithOne(c => c.TipoDenuncio)
                .HasForeignKey(c => c.IdTipoDenuncio)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Denuncios)
                .WithOne(d => d.TipoDenuncio)
                .HasForeignKey(d => d.IdTipoDenuncio)
                .OnDelete(DeleteBehavior.Restrict);

            // Indices
            builder.HasIndex(t => t.UrlPath).IsUnique();
            builder.HasIndex(t => t.Activo);
        }
    }
}
