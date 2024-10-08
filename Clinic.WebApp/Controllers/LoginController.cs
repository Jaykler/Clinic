using Clinic.WebApp.Models.Context;
using Microsoft.AspNetCore.Mvc;


namespace Clinic.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ClinicContext _context;

        public LoginController( ClinicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string usuario, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == usuario && u.Password == password && u.IdEstatus == 1);
            if (user is null)  return Content("Usuario No existe"); 
            if ( usuario is null||password is null) return Content($"{usuario}/password es incorrecto");

            return Content("1");

        }

    }
}
