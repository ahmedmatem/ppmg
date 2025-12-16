using Microsoft.EntityFrameworkCore;
using SchoolCourses.Data;

namespace SchoolCourses.Tests
{
    /// <summary>
    /// Helper db context Factory
    /// </summary>
    public static class InMemoryDbContextFactory
    {
        public static SchoolDbContext CreateDbContext()
        {
            // set options for in-memory use
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase(databaseName: "db_" + Guid.NewGuid().ToString())
                .Options;

            return new SchoolDbContext(options);
        }
    }
}
