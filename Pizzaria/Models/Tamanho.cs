using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Tamanho : IEntidade
    {
        public Tamanho(string nome)
        {
            Nome = nome;
        }
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        public string Nome { get; private set; }
        public List<Pizza> Pizzas { get; set; }
        
        public void AlterarDados(string novoNome)
        {
            Nome = novoNome;
            DataAlteracao = DateTime.Now;
        }
    }
}
