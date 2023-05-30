using Microsoft.AspNetCore.Mvc;
using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.Controllers.Filters;

namespace Fiap.Web.AspNet5.Controllers
{
    [FiapAuthFilter]
    public class RepresentanteController : Controller
    {
        private readonly IRepresentanteRepository representanteRepository;

        public RepresentanteController(IRepresentanteRepository _representanteRepository)
        {
            representanteRepository = _representanteRepository;
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
