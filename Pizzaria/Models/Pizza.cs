using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Pizza : IEntidade
    {

        public Pizza(string nome, string fotourl ,decimal preco)
        {
            Nome = nome;
            FotoUrl = fotourl;
            Preco = preco;
        }

        public Pizza(string nome, string fotourl, decimal preco, int tamanhoid)
        {
            Nome = nome;
            FotoUrl = fotourl;
            Preco = preco;
            TamanhoId = tamanhoid;
        }


        public int Id { get; set; }
        public DateTime DataCadastro { get;  set; }
        public DateTime DataAlteracao { get; set; }

        public string Nome { get; set; }
        public List<PizzaSabor> PizzaSabores  { get; set; }

        public string FotoUrl { get; private set; }
        public decimal Preco { get; private set; }
        public Tamanho Tamanho { get; set; }
        public int TamanhoId { get; set; }
    }
}
