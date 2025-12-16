using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SchoolCourses.Data;
using SchoolCourses.Models.Entities;
using SchoolCourses.Services.Implementations;
using System.Threading.Tasks;
using static SchoolCourses.Tests.InMemoryDbContextFactory;

namespace SchoolCourses.Tests.Services
{
    [TestFixture]
    public class StudentServiceTests
    {
        private SchoolDbContext context = default!;
        private StudentService studentService = default!;

        [SetUp]
        public void Setup()
        {
            // Use db-context factory helper to create in-memory database context.
            // Separate InMemory database context and service for each test.
            context = CreateDbContext();
            // Create an instance of service
            studentService = new StudentService(context);
        }

        [Test]
        public async Task GetAverageGradeAsync_ReturnNull_WhenStudentsHasNoGrades()
        {
            // Arrange            
            var student = new Student()
            {
                FirstName = "Ahmed",
                LastName = "Matem",
                Email = "ahmedmatem@gmail.com",
                ClassNumber = 1,
            };

            // Add student into database over db context
            context.Students.Add(student);
            await context.SaveChangesAsync();

            // Act
            var result = await studentService.GetAverageGradeAsync(student.Id);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetAverageGradeAsync_ReturnsCorrectAverage_WhenStudentHasGrades()
        {
            // Arrange
            var student = new Student()
            {
                FirstName = "Ahmed",
                LastName = "Matem",
                Email = "ahmedmatem@gmail.com",
                ClassNumber = 1,
            };

            // Add student into database over db context
            context.Students.Add(student);
            await context.SaveChangesAsync();

            // Enroll student in several cources
            var enrollment1 = new Enrollment() 
            {
                StudentId = student.Id,
                Course = new Course 
                {
                    Name = "Math"
                    , Description = "Math course", 
                    Credits = 5 
                },
                Grade = 5.50m,
                EnrolledOn = DateTime.UtcNow
            };

            var enrollment2 = new Enrollment
            {
                StudentId = student.Id,
                Course = new Course 
                { 
                    Name = "OOP",
                    Description = "OOP course", 
                    Credits = 6
                },
                Grade = 4.50m,
                EnrolledOn = DateTime.UtcNow
            };

            // Save student enrollments
            context.Enrollments.AddRange(enrollment1, enrollment2);
            await context.SaveChangesAsync();

            // Now we have a student enrolled in two cources with some grades
            // Time to act ...

            // Act
            var result = await studentService.GetAverageGradeAsync(student.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(5.00m).Within(0.001m));
        }

        [Test]
        public async Task GetAllAsync_ReturnsStudentsOrderedByLastNameThenFirstName()
        {
            // Arrange
            var s1 = new Student { FirstName = "Ivan", LastName = "Petrov", Email = "a@a.bg", ClassNumber = 12 };
            var s2 = new Student { FirstName = "Alex", LastName = "Ivanov", Email = "b@b.bg", ClassNumber = 12 };
            var s3 = new Student { FirstName = "Boris", LastName = "Ivanov", Email = "c@c.bg", ClassNumber = 12 };

            // Add students in database
            context.Students.AddRange(s1, s2, s3);
            await context.SaveChangesAsync();

            // Act
            var result = await studentService.GetAllAsync();

            // Assert
            Assert.That(result[0].LastName, Is.EqualTo("Ivanov"));
            Assert.That(result[0].FirstName, Is.EqualTo("Alex"));  // 1. Alex Ivanov
            Assert.That(result[1].LastName, Is.EqualTo("Ivanov"));
            Assert.That(result[1].FirstName, Is.EqualTo("Boris")); // 2. Boris Ivanov
            Assert.That(result[2].LastName, Is.EqualTo("Petrov")); // 3. Ivan Petrov
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
