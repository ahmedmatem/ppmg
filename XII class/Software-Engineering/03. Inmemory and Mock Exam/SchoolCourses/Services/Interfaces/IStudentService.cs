using SchoolCourses.Models.Entities;

namespace SchoolCourses.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task<Student> CreateAsync(Student student);

        Task<bool> UpdateAsync(Student student);

        Task<bool> DeleteAsync(int id);

        Task<decimal?> GetAverageGradeAsync(int studentId);
    }
}
