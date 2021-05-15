using DivulgaTudo.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DivulgaTudo.Dados.Mapeamento
{
    class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Cliente : Anuncios
            builder.HasMany(c => c.Anuncios)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);

            builder.ToTable("Clientes");
        }
    }
}
