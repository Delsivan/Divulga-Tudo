using DivulgaTudo.Negocio.Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DivulgaTudo.App.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public ClienteViewModel()
        { }

        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        public List<Anuncio> Anuncios { get; set; }
    }
}
