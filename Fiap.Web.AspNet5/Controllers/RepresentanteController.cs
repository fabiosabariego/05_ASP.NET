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
    public class RepresentanteController : Controller
    {
        private readonly RepresentanteRepository representanteRepository;

        public RepresentanteController(DataContext context)
        {
            representanteRepository = new RepresentanteRepository(context);
        }

        // GET: Representante
        public IActionResult Index()
        {
            var listaRepresentantes = representanteRepository.FindAll();

              return View(listaRepresentantes);
        }

        // GET: Representante/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = representanteRepository.FindById((int)id);

            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }

        // GET: Representante/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RepresentanteModel representanteModel)
        {
            if (ModelState.IsValid)
            {
                representanteRepository.Insert(representanteModel);

                return RedirectToAction(nameof(Index));
            }

            return View(representanteModel);
        }

        // GET: Representante/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = representanteRepository.FindById((int)id);

            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RepresentanteModel representanteModel)
        {
            if (id != representanteModel.RepresentanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                representanteRepository.Update(representanteModel);

                return RedirectToAction(nameof(Index));
            }

            return View(representanteModel);
        }

        // GET: Representante/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = representanteRepository.FindById((int)id);

            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }

        // POST: Representante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return Problem("Entity set 'DataContext.Representantes'  is null.");
            }

            var representanteModel = representanteRepository.FindById((int)id);

            if (representanteModel != null)
            {
                representanteRepository.Delete(representanteModel);
            }
            
            return RedirectToAction(nameof(Index));

        }

    }
}
