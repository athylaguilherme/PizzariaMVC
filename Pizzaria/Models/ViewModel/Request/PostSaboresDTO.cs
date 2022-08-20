using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models.ViewModel.Request
{
    public class PostSaboresDTO
    {
        [Required(ErrorMessage = "O Nome do Ingrediente é obrigatório!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "O Nome do Ingrediente dever ter no MIN 2 caracter e no MAX 25 ")]
        public string Nome { get;  set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Imagem obrigatória")]
        public string FotoUrl { get;  set; }
    }
}
