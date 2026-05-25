using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;
        public BlogViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? count)
        {
            var blogs = await _blogService.GetAllAsync();
            if (count.HasValue)
            {
                blogs = blogs.Take(count.Value).ToList();
            }

            return View(blogs);
        }
    }
}
