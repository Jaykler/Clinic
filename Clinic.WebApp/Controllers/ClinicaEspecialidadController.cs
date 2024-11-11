using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.WebApp.Controllers
{
    public class ClinicaEspecialidadController : Controller
    {
        private readonly ClinicContext _context;

        // GET: ClinicaEspecialidadController

        public ClinicaEspecialidadController(ClinicContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var list = _context.ClinicaEspecialidads.Where(x => x.Estado == 1).ToList();

            if (list == null) return View(new List<ClinicaHistorica>());

            return View(list);
        }

        // GET: ClinicaEspecialidadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicaEspecialidadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicaEspecialidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicaEspecialidad clinicaEspecialidad)
        {
            if (clinicaEspecialidad is null) return Content("Los campos no pueden estar vacios");
            _context.Add(clinicaEspecialidad);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ClinicaEspecialidadController/Edit/5
        public ActionResult Edit(int id)
        {
            ClinicaEspecialidad model = new();

            var entity = _context.ClinicaEspecialidads.Find(id);

            model.Idespecialidad = entity.Idespecialidad;
            model.Nombre = entity.Nombre;
            model.Estado = entity.Estado;

            return View(model);
        }

        // POST: ClinicaEspecialidadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClinicaEspecialidad clinicaEspecialidad)
        {
            ClinicaEspecialidad model = new();

            var entity = _context.ClinicaEspecialidads.Find(clinicaEspecialidad.Idespecialidad);

            model.Idespecialidad = entity.Idespecialidad;
            model.Nombre = entity.Nombre;
            model.Estado = entity.Estado;

            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ClinicaEspecialidadController/Delete/5
        public ActionResult Delete(int id)
        {
            ClinicaEspecialidad model = new();

            var entity = _context.ClinicaEspecialidads.Find(model.Idespecialidad);

            model.Idespecialidad = entity.Idespecialidad;
            model.Nombre = entity.Nombre;
            model.Estado = entity.Estado;

            return View(model);
        }

        // POST: ClinicaEspecialidadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            var model = _context.ClinicaEspecialidads.Find(id);
            model!.Estado = 3;
            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
