using MVC_Fiorella_All.Models;

namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface ISliderInfoService
    {
        Task<SliderInfo> GetAllAsync();
    }
}
