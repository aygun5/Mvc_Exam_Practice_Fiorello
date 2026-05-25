using MVC_Fiorella_All.Models;

namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog> GetById(int id);
    }
}
