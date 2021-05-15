using System;

namespace DivulgaTudo.Negocio.Entidades
{
    public class Anuncio : EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public decimal InvestimentoPorDia { get; set; }

        public bool Ativo { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

    }
}
