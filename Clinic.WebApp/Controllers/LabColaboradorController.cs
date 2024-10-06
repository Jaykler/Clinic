using Clinic.WebApp.Models;
using Clinic.WebApp.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.WebApp.Controllers
{
    public class LabColaboradorController : Controller
    {
        private readonly ClinicContext _context;

        public LabColaboradorController(ClinicContext context)
        {
            _context = context;
        }
        // GET: LabColaboradorController
        public ActionResult Index()
        {
            var list = _context.LabCOLABORADOR.Where(x=> x.Definido.Equals(1) && x.Estatus.Equals(1)).Select(x => new LabColaborador
            {
                Colaborador = x.Colaborador,
                NombreColaborador = x.NombreColaborador,
                Estatus = x.Estatus,
                Departamento = x.Departamento,
                Definido = x.Definido,
                Registrado = x.Registrado,

            }).ToList();

            return View(list);
        }

        // GET: LabColaboradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LabColaboradorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabColaboradorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabColaboradorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LabColaboradorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabColaboradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LabColaboradorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
