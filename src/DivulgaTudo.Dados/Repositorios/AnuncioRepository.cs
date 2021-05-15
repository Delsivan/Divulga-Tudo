using DivulgaTudo.Dados.Contexto;
using DivulgaTudo.Negocio.Entidades;
using DivulgaTudo.Negocio.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivulgaTudo.Dados.Repositorios
{
    public class AnuncioRepository : BaseRepository<Anuncio>, IAnuncioRepository
    {
      
        public AnuncioRepository(DivulgaTudoDBContexto db) : base(db)
        {}

        public async Task<List<Anuncio>> ObterPorDateEClienteId(int clienteId, DateTime dataInicio, DateTime dataFim)
        {
            return await Db.Anuncios.Include(x => x.Cliente).Where(c => c.ClienteId == clienteId && c.DataInicio >= dataInicio && c.DataFim <= dataFim).ToListAsync();
        }

        public async Task<Anuncio> ObterPorIdComCliente(int id)
        {
            return await Db.Anuncios.Include(x => x.Cliente).SingleAsync(x => x.Id == id);
        }

        public async Task<List<Anuncio>> ObterTodosComCliente()
        {
            return await Db.Anuncios.Include(x => x.Cliente).ToListAsync();
        }
    }
}
