using Microsoft.AspNetCore.Mvc;
using Pizzaria.Data;
using Pizzaria.Models;
using Pizzaria.Models.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Controllers
{
    public class SaboresController : Controller
    {
        private PizzariaDbContext _context;

        public SaboresController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Sabores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostSaboresDTO dtoSabor)
        {
            Sabor NovoSabor = new Sabor(dtoSabor.Nome, dtoSabor.FotoUrl);

            _context.Sabores.Add(NovoSabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            if (id == null)
            {
                return View();
            }

            var resultado = _context.Sabores.FirstOrDefault(s => s.Id == id);
            if (resultado == null)
            {
                return View();
            }

            return View(resultado);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, Sabor sabor)
        {

            var AtualizarSabor = _context.Sabores.FirstOrDefault(s => s.Id == id);
            AtualizarSabor.AlterarDados(sabor.Nome, sabor.FotoUrl);
            _context.Sabores.Update(AtualizarSabor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            if (id == null)
            {
                return View();
            }

            var resultado = _context.Sabores.FirstOrDefault(s => s.Id == id);
            if (resultado == null)
            {
                return View();
            }

            return View(resultado);

        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var DeletarSabor = _context.Sabores.FirstOrDefault(s => s.Id == id);
            _context.Sabores.Remove(DeletarSabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id) => View(_context.Sabores.Find(id));

    }
}
