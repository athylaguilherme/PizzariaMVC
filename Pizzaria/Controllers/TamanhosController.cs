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
    public class TamanhosController : Controller
    {

        private PizzariaDbContext _context;

        public TamanhosController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Tamanhos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostTamanhoDTO dtoTamanho)
        {
            

            Tamanho NovoTamanho = new Tamanho(dtoTamanho.Nome);

            if (!ModelState.IsValid) return View(NovoTamanho);

            _context.Tamanhos.Add(NovoTamanho);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var resultado = _context.Tamanhos.FirstOrDefault(t => t.Id == id);
            if (resultado == null)
            {
                return View();
            }

            return View(resultado);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostTamanhoDTO tamanhoDTO)
        {

            var AtualizarTamanho = _context.Tamanhos.FirstOrDefault(t => t.Id == id);

            if (!ModelState.IsValid) return View(AtualizarTamanho);

            AtualizarTamanho.AlterarDados(tamanhoDTO.Nome);

            _context.Tamanhos.Update(AtualizarTamanho);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var resultado = _context.Tamanhos.FirstOrDefault(t => t.Id == id);
            if (resultado == null)
            {
                return View();
            }

            return View(resultado);

        }

        [HttpPost]
        public IActionResult ConfirmarDeletar(int id)
        {
            var DeletarTamanho = _context.Tamanhos.FirstOrDefault(t => t.Id == id);
            _context.Tamanhos.Remove(DeletarTamanho);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id) => View(_context.Tamanhos.Find(id));

    }
}
