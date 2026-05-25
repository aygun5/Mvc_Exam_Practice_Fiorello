using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.ViewComponents
{
    public class ExpertViewComponent: ViewComponent
    {
        private readonly IExpertService _expertService;
        public ExpertViewComponent(IExpertService expertService)
        {
             _expertService = expertService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var experts = await _expertService.GetAllAsync();
            return View(experts);
        }
    }
}
