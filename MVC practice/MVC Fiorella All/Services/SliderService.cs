using Microsoft.EntityFrameworkCore;
using MVC_Fiorella_All.Data;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;
using MVC_Fiorella_All.ViewModels.Slider;

namespace MVC_Fiorella_All.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;
        public SliderService(AppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task CreateAsync(SliderCreateVM model)
        {
            var fileName = _fileService.GenerateUniqueFileName(model.Image.FileName);
            var path = _fileService.GeneratePath("assets/img/", fileName);
            await _fileService.UploadAsync(model.Image, path);

            Slider slider = new Slider
            {
                Image = fileName
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            string oldPath = _fileService.GeneratePath("assets/img", slider.Image);
            _fileService.Delete(oldPath);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderVM>> GetAllAdminAsync()
        {
            var sliders = await _context.Sliders.Select(s => new SliderVM
            {
                Id = s.Id,
                Image = s.Image
            }).ToListAsync();
            return sliders;
        }

        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<SliderDetailVM> GetByIdAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            return new SliderDetailVM
            {
                Id = slider.Id,
                Image = slider.Image
            };
        }

        public async Task UpdateAsync(int id, SliderUpdateVM model)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(m=>m.Id ==id);;
            string oldPath = _fileService.GeneratePath("assets/img", slider.Image);
            _fileService.Delete(oldPath);
            var fileName = _fileService.GenerateUniqueFileName(model.NewImage.FileName);
            var path = _fileService.GeneratePath("assets/img/", fileName);
            await _fileService.UploadAsync(model.NewImage, path);

            slider.Image = fileName;
            await _context.SaveChangesAsync();
        }
    }
}
