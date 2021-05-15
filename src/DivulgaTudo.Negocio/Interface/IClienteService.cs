using DivulgaTudo.Negocio.Entidades;
using System.Threading.Tasks;

namespace DivulgaTudo.Negocio.Interface
{
    public interface IClienteService
    {
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
    }
}
