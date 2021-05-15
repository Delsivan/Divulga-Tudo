using DivulgaTudo.Negocio.Entidades;
using DivulgaTudo.Negocio.Interface;
using System.Threading.Tasks;

namespace DivulgaTudo.Negocio.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repositorio;

        public ClienteService(IClienteRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _repositorio.Adicionar(cliente);
            return;
        }

        public async Task Atualizar(Cliente cliente)
        {
            await _repositorio.Atualizar(cliente);
            return;
        }
    }
}
