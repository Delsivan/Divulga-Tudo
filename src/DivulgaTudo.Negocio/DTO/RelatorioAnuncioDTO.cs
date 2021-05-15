namespace DivulgaTudo.Negocio.DTO
{
    public class RelatorioAnuncioDTO
    {
        public string TituloAnuncio { get; set; }
        public string Cliente { get; set; }
        public decimal ValorInvestido { get; set; }
        public double MaxVisualizacao { get; set; }
        public double MaxClique { get; set; }
        public double MaxCompartilhamento  { get; set; }

        public RelatorioAnuncioDTO(string tituloAnuncio, string cliente, decimal valorInvestido, double maxVisualizacao, double maxClique, double maxCompartilhamento) 
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
