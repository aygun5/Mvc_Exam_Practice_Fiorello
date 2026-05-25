using Microsoft.EntityFrameworkCore;
using MVC_Fiorella_All.Data;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.Services
{
    public class SliderInfoService : ISliderInfoService
    {
        private readonly AppDbContext _context;
        public SliderInfoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SliderInfo> GetAllAsync()
        {
            return await _context.SliderInfos.FirstOrDefaultAsync();
        }
    }
}
