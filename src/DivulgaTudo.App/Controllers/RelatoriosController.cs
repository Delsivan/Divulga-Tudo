using DivulgaTudo.App.ViewModels;
using DivulgaTudo.Negocio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DivulgaTudo.App.Controllers
{
    public class RelatoriosController : Controller
    {
        private IRelatorioService _service;
        private IClienteRepository _clienteRepository;

        public RelatoriosController(IRelatorioService service, IClienteRepository clienteRepository)
        {
            _service = service;
            _clienteRepository = clienteRepository;
        }

        public async Task<IActionResult> Index(int clienteId, string dataInicio, string dataFim)
        {
            var clientes = await _clienteRepository.ObterTodos();

            ViewBag.ClienteId = clientes.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

            if (clienteId <= 0 && string.IsNullOrWhiteSpace(dataInicio) && string.IsNullOrWhiteSpace(dataFim))
                return View();

            var dateInicio = DateTime.Parse(dataInicio);
            var dateFim = DateTime.Parse(dataFim);

            var anuncios = await _service.GerarRelatorioAnuncio(clienteId, dateInicio, dateFim);

            var anunciosViewModel = anuncios.Select(r => new RelatorioViewModel(r.TituloAnuncio, r.Cliente,r.ValorInvestido ,r.MaxVisualizacao, r.MaxClique, r.MaxCompartilhamento));
           
            return View(anunciosViewModel);
        }
    }
}
