using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Models;
using Pizzaria.Models.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Controllers
{
    public class PizzasController : Controller
    {

        private PizzariaDbContext _context;

        public PizzasController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Pizzas);
        }

        public void DadosDropdown()
        {
            var resposta = new PostPizzaDropdownVM()
            {
                Sabores = _context.Sabores.OrderBy(s => s.Nome).ToList(),
                Tamanhos = _context.Tamanhos.OrderBy(x => x.Nome).ToList(),

            };

            ViewBag.Sabores = new SelectList(resposta.Sabores, "Id", "Nome");
            ViewBag.Tamanhos = new SelectList(resposta.Tamanhos, "Id", "Nome");

        }

        public IActionResult Criar()
        {
            DadosDropdown();

            return View();
        }

        [HttpPost]

        public IActionResult Criar(PostPizzaVM pizzaVM)
        {
            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View();
            }

            Pizza pizza = new Pizza
                (
                    pizzaVM.Nome,
                    pizzaVM.FotoUrl,
                    pizzaVM.Preco,
                    pizzaVM.TamanhoId

                );

            _context.Add(pizza);
            _context.SaveChanges();

            foreach (var saboresId in pizzaVM.SaboresId)
            {
                var NovoSabor = new PizzaSabor(pizza.Id, saboresId);
                _context.PizzasSabores.Add(NovoSabor);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var resultado = _context.Pizzas
                .Include(ps => ps.PizzaSabores).ThenInclude(s => s.Sabor)
                .FirstOrDefault(p => p.Id == id);

            if (resultado == null)
                return View("NotFound");

            var result = new PostPizzaVM()
            {
                Nome = resultado.Nome,
                FotoUrl = resultado.FotoUrl,
                Preco = resultado.Preco,
                SaboresId = resultado.PizzaSabores.Select(s => s.SaborId).ToList(),
                TamanhoId = resultado.TamanhoId
            };

            DadosDropdown();
            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostPizzaVM pizzaVM)
        {
            var resultado = _context.Pizzas.FirstOrDefault(p => p.Id == id);

            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View(pizzaVM);
            }

            resultado.AlterarDados
                (
                pizzaVM.Nome,
                pizzaVM.FotoUrl,
                pizzaVM.Preco,
                pizzaVM.TamanhoId
                );

            _context.Update(resultado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Detalhes), resultado);
        }

        public IActionResult Deletar(int id)
        {
            var resultado = _context.Pizzas.FirstOrDefault(p => p.Id == id);

            if (resultado == null)
                return View("NotFound");

            return View(resultado);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var resultado = _context.Pizzas.FirstOrDefault(p => p.Id == id);

            _context.Remove(resultado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = _context.Pizzas
                .Include(ps => ps.PizzaSabores).ThenInclude(s => s.Sabor)
                .Include(t => t.Tamanho)
                .FirstOrDefault(p => p.Id == id);

            if (resultado == null)
                return View("NotFound");


            return View(resultado);
        }
    }
}
