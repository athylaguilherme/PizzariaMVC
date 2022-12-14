using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Models
{
    public class Pizza : IEntidade
    {
        protected Pizza()
        {

        }
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
        
        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }

        public void AlterarDados(string novoNome, string fotoUrl, decimal preco, int tamanhoid)
        {
            if(preco > 0)
            {
                Nome = novoNome;
                FotoUrl = fotoUrl;
                Preco = preco;
                TamanhoId = tamanhoid;
                DataAlteracao = DateTime.Now;
            }
            else
            {
                return;
            }
        }
    }
}
