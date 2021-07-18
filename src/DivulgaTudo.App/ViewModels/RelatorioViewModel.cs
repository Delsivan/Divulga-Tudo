using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DivulgaTudo.App.ViewModels
{
    public class RelatorioViewModel
    {
        [DisplayName("Anúncio")]
        public string TituloAnuncio { get; set; }
        public string Cliente { get; set; }

        [DisplayName("Valor total Investido")]
        public decimal ValorInvestido { get; set; }
        
        [DisplayName("Número Max. de Visualizações")]
        public double MaxVisualizacao { get; set; }

        [DisplayName("Número Max. de Cliques")]
        public double MaxClique { get; set; }

        [DisplayName("Número Max. de Compartilhamento")]
        public double MaxCompartilhamento { get; set; }

        public int ClienteId { get; set; }

        public RelatorioViewModel(string tituloAnuncio, string cliente, decimal valorInvestido, double maxVisualizacao, double maxClique, double maxCompartilhamento)
        {
            TituloAnuncio = tituloAnuncio;
            Cliente = cliente;
            ValorInvestido = valorInvestido;
            MaxVisualizacao = maxVisualizacao;
            MaxClique = maxClique;
            MaxCompartilhamento = maxCompartilhamento;
        }
    }
}