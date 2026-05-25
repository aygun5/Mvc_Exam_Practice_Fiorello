using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.CreateAsync(category);

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
