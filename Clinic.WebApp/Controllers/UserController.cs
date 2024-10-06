using Clinic.WebApp.Models;
using Clinic.WebApp.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ClinicContext _context;

        // GET: UserController

        public UserController(ClinicContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {

            var list = _context.Users.Select(x => new User
            {
                Id = x.Id,
                IdEstatus = x.IdEstatus,
                IdEstatusNavigation = new MStatus
                {
                    Status = x.IdEstatusNavigation.Status,
                },
                Nombre = x.Nombre,
                Edad = x.Edad,
                Email = x.Email,
                Password = x.Password,
            }).Where(x => x.IdEstatus.Equals(1)).ToList();

            return View(list);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
