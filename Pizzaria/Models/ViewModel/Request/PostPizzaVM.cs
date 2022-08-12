using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models.ViewModel.Request
{
    public class PostPizzaVM
    {
        public string Nome { get; set; }
        public string FotoUrl { get; set; }
        public decimal Preco { get; set; }
        public List<int> SaboresId { get; set; }
        public int TamanhoId { get; set; }
    }
}
