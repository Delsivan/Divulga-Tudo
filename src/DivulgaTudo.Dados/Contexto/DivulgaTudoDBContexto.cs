using DivulgaTudo.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DivulgaTudo.Dados.Contexto
{
    public class DivulgaTudoDBContexto : DbContext
    {
        public DivulgaTudoDBContexto(DbContextOptions<DivulgaTudoDBContexto> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }

    }
}
