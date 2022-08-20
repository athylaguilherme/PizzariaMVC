using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models.ViewModel.Request
{
    public class PostTamanhoDTO
    {
        [Required(ErrorMessage = "O Nome do Tamanho é obrigatório!")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "O Nome do Tamanho dever ter no MIN 1 caracter e no MAX 15 ")]
        public string Nome { get;  set; }
    }
}
