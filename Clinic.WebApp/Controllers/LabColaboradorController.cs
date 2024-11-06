using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Models;
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
            var list = _context.LabColaboradors.Select(x => new LabColaborador
            {
                Id = x.Id,
                Colaborador = x.Colaborador,
                NombreColaborador = x.NombreColaborador,
                Estatus = x.Estatus,
                Departamento = x.Departamento,
                Definido = x.Definido,
                Registrado = x.Registrado,

            }).Where(x => /*x.Definido.Equals(1) &&*/ x.Estatus.Equals(1)).ToList();

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
        public ActionResult Create(LabColaborador labcolaborador)
        {
            if (labcolaborador is null) return Content("Los campos no pueden estar vacios");

            _context.Add(labcolaborador);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: LabColaboradorController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LabColaborador model = new();
            
            
            var colab = _context.LabColaboradors.Find(id);
            //if (colab == null) return Content("id no encontrado");
            model.Id = colab.Id;    
            model.Colaborador = colab.Colaborador;
            model.NombreColaborador = colab.NombreColaborador;
            model.Estatus = colab.Estatus;
            model.Departamento = colab.Departamento;
            model.Definido = colab.Definido;
            model.Registrado = colab.Registrado;
            

            return View(model);
        }

        // POST: LabColaboradorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LabColaborador colab)
        {
            var model = _context.LabColaboradors.Find(colab.Id);
            if (model == null) return Content("Not found");
            model.Id = colab.Id;
            model.Colaborador = colab.Colaborador;
            model.NombreColaborador = colab?.NombreColaborador;
            model.Estatus = colab!.Estatus;
            model.Departamento = model.Departamento;
            model.Definido = colab.Definido;
            model.Registrado = model.Registrado;

            _context.Update(model);
            _context.SaveChanges();

            return Redirect(Url.Content("~/LabColaborador/Index"));
        }

        // GET: LabColaboradorController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            LabColaborador model = new();
            var colab = _context.LabColaboradors.Find(id);

            model.Id = id;
            model.Colaborador = colab!.Colaborador;
            model.NombreColaborador = colab?.NombreColaborador;
            model.Estatus = colab!.Estatus;
            model.Departamento = model.Departamento;
            model.Definido = colab.Definido;
            model.Registrado = model.Registrado;

            colab.Estatus = 3; 

            _context.SaveChanges();

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
