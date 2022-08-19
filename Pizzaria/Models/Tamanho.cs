
using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;


namespace Pizzaria.Models
{
    public class Tamanho : IEntidade
    {
        public Tamanho(string nome)
        {
            Nome = nome;
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
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
