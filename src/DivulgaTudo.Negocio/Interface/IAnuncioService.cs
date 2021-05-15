using DivulgaTudo.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivulgaTudo.Negocio.Interface
{
    public interface IAnuncioService
    {
        Task Adicionar(Anuncio anuncio);
    }
}
