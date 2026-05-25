using MVC_Fiorella_All.ViewModels.Expert;

namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface IExpertService
    {
        Task<IEnumerable<ExpertUIVM>> GetAllAsync();
        Task<IEnumerable<ExpertVM>> GetAllAdminAsync();
        Task CreateAsync(ExpertCreateVM model);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, ExpertUpdateVM model);
        Task<ExpertDetailVM> GetByIdAsync(int id);
    }
}
