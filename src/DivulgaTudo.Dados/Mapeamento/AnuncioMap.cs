using DivulgaTudo.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivulgaTudo.Dados.Mapeamento
{
    class AnuncioMap : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.DataInicio)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.DataFim)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(a => a.InvestimentoPorDia)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(a => a.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(a => a.ClienteId)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Anuncios");

        }
    }
}
