using Microsoft.EntityFrameworkCore;
using SchoolCourses.Data;
using SchoolCourses.Models.Entities;
using SchoolCourses.Services.Interfaces;

namespace SchoolCourses.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly SchoolDbContext _context;
        private readonly IEmailSender _emailSender;

        public EnrollmentService(SchoolDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task<bool> EnrollStudentAsync(int studentId, int courseId)
        {
            var studentExists = await _context.Students.AnyAsync(s => s.Id == studentId);
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);

            if (!studentExists || !courseExists)
            {
                return false;
            }

            var alreadyEnrolled = await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (alreadyEnrolled)
            {
                return false;
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledOn = DateTime.UtcNow
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            var student = await _context.Students.FindAsync(studentId);
            var course = await _context.Courses.FindAsync(courseId);

            if (student != null && course != null)
            {
                await _emailSender.SendAsync(
                    student.Email,
                    "Успешно записване",
                    $"Бяхте записан в курс: {course.Name}");
            }

            return true;
        }

        public async Task<bool> SetGradeAsync(int enrollmentId, decimal grade)
        {
            if (grade < 2.0m || grade > 6.0m)
            {
                return false;
            }

            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return false;
            }

            enrollment.Grade = grade;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Enrollment?> GetEnrollmentAsync(int enrollmentId)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == enrollmentId);
        }
    }
}
