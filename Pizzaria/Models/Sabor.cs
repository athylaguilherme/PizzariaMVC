using Pizzaria.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Models
{
    public class Sabor : IEntidade
    {
        public Sabor(string nome, string fotoUrl)
        {
            Nome = nome;
            FotoUrl = fotoUrl;
            DataCadastro = DateTime.Now;
            DataAlteracao = DataCadastro;
        }
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Nome  { get; private set; }

        [Display(Name = "Imagem")]
        public string FotoUrl { get; private set; }
        public List<PizzaSabor> PizzaSabores { get; set; }

        public void AlterarDados(string novoNome, string fotoUrl)
        {

            Nome = novoNome;
            FotoUrl = fotoUrl;
            DataAlteracao = DateTime.Now;
        }

    }
}
