namespace MVC_Fiorella_All.Services.Interfaces
{
    public interface IFileService
    {
        string GenerateUniqueFileName(string fileName);
        string GeneratePath(string folder, string fileName);
        Task UploadAsync(IFormFile file, string path);
        void Delete(string path);
    }
}
