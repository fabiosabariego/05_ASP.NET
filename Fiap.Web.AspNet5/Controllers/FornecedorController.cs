using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;

namespace Fiap.Web.AspNet5.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedorRepository fornecedorRepository;

        public FornecedorController(DataContext context)
        {
            fornecedorRepository = new FornecedorRepository(context);
        }

        // GET: Fornecedor
        public IActionResult Index()
        {

            var lista = fornecedorRepository.FindAll();
            
            /*
            return lista != null ? 
                          View(lista) :
                          Problem("Entity set 'DataContext.Fornecedores'  is null.");
            */

            return View(lista);
        }

        // GET: Fornecedor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = fornecedorRepository.FindById((int)id);

            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorRepository.Insert(fornecedorModel);

                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        // GET: Fornecedor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = fornecedorRepository.FindById((int)id);

            if (fornecedorModel == null)
            {
                return NotFound();
            }
            return View(fornecedorModel);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FornecedorModel fornecedorModel)
        {
            if (id != fornecedorModel.FornecedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                fornecedorRepository.Update(fornecedorModel);
                
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        // GET: Fornecedor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = fornecedorRepository.FindById((int)id);

            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {

            if (id == null)
            {
                return Problem("Entity set 'DataContext.Fornecedores'  is null.");
            }

            var fornecedorModel = fornecedorRepository.FindById((int)id);

            if (fornecedorModel != null)
            {
                fornecedorRepository.Delete(fornecedorModel);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
