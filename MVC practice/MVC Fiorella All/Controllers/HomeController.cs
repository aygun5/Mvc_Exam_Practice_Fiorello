using Microsoft.AspNetCore.Mvc;
namespace MVC_Fiorella_All.Controllers
{
    public class HomeController : Controller
    {
        public async Task <IActionResult> Index()
        {

            return View();
        }
    }
}
