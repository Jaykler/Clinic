using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.WebApp.Controllers
{
    public class ClinicaDiagnosticoController : Controller
    {
        private readonly ClinicContext _context;
        public ClinicaDiagnosticoController(ClinicContext context)
        {

            _context = context;
        }

        // GET: ClinicaDiagnosticoController
        public ActionResult Index()
        {
            var list = _context.ClinicaDiagnosticos.Where(x => x.Estado == 1).ToList();

            if (list == null) return View(new List<ClinicaDiagnostico>());

            return View(list);
        }

        // GET: ClinicaDiagnosticoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicaDiagnosticoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicaDiagnosticoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicaDiagnostico clinicaDiagnostico)
        {
            if (clinicaDiagnostico is null) return Content("Los campos no pueden estar vacios");
            _context.Add(clinicaDiagnostico);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ClinicaDiagnosticoController/Edit/5
        public ActionResult Edit(int id)
        {
            ClinicaDiagnostico model = new();

            var entity = _context.ClinicaDiagnosticos.Find(id);

            model.Iddiagnostico = entity.Iddiagnostico;
            model.IdhistoricaClinica = entity.IdhistoricaClinica;
            model.Identificacion = entity.Identificacion;
            model.Observaciones = entity.Observaciones;
            model.Iddoctor = entity.Iddoctor;
            model.Diagnosticos = entity.Diagnosticos;
            model.FechaDiagnostico = entity.FechaDiagnostico;
            model.Estado = entity.Estado;
            model.ExamenLab = entity.ExamenLab;

            return View(model);
        }

        // POST: ClinicaDiagnosticoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClinicaDiagnostico clinicaDiagnostico)
        {
            ClinicaDiagnostico model = new();

            var entity = _context.ClinicaDiagnosticos.Find(clinicaDiagnostico.Iddiagnostico);

            //model.Iddiagnostico = entity.Iddiagnostico;
            model.IdhistoricaClinica = entity.IdhistoricaClinica;
            model.Identificacion = entity.Identificacion;
            model.Observaciones = entity.Observaciones;
            model.Iddoctor = entity.Iddoctor;
            model.Diagnosticos = entity.Diagnosticos;
            model.FechaDiagnostico = entity.FechaDiagnostico;
            model.Estado = entity.Estado;
            model.ExamenLab = entity.ExamenLab;

            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: ClinicaDiagnosticoController/Delete/5
        public ActionResult Delete(int id)
        {
            ClinicaDiagnostico model = new();

            var entity = _context.ClinicaDiagnosticos.Find(id);

            model.Iddiagnostico = entity.Iddiagnostico;
            model.IdhistoricaClinica = entity.IdhistoricaClinica;
            model.Identificacion = entity.Identificacion;
            model.Observaciones = entity.Observaciones;
            model.Iddoctor = entity.Iddoctor;
            model.FechaDiagnostico = entity.FechaDiagnostico;
            model.Estado = entity.Estado;
            model.ExamenLab = entity.ExamenLab;


            return View(model);
        }

        // POST: ClinicaDiagnosticoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
           

            var model = _context.ClinicaDiagnosticos.Find(id);

            model!.Estado = 3;
            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
