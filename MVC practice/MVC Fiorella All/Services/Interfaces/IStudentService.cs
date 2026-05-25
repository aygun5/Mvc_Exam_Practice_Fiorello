using MVC_Fiorella_All.ViewModels.Student;

namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentUIVM>> GetAllAsync();
        Task<IEnumerable<StudentVM>> GetAllAdminAsync();
        Task<StudentDetailVM> GetByIdAsync(int id);
        Task CreateAsync(StudentCreateVM model);
        Task UpdateAsync(int id,StudentUpdateVM model);
        Task DeleteAsync(int id);

    }
}
