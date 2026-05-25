using Microsoft.EntityFrameworkCore;
using MVC_Fiorella_All.Data;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category is null) return;

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>>GetAllAsync()
        {
            return await _context.Categories.Include(p=>p.Products).ToListAsync();
        }
    }
}
