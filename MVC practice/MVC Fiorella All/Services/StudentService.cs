using Microsoft.EntityFrameworkCore;
using MVC_Fiorella_All.Data;
using MVC_Fiorella_All.Models;
using MVC_Fiorella_All.Services.Interfaces;
using MVC_Fiorella_All.ViewModels.Student;

namespace MVC_Fiorella_All.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(StudentCreateVM model)
        {
            await _context.AddAsync(new Student
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                Email = model.Email,
                Adress = model.Adress,
                Grade = model.Grade,
                Group = model.Group,
                Phone = model.Phone,
                Faculty= model.Faculty
            });
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentVM>> GetAllAdminAsync()
        {
            var students= await _context.Students.Select(s => new StudentVM
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                Age = s.Age,
                Email = s.Email
            }).ToListAsync();

            return students;
        }

        public Task<IEnumerable<StudentUIVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDetailVM> GetByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync (s=>s.Id== id);
            return new StudentDetailVM
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Email = student.Email,
                Adress = student.Adress,
                Grade = student.Grade,
                Group = student.Group,
                Phone = student.Phone,
                Faculty= student.Faculty
            };
        }

        public Task UpdateAsync(int id, StudentUpdateVM model)
        {
            throw new NotImplementedException();
        }
    }
}
