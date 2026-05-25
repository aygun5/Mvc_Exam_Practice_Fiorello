using MVC_Fiorella_All.Models;

namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task CreateAsync(Category category);
        Task DeleteAsync(int id);

    }
}
