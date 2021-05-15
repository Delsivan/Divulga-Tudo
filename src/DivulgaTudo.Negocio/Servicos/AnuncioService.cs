using DivulgaTudo.Negocio.Entidades;
using DivulgaTudo.Negocio.Interface;
using System.Threading.Tasks;

namespace DivulgaTudo.Negocio.Servicos
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _repositorio;

        public AnuncioService(IAnuncioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Adicionar(Anuncio anuncio)
        {
            await _repositorio.Adicionar(anuncio);
            return;
        }
    }
}
