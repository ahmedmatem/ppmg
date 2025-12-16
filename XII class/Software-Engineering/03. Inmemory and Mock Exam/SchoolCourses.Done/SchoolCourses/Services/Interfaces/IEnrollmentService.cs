using SchoolCourses.Models.Entities;

namespace SchoolCourses.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollStudentAsync(int studentId, int courseId);

        Task<bool> SetGradeAsync(int enrollmentId, decimal grade);

        Task<Enrollment?> GetEnrollmentAsync(int enrollmentId);
    }
}
