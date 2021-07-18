using DivulgaTudo.App.ViewModels;
using DivulgaTudo.Negocio.Entidades;
using DivulgaTudo.Negocio.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DivulgaTudo.App.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _servico;
        private readonly IClienteRepository _repositorio;

        public ClienteController(IClienteService servico, IClienteRepository repositorio)
        {
            _servico = servico;
            _repositorio = repositorio;
        }
        public async Task<IActionResult> Index()
        {
            var clientes = await _repositorio.ObterTodos();
            return View(clientes);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var cliente = new Cliente 
            {
                Nome = model.Nome,
                Email = model.Email
            };

            await _servico.Adicionar(cliente);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Atualizar(int id)
        {
            if (id <= 0)
                return RedirectToAction("Index");

            var cliente = await _repositorio.ObterPorId(id);

            if (cliente == null)
                return View("Index");

            var model = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var cliente = new Cliente 
            {
                Id = model.Id,
                Nome = model.Nome,
                Email = model.Email
            };

            await _servico.Atualizar(cliente);

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
