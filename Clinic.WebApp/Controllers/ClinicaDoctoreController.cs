using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.WebApp.Controllers
{
    public class ClinicaDoctoreController : Controller
    {
        private readonly ClinicContext _context;

        public ClinicaDoctoreController(ClinicContext context)
        {

            _context = context;
        }
        // GET: ClinicaDoctoreController
        public ActionResult Index()
        {
            var list = _context.ClinicaDoctores.Where(x => x.Estado == 1).ToList();

            if (list == null) return View(new List<ClinicaDoctore>());

            return View(list);
        }

        // GET: ClinicaDoctoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicaDoctoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicaDoctoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicaDoctore clinicaDoctore)
        {
            if (clinicaDoctore is null) return Content("Los campos no pueden estar vacios");
            _context.Add(clinicaDoctore);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ClinicaDoctoreController/Edit/5
        public ActionResult Edit(int id)
        {
            ClinicaDoctore model = new();
            var entity = _context.ClinicaDoctores.Find(id);
            model.Iddoctor = entity.Iddoctor;
            model.Identificacion = entity.Identificacion;
            model.Estado = entity.Estado;
            model.Nombres = entity.Nombres;
            model.Idespecialidad = entity.Idespecialidad;

            return View(model);
        }

        // POST: ClinicaDoctoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClinicaDoctore clinicaDoctore)
        {
            ClinicaDoctore model = new();
            var entity = _context.ClinicaDoctores.Find(clinicaDoctore.Iddoctor);

            //model.Iddoctor = entity.Iddoctor;
            model.Nombres = entity.Nombres;
            model.Identificacion = entity.Identificacion;
            model.Estado = entity.Estado;
            model.Idespecialidad = entity.Idespecialidad;

            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ClinicaDoctoreController/Delete/5
        public ActionResult Delete(int id)
        {
            ClinicaDoctore model = new();
            var entity = _context.ClinicaDoctores.Find(id);
            model.Iddoctor = entity!.Iddoctor;
            model.Identificacion = entity.Identificacion;
            model.Estado = entity.Estado;
            model.Idespecialidad = entity.Idespecialidad;

            return View(model);
        }

        // POST: ClinicaDoctoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            var model = _context.ClinicaDoctores.Find(id);
            model!.Estado = 3;
            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
