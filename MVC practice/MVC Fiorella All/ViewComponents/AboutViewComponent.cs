using Microsoft.AspNetCore.Mvc;

namespace MVC_Fiorella_All.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
