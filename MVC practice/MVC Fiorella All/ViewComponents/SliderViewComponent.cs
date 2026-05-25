using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly ISliderInfoService _sliderInfoService;

        public SliderViewComponent(ISliderService sliderService,
                              ISliderInfoService sliderInfoService)
        {
            _sliderService = sliderService;
            _sliderInfoService = sliderInfoService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _sliderService.GetAllAsync();
            var sliderInfo = await _sliderInfoService.GetAllAsync();
            SliderVMVC model = new()
            {
                Sliders = sliders,
                SliderInfo = sliderInfo
            };
            return View(model);
        }
    }
    public class SliderVMVC
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public SliderInfo SliderInfo { get; set; }
    }
}
