using DivulgaTudo.Negocio.DTO;
using DivulgaTudo.Negocio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivulgaTudo.Negocio.Servicos
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public RelatorioService(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public async Task<List<RelatorioAnuncioDTO>> GerarRelatorioAnuncio(int clienteId, DateTime dataInicio, DateTime dataFim)
        {
            var anuncios = await _anuncioRepository.ObterPorDateEClienteId(clienteId, dataInicio, dataFim);

            return anuncios.Select(r =>
                new RelatorioAnuncioDTO
                (
                    r.Nome,
                    r.Cliente?.Nome,
                    CalculaTotalInvestido(r.InvestimentoPorDia, r.DataInicio, r.DataFim),
                    CalculaTotalViews(r.InvestimentoPorDia), 
                    Math.Ceiling(CalculaCliques(CalculaTotalViews(r.InvestimentoPorDia))),
                    CalculaCompartilhamentos(CalculaTotalViews(r.InvestimentoPorDia))
                 )
           ).ToList();
        }

        private decimal CalculaTotalInvestido(decimal valorInvestidoPorDia, DateTime dataInicio, DateTime dataFim) 
        {
            int qtdDiasAnuncio = dataFim.Subtract(dataInicio).Days;

            return qtdDiasAnuncio * valorInvestidoPorDia; 
        }

        private double CalculaCliques(double qtdViews) 
        {
            return (qtdViews * 0.12);
        }

        private double CalculaCompartilhamentos(double qtdCliques)
        {
            return ((qtdCliques * 0.15));
        }

        private double CalcularQtdPessoasCompartilharam(double qtdViews) 
        {
            double qtdCliques = CalculaCliques(qtdViews);
            double qtdPessoasCompartilhamento = CalculaCompartilhamentos(qtdCliques);

            return Math.Round(qtdPessoasCompartilhamento);
        }

        private double QtdViewsPorCompartilhamento(double totalViews, double qtdPessoasCompartilharam, double qtdTotalCompartilhamento)
        {
            if (qtdTotalCompartilhamento != 3 && qtdPessoasCompartilharam > 1) 
            {
                var views = qtdPessoasCompartilharam * 40;
                totalViews += views;

                var totalPessoasCompartilharam = CalcularQtdPessoasCompartilharam(views);

                totalViews = QtdViewsPorCompartilhamento(totalViews, totalPessoasCompartilharam, qtdTotalCompartilhamento + 1);

                return totalViews;
            }
            
            return totalViews;
        }

        private double CalculaTotalViews(decimal valorInvestido)
        {
            int qtdCompartilhamentos = 0;

            var views = (double)(valorInvestido * 30);

            var pessoasCompartilharam = CalcularQtdPessoasCompartilharam(views);

            views = QtdViewsPorCompartilhamento(views, pessoasCompartilharam, qtdCompartilhamentos);

            return views;
        }
    }
}
