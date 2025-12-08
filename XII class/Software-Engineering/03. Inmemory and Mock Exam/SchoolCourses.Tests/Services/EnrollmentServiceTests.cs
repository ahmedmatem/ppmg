using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Moq;
using SchoolCourses.Data;
using SchoolCourses.Models.Entities;
using SchoolCourses.Services.Implementations;
using SchoolCourses.Services.Interfaces;
using static SchoolCourses.Tests.InMemoryDbContextFactory;

namespace SchoolCourses.Tests.Services
{
    [TestFixture]
    public class EnrollmentServiceTests
    {
        private SchoolDbContext context = default!;
        private EnrollmentService enrollmentService = default!;
        private Mock<IEmailSender> emailSenderMock = null!;

        [SetUp]
        public void Setup()
        {
            // Use db-context factory helper to create in-memory database context.
            // Separate InMemory database context and service for each test.
            context = CreateDbContext();
            // Create an instance of service
            emailSenderMock = new Mock<IEmailSender>();
            enrollmentService = new EnrollmentService(context, emailSenderMock.Object);
        }

        [Test]
        public async Task EnrollStudentAsync_ReturnsFalse_WhenStudentDoesNotExist()
        {
            // Arrange
            // We only have a course, but no student
            var course = new Course 
            {
                Name = "Math", 
                Description = "Math course", 
                Credits = 5 
            };

            // Add and save course in database
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            // Act
            var result = await enrollmentService
                // trying to enroll a student with id: 999, which does not exist
                .EnrollStudentAsync(studentId: 999, courseId: course.Id);

            // Assert
            Assert.That(result, Is.False);
            emailSenderMock.Verify(
                e => e.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public async Task EnrollStudentAsync_ReturnsFalse_WhenAlreadyEnrolled()
        {
            // Arrange
            // create a student
            var student = new Student
            {
                FirstName = "Ahmed",
                LastName = "Ahmed",
                Email = "ahmedmatem@gmail.com",
                ClassNumber = 1
            };
            // create a course
            var course = new Course 
            {  
                Name = "OOP",
                Description = "OOP course",
                Credits = 6 
            };
            // Add student and course in database
            context.Students.Add(student);
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            // First enrollment
            context.Enrollments.Add(new Enrollment
            {
                StudentId = student.Id,
                CourseId = course.Id,
                EnrolledOn = DateTime.UtcNow
            });
            await context.SaveChangesAsync(); // save in database

            // Act
            // trying to enroll existing student by bservice
            var result = await enrollmentService.EnrollStudentAsync(student.Id, course.Id);

            // Assert
            Assert.That(result, Is.False);
            emailSenderMock.Verify(
                e => e.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public async Task EnrollStudentAsync_SuccessfullyEnrolls_AndSendsEmail()
        {
            // Arrange
            var student = new Student
            {
                FirstName = "Ahmed",
                LastName = "Ahmed",
                Email = "ahmedmatem@gmail.com",
                ClassNumber = 1
            };

            var course = new Course 
            {
                Name = "Databases",
                Description = "DB course",
                Credits = 5
            };

            context.Students.Add(student);
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            var service = new EnrollmentService(context, emailSenderMock.Object);

            // Act
            // Enrool student in course
            var result = await service.EnrollStudentAsync(student.Id, course.Id);

            // Checking if a record has been created in Enrollments
            var enrollmentInDb = await context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == student.Id && e.CourseId == course.Id);

            // Assert
            Assert.That(result, Is.True);            

            Assert.That(enrollmentInDb, Is.Not.Null);

            // Checking the email sender has been called
            emailSenderMock.Verify(
                e => e.SendAsync(
                    student.Email,
                    It.Is<string>(s => s.Contains("Успешно")),
                    It.Is<string>(b => b.Contains(course.Name))),
                Times.Once);
        }

        [Test]
        public async Task SetGradeAsync_ReturnsFalse_WhenGradeIsOutOfRange()
        {
            // Arrange
            // All we need to arrange test is done in Setup

            // Act
            var resultLow = await enrollmentService.SetGradeAsync(enrollmentId: 1, grade: 1.50m);
            var resultHigh = await enrollmentService.SetGradeAsync(enrollmentId: 1, grade: 6.50m);

            // Assert
            Assert.That(resultLow, Is.False);
            Assert.That(resultHigh, Is.False);
        }

        [Test]
        public async Task SetGradeAsync_ReturnsTrue_AndSavesGrade_WhenDataIsValid()
        {
            // Arrange
            var student = new Student
            {
                FirstName = "Ahmed",
                LastName = "Ahmed",
                Email = "ahmedmatem@gmail.com",
                ClassNumber = 1
            };
            var course = new Course
            {
                Name = "C#",
                Description = "C# Programming",
                Credits = 5
            };

            context.Students.Add(student);
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                CourseId = course.Id,
                EnrolledOn = DateTime.UtcNow
            };

            context.Enrollments.Add(enrollment);
            await context.SaveChangesAsync();

            // Act
            var result = await enrollmentService.SetGradeAsync(enrollment.Id, 5.25m);
            var enrollmentInDb = await context.Enrollments.FindAsync(enrollment.Id);

            // Assert
            Assert.That(result, Is.True);            
            Assert.That(enrollmentInDb!.Grade, Is.EqualTo(5.25m));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
