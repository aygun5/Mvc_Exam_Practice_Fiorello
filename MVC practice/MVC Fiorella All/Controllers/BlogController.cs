using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogservice;
        public BlogController(IBlogService blogService)
        {
         _blogservice = blogService;    
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task <IActionResult> Detail(int id)
        {
            var blog= await _blogservice.GetById(id);
            return View(blog);
        }
    }
}
    