using Microsoft.AspNetCore.Mvc;
using MVC_Fiorella_All.Services.Interfaces;
using MVC_Fiorella_All.ViewModels.Slider;

namespace MVC_Fiorella_All.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            var slider = await _sliderService.GetAllAdminAsync();
            return View(slider);
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _sliderService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            var slider = await _sliderService.GetByIdAsync(id.Value);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            await _sliderService.DeleteAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var slider = await _sliderService.GetByIdAsync(id.Value);
            if (slider == null) return NotFound();
            return View(new SliderUpdateVM
            {


                Image = slider.Image
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM model)
        {
            if (id == null) return BadRequest();
            var slider = await _sliderService.GetByIdAsync(id.Value);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _sliderService.UpdateAsync(id.Value, model);
            return RedirectToAction(nameof(Index));
        }
    }
}

