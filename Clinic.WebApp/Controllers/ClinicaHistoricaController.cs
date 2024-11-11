using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.WebApp.Controllers
{
    public class ClinicaHistoricaController : Controller
    {
        private readonly ClinicContext _context;

        public ClinicaHistoricaController(ClinicContext context)
        {

            _context = context;
        }
        // GET: ClinicaHistoricaController
        public ActionResult Index()
        {
             var list = _context.ClinicaHistoricas.Where(x => x.Estado == 1).ToList();

            if (list == null) return View(new List<ClinicaHistorica>());
            
            return View(list);
        }

        // GET: ClinicaHistoricaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicaHistoricaController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ClinicaHistoricaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicaHistorica clinicaHistorica)
        {
            if (clinicaHistorica is null) return Content("Los campos no pueden estar vacios");
            _context.Add(clinicaHistorica);
             _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ClinicaHistoricaController/Edit/5
        public ActionResult Edit(int id)
        {
            ClinicaHistorica model = new();

            var entity = _context.ClinicaHistoricas.Find(id);

            model.IdhistoriaClinica = entity.IdhistoriaClinica;
            model.Idpaciente = entity.Idpaciente;
            model.Identificacion = entity.Identificacion;
            model.Estado = entity.Estado;

            return View(model);
        }

        // POST: ClinicaHistoricaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClinicaHistorica entity)
        {
            var model = _context.ClinicaHistoricas.Find(entity.IdhistoriaClinica);
            if (model == null) return Content("Not found");
            model.Idpaciente = entity.Idpaciente;
            model.Identificacion = entity.Identificacion;
            model.IdhistoriaClinica = entity.IdhistoriaClinica;
            model.Estado = entity.Estado;
            if (model == null) return Content("Not found");
            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: ClinicaHistoricaController/Delete/5
        public ActionResult Delete(int id)
        {
            ClinicaHistorica model = new();

            var entity = _context.ClinicaHistoricas.Find(id);

            if (entity == null)
            {
                View("Index");
            }

            model.Idpaciente = entity.Idpaciente;
            model.Identificacion = entity.Identificacion;
            model.IdhistoriaClinica = entity.IdhistoriaClinica;

            return View(model);
        }

        // POST: ClinicaHistoricaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            var model = _context.ClinicaHistoricas.Find(id);
            model!.Estado = 3;
            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
