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
            if (!ModelState.IsValid) return View(dtoSabor);

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
        public IActionResult Atualizar(int id, PostSaboresDTO Postsabor)
        {

            var AtualizarSabor = _context.Sabores.FirstOrDefault(s => s.Id == id);

            if (!ModelState.IsValid) return View(AtualizarSabor);

            AtualizarSabor.AlterarDados(Postsabor.Nome, Postsabor.FotoUrl);
            _context.Sabores.Update(AtualizarSabor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var resultado = _context.Sabores.FirstOrDefault(s => s.Id == id);
            if (resultado == null)
            {
                return View("NotFound");
            }

            return View(resultado);

        }

        [HttpPost]
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
