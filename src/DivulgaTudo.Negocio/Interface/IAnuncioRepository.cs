using DivulgaTudo.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivulgaTudo.Negocio.Interface
{
    public interface IAnuncioRepository : IBaseRepository<Anuncio>
    {
        Task<List<Anuncio>> ObterTodosComCliente();
        Task<Anuncio> ObterPorIdComCliente(int id);
        Task<List<Anuncio>> ObterPorDateEClienteId(int clienteId, DateTime dataInicio, DateTime dataFim);
    }
}
