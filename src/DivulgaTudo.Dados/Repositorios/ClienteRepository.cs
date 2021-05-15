using DivulgaTudo.Dados.Contexto;
using DivulgaTudo.Negocio.Entidades;
using DivulgaTudo.Negocio.Interface;

namespace DivulgaTudo.Dados.Repositorios
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DivulgaTudoDBContexto db) : base(db)
        {
        }
    }
}
