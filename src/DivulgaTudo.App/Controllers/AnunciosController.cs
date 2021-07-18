using DivulgaTudo.App.ViewModels;
using DivulgaTudo.Negocio.Entidades;
using DivulgaTudo.Negocio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace DivulgaTudo.App.Controllers
{
    public class AnunciosController : Controller
    {
        private readonly IAnuncioService _servico;
        private readonly IAnuncioRepository _repositorio;
        private readonly IClienteRepository _clienteRepository;

        public AnunciosController(IAnuncioService servico, IAnuncioRepository repositorio, IClienteRepository clienteRepository)
        {
            _servico = servico;
            _repositorio = repositorio;
            _clienteRepository = clienteRepository;
        }
        public async Task<IActionResult> Index()
        {
            var anuncios = await _repositorio.ObterTodosComCliente();
            var anunciosViewModel = anuncios.Select(anuncio => new AnuncioViewModel(anuncio)).ToList();
            
            return View(anunciosViewModel);
        }
        public async Task<IActionResult> Adicionar()
        {
            var clientes = await _clienteRepository.ObterTodos();

            ViewBag.ClienteId = clientes.Select(c => new SelectListItem(c.Nome, c.Id.ToString()));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(AnuncioViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var anuncio = new Anuncio 
            {
                Nome = model.Nome,
                DataInicio = model.DataInicio,
                DataFim = model.DataFim,
                InvestimentoPorDia = model.InvestimentoPorDia,
                ClienteId = model.ClienteId,
                Ativo = model.Ativo,
            };

            await _servico.Adicionar(anuncio);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(int id)
        {
            if (id <= 0)
                return RedirectToAction("index");

            var anuncio = await _repositorio.ObterPorIdComCliente(id);

            var anuncioViewModel = new AnuncioViewModel(anuncio);

            return View(anuncioViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(AnuncioViewModel model)
        {
            if (!ModelState.IsValid)
                  return View(model);

            var anuncio = new Anuncio
            {
                Id = model.Id,
                Nome = model.Nome,
                DataInicio = model.DataInicio,
                DataFim = model.DataFim,
                Ativo = model.Ativo,
                InvestimentoPorDia  = model.InvestimentoPorDia,
                ClienteId = model.ClienteId
            };

            await _repositorio.Atualizar(anuncio);

            return RedirectToAction("Index"); 
        }

        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                if (id <= 0)
                    return RedirectToAction("Index");

                await _repositorio.Remover(id);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
