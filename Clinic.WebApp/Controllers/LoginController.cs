using Microsoft.AspNetCore.Mvc;

namespace Clinic.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
