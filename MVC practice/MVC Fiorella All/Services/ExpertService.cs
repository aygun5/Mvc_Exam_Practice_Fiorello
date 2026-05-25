using Microsoft.EntityFrameworkCore;
using MVC_Fiorella_All.Data;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;
using MVC_Fiorella_All.ViewModels.Expert;
using Newtonsoft.Json.Linq;

namespace MVC_Fiorella_All.Services
{
    public class ExpertService : IExpertService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileservice;
        public ExpertService(AppDbContext context, IFileService fileservice )
        {
            _context = context;
            _fileservice = fileservice;
        }
        public async Task CreateAsync(ExpertCreateVM model)
        {
            var fileName = _fileservice.GenerateUniqueFileName(model.Image.FileName);
            var path = _fileservice.GeneratePath("assets/img",fileName);
            await _fileservice.UploadAsync(model.Image, path);

            Expert expert = new Expert
            {
                Image = fileName,
                FullName = model.FullName,
                Job = model.Job,
            };
            await _context.Experts.AddAsync(expert);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var expert = await _context.Experts.FirstOrDefaultAsync(e => e.Id == id);
            var oldPath = _fileservice.GeneratePath("assets/img", expert.Image);
            _fileservice.Delete(oldPath);
            _context.Experts.Remove(expert);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<ExpertVM>> GetAllAdminAsync()
        {
            var experts = _context.Experts.Select(e => new ExpertVM
            {
                Id = e.Id,
                Image = e.Image,
                FullName = e.FullName,
                Job = e.Job,
            }).ToList();
            return Task.FromResult(experts.AsEnumerable());
        }

        public async Task<IEnumerable<ExpertUIVM>> GetAllAsync()
        {
            var experts = await _context.Experts.Select(e => new ExpertUIVM
            {
                Image = e.Image,
                FullName = e.FullName,
                Job = e.Job,
            }).ToListAsync();
            return experts;
        }

        public async Task<ExpertDetailVM> GetByIdAsync(int id)
        {
            var expert = await _context.Experts.FirstOrDefaultAsync(e => e.Id == id);
            return new ExpertDetailVM
            {
                Id = expert.Id,
                Image = expert.Image,
                FullName = expert.FullName,
                Job = expert.Job,
            };
        }

        public async Task UpdateAsync(int id, ExpertUpdateVM model)
        {
            var expert = await _context.Experts.FindAsync(id);
            if(model.NewImage != null)
            {
                var oldPath = _fileservice.GeneratePath("assets/img", expert.Image);
                _fileservice.Delete(oldPath);

                var fileName = _fileservice.GenerateUniqueFileName(model.NewImage.FileName);
                var path = _fileservice.GeneratePath("assets/img", fileName);
                await _fileservice.UploadAsync(model.NewImage, path);
                expert.Image = fileName;
            }
   
            expert.FullName = model.FullName;
            expert.Job = model.Job;

            await _context.SaveChangesAsync();
        }
    }
}
