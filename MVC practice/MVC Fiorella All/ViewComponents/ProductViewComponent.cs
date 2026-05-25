using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public ProductViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}
