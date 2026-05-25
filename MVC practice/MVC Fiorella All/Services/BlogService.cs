using Microsoft.EntityFrameworkCore;
using MVC_Fiorella_All.Data;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;

namespace MVC_Fiorella_All.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
              _context = context;    
        }
        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Include(b => b.BlogImages).ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.Include(b => b.BlogImages).
                                        FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
