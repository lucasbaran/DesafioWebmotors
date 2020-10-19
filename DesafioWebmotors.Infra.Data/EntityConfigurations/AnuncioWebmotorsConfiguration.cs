using DesafioWebmotors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioWebmotors.Infra.Data.EntityConfigurations
{
    public class AnuncioWebmotorsConfiguration : IEntityTypeConfiguration<AnuncioWebmotors>
    {
        public void Configure(EntityTypeBuilder<AnuncioWebmotors> builder)
        {
            builder.ToTable("AnuncioWebmotors");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Marca)
                .HasColumnType("varchar(45)")
                .HasColumnName("marca")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Modelo)
                .HasColumnType("varchar(45)")
                .HasColumnName("modelo")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Versao)
                .HasColumnType("varchar(45)")
                .HasColumnName("versao")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Ano)
                .HasColumnType("INT")
                .HasColumnName("ano")
                .IsRequired();

            builder.Property(x => x.Quilometragem)
                .HasColumnType("INT")
                .HasColumnName("quilometragem")
                .IsRequired();

            builder.Property(x => x.Observacao)
                .HasColumnType("text")
                .HasColumnName("observacao")
                .IsRequired();

        }
    }
}
