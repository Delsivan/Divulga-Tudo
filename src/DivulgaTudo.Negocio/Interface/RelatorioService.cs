using DivulgaTudo.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivulgaTudo.Negocio.Interface
{
    public interface IRelatorioService
    {
        Task<List<RelatorioAnuncioDTO>> GerarRelatorioAnuncio(int clienteId, DateTime dataInicio, DateTime dataFim);
    }
}
