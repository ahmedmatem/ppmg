using Microsoft.EntityFrameworkCore;
using SchoolCourses.Data;
using SchoolCourses.Models.Entities;
using SchoolCourses.Services.Implementations;

namespace SchoolCourses.Tests.Services
{
    /// <summary>
    /// Unit tests for CourseService and specifically for the GetStudentsInCourseAsync method.
    /// </summary>
    /// <remarks>
    /// Two main scenarios are covered in this class:
    /// 1. Negative / edge case – course that does not exist.
    /// 2. Checking for number and order of returned students.
    /// </remarks>
    [TestFixture]
    public class CourseServiceTests
    {
        private DbContextOptions<SchoolDbContext> dbOptions = null!;

        [SetUp]
        public void SetUp()
        {
            // New InMemory database for each test
            dbOptions = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task GetStudentsInCourseAsync_ReturnsEmptyList_WhenCourseDoesNotExist()
        {
            // Arrange
            using var context = new SchoolDbContext(dbOptions);

            // We create some students and courses,
            // but we will call the method with an ID that does not exist.
            var course = new Course
            {
                Name = "Math",
                Description = "Math course",
                Credits = 5
            };

            var student = new Student
            {
                FirstName = "Ahmed",
                LastName = "Ahmed",
                Email = "ahmedmatem@gmail.com",
                ClassNumber = 1
            };

            context.Courses.Add(course);
            context.Students.Add(student);
            await context.SaveChangesAsync();

            var service = new CourseService(context);

            int nonExistingCourseId = course.Id + 1000;

            // Act
            var result = await service.GetStudentsInCourseAsync(nonExistingCourseId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetStudentsInCourseAsync_ReturnsStudentsOrderedByLastNameThenFirstName()
        {
            // Arrange
            using var context = new SchoolDbContext(dbOptions);

            var course = new Course
            {
                Name = "Programming",
                Description = "C# and OOP",
                Credits = 6
            };
            context.Courses.Add(course);

            var s1 = new Student
            {
                FirstName = "Boris",
                LastName = "Ivanov",
                Email = "boris@example.com",
                ClassNumber = 1
            };
            var s2 = new Student
            {
                FirstName = "Alex",
                LastName = "Ivanov",
                Email = "alex@gmail.com",
                ClassNumber = 2
            };
            var s3 = new Student
            {
                FirstName = "Ivan",
                LastName = "Petrov",
                Email = "ivan@gmail.com",
                ClassNumber = 3
            };

            context.Students.AddRange(s1, s2, s3);
            await context.SaveChangesAsync();

            // Enroll them in the course
            context.Enrollments.AddRange(
                new Enrollment { StudentId = s1.Id, CourseId = course.Id, EnrolledOn = DateTime.UtcNow },
                new Enrollment { StudentId = s2.Id, CourseId = course.Id, EnrolledOn = DateTime.UtcNow },
                new Enrollment { StudentId = s3.Id, CourseId = course.Id, EnrolledOn = DateTime.UtcNow }
            );
            await context.SaveChangesAsync();

            var service = new CourseService(context);

            // Act
            var result = await service.GetStudentsInCourseAsync(course.Id);

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));

            // Expected order according to the implementation:
            // OrderBy LastName, ThenBy FirstName
            // 1) Alex Ivanov
            // 2) Boris Ivanov
            // 3) Ivan Petrov
            Assert.Multiple(() =>
            {
                Assert.That(result[0].LastName, Is.EqualTo("Ivanov"));
                Assert.That(result[0].FirstName, Is.EqualTo("Alex"));

                Assert.That(result[1].LastName, Is.EqualTo("Ivanov"));
                Assert.That(result[1].FirstName, Is.EqualTo("Boris"));

                Assert.That(result[2].LastName, Is.EqualTo("Petrov"));
                Assert.That(result[2].FirstName, Is.EqualTo("Ivan"));
            });
        }
    }
}
