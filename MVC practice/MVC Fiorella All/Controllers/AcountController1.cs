using Microsoft.AspNetCore.Mvc;

namespace MVC_Fiorella_All.Controllers
{
    public class AcountController1 : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }
    }
}
