using System.ComponentModel.DataAnnotations;

namespace MVC_Fiorella_All.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
