using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Implementations;

namespace LibraryManagement.Tests.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        private DbContextOptions<LibraryDbContext> _dbOptions = null!;

        [SetUp]
        public void SetUp()
        {
            _dbOptions = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Test]
        public async Task ChangeAvailableCopiesAsync_ReturnsFalse_WhenBookDoesNotExist()
        {
            using var context = new LibraryDbContext(_dbOptions);
            var service = new BookService(context);

            var result = await service.ChangeAvailableCopiesAsync(999, -1);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ChangeAvailableCopiesAsync_DoesNotAllowNegativeAvailableCopies()
        {
            using var context = new LibraryDbContext(_dbOptions);
            var book = new Book
            {
                Title = "Test",
                Author = "Author",
                Isbn = "123",
                TotalCopies = 3,
                AvailableCopies = 1
            };
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var service = new BookService(context);

            var result = await service.ChangeAvailableCopiesAsync(book.Id, -2);

            Assert.That(result, Is.False);

            var bookInDb = await context.Books.FindAsync(book.Id);
            Assert.That(bookInDb!.AvailableCopies, Is.EqualTo(1));
        }

        [Test]
        public async Task ChangeAvailableCopiesAsync_ChangesCount_WhenValid()
        {
            using var context = new LibraryDbContext(_dbOptions);
            var book = new Book
            {
                Title = "Valid",
                Author = "Author",
                Isbn = "321",
                TotalCopies = 5,
                AvailableCopies = 2
            };
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var service = new BookService(context);

            var result = await service.ChangeAvailableCopiesAsync(book.Id, +1);

            Assert.That(result, Is.True);

            var bookInDb = await context.Books.FindAsync(book.Id);
            Assert.That(bookInDb!.AvailableCopies, Is.EqualTo(3));
        }
    }
}
