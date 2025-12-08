using Microsoft.EntityFrameworkCore;
using SchoolCourses.Data;
using SchoolCourses.Models.Entities;
using SchoolCourses.Services.Interfaces;

namespace SchoolCourses.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly SchoolDbContext _context;

        public StudentService(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            if (!await _context.Students.AnyAsync(s => s.Id == student.Id))
                return false;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal?> GetAverageGradeAsync(int studentId)
        {
            var gradesQuery = _context.Enrollments
                .Where(e => e.StudentId == studentId && e.Grade.HasValue)
                .Select(e => e.Grade!.Value);

            if (!await gradesQuery.AnyAsync())
            {
                return null;
            }

            return await gradesQuery.AverageAsync();
        }
    }
}
