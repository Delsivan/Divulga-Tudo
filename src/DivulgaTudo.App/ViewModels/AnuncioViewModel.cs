using DivulgaTudo.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DivulgaTudo.App.ViewModels
{
    public class AnuncioViewModel
    {
        public AnuncioViewModel(Anuncio anuncio)
        {
            Id = anuncio.Id;
            Nome = anuncio.Nome;
            DataInicio = anuncio.DataInicio;
            DataFim = anuncio.DataFim;
            Ativo = anuncio.Ativo;
            InvestimentoPorDia = anuncio.InvestimentoPorDia;
            Cliente = new ClienteViewModel(anuncio.Cliente?.Nome, anuncio.Cliente?.Email);
            ClienteId = anuncio.Cliente.Id;
        }

        public AnuncioViewModel()
        {}

        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Titulo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Inicio")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data de Fim")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Investimento por dia")]
        public decimal InvestimentoPorDia { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        public ClienteViewModel Cliente { get; set; }
    }
}
