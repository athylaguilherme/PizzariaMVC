using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models.ViewModel.Request
{
    public class PostPizzaVM
    {
        [Required(ErrorMessage = "O Nome da Pizza é obrigatório!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "O Nome da Pizza dever ter no MIN 2 caracter e no MAX 25 ")]
        public string Nome { get; set; }
        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Imagem da Pizza obrigatório")]
        public string FotoUrl { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Preço da Pizza obrigatório")]
        public decimal Preco { get; set; }

        [Display(Name = "Ingredientes")]
        [Required(ErrorMessage = "No Min 1 Ingrediente é obrigatório para uma Pizza")]
        public List<int> SaboresId { get; set; }

        [Display(Name = "Tamanho")]
        [Required(ErrorMessage = "Tamanho da Pizza é obrigatório")]
        public int TamanhoId { get; set; }
    }
}
