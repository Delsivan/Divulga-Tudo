using System.Collections.Generic;

namespace DivulgaTudo.Negocio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public List<Anuncio> Anuncios { get; set; }
    }
}
