using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Clinic.WebApp.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ClinicContext _context;

        public PacienteController(ClinicContext context)
        {
            _context = context;
        }
        // GET: PacienteController
        public ActionResult Index()
        {
            var list = _context.Pacientes.Where(x => x.Estado == "1").ToList();

            if (list == null) return View(new List<ClinicaHistorica>());

            return View(list);
        }

        // GET: PacienteController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: PacienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            if (paciente is null) return Content("Los campos no pueden estar vacios");

            _context.Add(paciente);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: PacienteController/Edit/5
        public ActionResult Edit(int id)
        {
            Paciente model = new();
            var entity = _context.Pacientes.Find(id);

            model.Id = entity.Id;
            model.Sexo =  entity.Sexo;
            model.Numsfs = entity.Numsfs;
            model.Identificacion = entity.Identificacion;
            model.Estado = entity.Estado;
            model.Ars = entity.Ars;
            model.Nombre = entity.Nombre;
            model.Lugar = entity.Lugar;
            model.Talla = entity.Talla;
            model.Edad = entity.Edad;
            model.Apellidomaterno = entity.Apellidomaterno;
            model.Apellidopaterno = entity.Apellidopaterno;
            model.Clasifica = entity.Clasifica;
            model.Nacionalidad = entity.Nacionalidad;
            model.Idcuenta = entity.Idcuenta;
            model.Correo = entity.Correo;
            model.Dparte = entity.Dparte;
            model.Peso = entity.Peso;
            model.Domicilio = entity.Domicilio;
            model.Direccion = entity.Direccion;
            model.Nic=entity.Nic;
            model.Registrado = entity.Registrado;
            model.Posicion = entity.Posicion;
            model.Nivel = entity.Nivel;
            model.Siglas = entity.Siglas;
            model.Telefono1 = entity.Telefono1;
            model.Telefono2 = entity.Telefono2;
            model.Fechanacimiento = entity.Fechanacimiento;


            return View(model);
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            Paciente model = new();

            var entity = _context.Pacientes.Find(paciente.Id);

            model.Id = entity.Id;
            model.Sexo = entity.Sexo;
            model.Numsfs = entity.Numsfs;
            model.Identificacion = entity.Identificacion;
            model.Estado = entity.Estado;
            model.Ars = entity.Ars;
            model.Nombre = entity.Nombre;
            model.Lugar = entity.Lugar;
            model.Talla = entity.Talla;
            model.Edad = entity.Edad;
            model.Apellidomaterno = entity.Apellidomaterno;
            model.Apellidopaterno = entity.Apellidopaterno;
            model.Clasifica = entity.Clasifica;
            model.Nacionalidad = entity.Nacionalidad;
            model.Idcuenta = entity.Idcuenta;
            model.Correo = entity.Correo;
            model.Dparte = entity.Dparte;
            model.Peso = entity.Peso;
            model.Domicilio = entity.Domicilio;
            model.Direccion = entity.Direccion;
            model.Nic = entity.Nic;
            model.Registrado = entity.Registrado;
            model.Posicion = entity.Posicion;
            model.Nivel = entity.Nivel;
            model.Siglas = entity.Siglas;
            model.Telefono1 = entity.Telefono1;
            model.Telefono2 = entity.Telefono2;
            model.Fechanacimiento = entity.Fechanacimiento;

            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PacienteController/Delete/5
        public ActionResult Delete(int id)
        {
            Paciente model = new();
            var entity = _context.Pacientes.Find(id);

            model.Id = entity.Id;
            model.Sexo = entity.Sexo;
            model.Numsfs = entity.Numsfs;
            model.Identificacion = entity.Identificacion;
            model.Estado = entity.Estado;
            model.Ars = entity.Ars;
            model.Nombre = entity.Nombre;
            model.Lugar = entity.Lugar;
            model.Talla = entity.Talla;
            model.Edad = entity.Edad;
            model.Apellidomaterno = entity.Apellidomaterno;
            model.Apellidopaterno = entity.Apellidopaterno;
            model.Clasifica = entity.Clasifica;
            model.Nacionalidad = entity.Nacionalidad;
            model.Idcuenta = entity.Idcuenta;
            model.Correo = entity.Correo;
            model.Dparte = entity.Dparte;
            model.Peso = entity.Peso;
            model.Domicilio = entity.Domicilio;
            model.Direccion = entity.Direccion;
            model.Nic = entity.Nic;
            model.Registrado = entity.Registrado;
            model.Posicion = entity.Posicion;
            model.Nivel = entity.Nivel;
            model.Siglas = entity.Siglas;
            model.Telefono1 = entity.Telefono1;
            model.Telefono2 = entity.Telefono2;
            model.Fechanacimiento = entity.Fechanacimiento;


            return View(model);
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            var model = _context.Pacientes.Find(id);
            
            model!.Estado = "3";
            _context.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
