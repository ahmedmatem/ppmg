using SchoolCourses.Models.Entities;

namespace SchoolCourses.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

        Task<Course> CreateAsync(Course course);

        Task<bool> UpdateAsync(Course course);

        Task<bool> DeleteAsync(int id);

        Task<List<Student>> GetStudentsInCourseAsync(int courseId);
    }
}
