using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.ViewModels.Slider;

namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface ISliderService
    {
        Task <IEnumerable<Slider>> GetAllAsync();
        Task <IEnumerable<SliderVM>> GetAllAdminAsync();
        Task CreateAsync(SliderCreateVM model);
        Task<SliderDetailVM> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, SliderUpdateVM model);
    }
}
