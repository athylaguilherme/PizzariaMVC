using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class PizzaSabor
    {
  
        public PizzaSabor(int pizzaId, int saborId)
        {
            PizzaId = pizzaId;
            SaborId = saborId;
        }

        [Key]
        public Pizza Pizza { get; set; }
        public int PizzaId { get; private set; }
        [Key]
        public Sabor Sabor { get; set; }
        public int SaborId { get; private set; }
    }
}
