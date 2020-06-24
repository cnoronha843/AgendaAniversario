using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAniversario.Models;
using AgendaAniversario.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAniversario.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository PessoaRepository { get; set; }

        public PessoaController (PessoaRepository pessoaRepository)
        {
            this.PessoaRepository = pessoaRepository;
        }
        public IActionResult Index()
        {
            var model = this.PessoaRepository.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pessoa  pessoa)
        {
            try
            {
                this.PessoaRepository.Save(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {

            var model = this.PessoaRepository.GetPessoaById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pessoa model)
        {
            try
            {
                model.Id = id;
                this.PessoaRepository.Update(model);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
            
        }

        public ActionResult Search ([FromQuery] string query )
        {
            var model = this.PessoaRepository.Search(query);

            return View("Index", model);

        }
        public IActionResult Delete (int id)
        {

            var model = this.PessoaRepository.GetPessoaById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id, Pessoa model)
        {
            try
            {
                model.Id = id;
                this.PessoaRepository.Delete(model);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }

        }

        public IActionResult Details(int id)
        {
            var model = this.PessoaRepository.GetPessoaById(id);
            return View(model);
            
        }



    }
}