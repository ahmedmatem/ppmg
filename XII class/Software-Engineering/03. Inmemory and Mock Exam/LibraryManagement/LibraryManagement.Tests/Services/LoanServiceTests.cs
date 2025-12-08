using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Implementations;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Tests.Services
{
    [TestFixture]
    public class LoanServiceTests
    {
        private DbContextOptions<LibraryDbContext> _dbOptions = null!;
        private Mock<INotificationService> _notificationMock = null!;

        [SetUp]
        public void SetUp()
        {
            _dbOptions = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _notificationMock = new Mock<INotificationService>();
        }

        [Test]
        public async Task CreateLoanAsync_ReturnsFalse_WhenMemberNotActive()
        {
            using var context = new LibraryDbContext(_dbOptions);

            var member = new Member
            {
                FirstName = "Ivo",
                LastName = "Ivanov",
                Email = "ivo@example.com",
                IsActive = false
            };
            var book = new Book
            {
                Title = "C#",
                Author = "Author",
                Isbn = "111",
                TotalCopies = 1,
                AvailableCopies = 1
            };

            context.Members.Add(member);
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var service = new LoanService(context, _notificationMock.Object);

            var result = await service.CreateLoanAsync(member.Id, book.Id);

            Assert.That(result, Is.False);
            _notificationMock.Verify(n => n.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task CreateLoanAsync_ReturnsFalse_WhenNoAvailableCopies()
        {
            using var context = new LibraryDbContext(_dbOptions);

            var member = new Member
            {
                FirstName = "Ana",
                LastName = "Atanasova",
                Email = "ana@example.com",
                IsActive = true
            };
            var book = new Book
            {
                Title = "Java",
                Author = "Author",
                Isbn = "222",
                TotalCopies = 1,
                AvailableCopies = 0
            };

            context.Members.Add(member);
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var service = new LoanService(context, _notificationMock.Object);

            var result = await service.CreateLoanAsync(member.Id, book.Id);

            Assert.That(result, Is.False);
            _notificationMock.Verify(n => n.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task CreateLoanAsync_CreatesLoan_DecrementsAvailableCopies_AndSendsNotification()
        {
            using var context = new LibraryDbContext(_dbOptions);

            var member = new Member
            {
                FirstName = "Bobi",
                LastName = "Borisov",
                Email = "bobi@example.com",
                IsActive = true
            };
            var book = new Book
            {
                Title = "ASP.NET",
                Author = "Author",
                Isbn = "333",
                TotalCopies = 2,
                AvailableCopies = 2
            };

            context.Members.Add(member);
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var service = new LoanService(context, _notificationMock.Object);

            var result = await service.CreateLoanAsync(member.Id, book.Id);

            Assert.That(result, Is.True);

            var loanInDb = await context.Loans
                .FirstOrDefaultAsync(l => l.MemberId == member.Id && l.BookId == book.Id);
            Assert.That(loanInDb, Is.Not.Null);

            var bookInDb = await context.Books.FindAsync(book.Id);
            Assert.That(bookInDb!.AvailableCopies, Is.EqualTo(1));

            _notificationMock.Verify(n =>
                n.SendAsync(
                    member.Email,
                    It.Is<string>(s => s.Contains("Ново заемане")),
                    It.Is<string>(b => b.Contains(book.Title))),
                Times.Once);
        }

        [Test]
        public async Task ReturnBookAsync_ReturnsFalse_WhenLoanNotFound()
        {
            using var context = new LibraryDbContext(_dbOptions);
            var service = new LoanService(context, _notificationMock.Object);

            var result = await service.ReturnBookAsync(999);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ReturnBookAsync_SetsReturnDate_IncrementsAvailableCopies_AndSendsNotification()
        {
            using var context = new LibraryDbContext(_dbOptions);

            var member = new Member
            {
                FirstName = "Geri",
                LastName = "Georgieva",
                Email = "geri@example.com",
                IsActive = true
            };
            var book = new Book
            {
                Title = "Databases",
                Author = "Author",
                Isbn = "444",
                TotalCopies = 1,
                AvailableCopies = 0
            };

            context.Members.Add(member);
            context.Books.Add(book);
            await context.SaveChangesAsync();

            var loan = new Loan
            {
                MemberId = member.Id,
                BookId = book.Id,
                LoanDate = DateTime.UtcNow.AddDays(-5),
                DueDate = DateTime.UtcNow.AddDays(9)
            };

            context.Loans.Add(loan);
            await context.SaveChangesAsync();

            var service = new LoanService(context, _notificationMock.Object);

            var result = await service.ReturnBookAsync(loan.Id);

            Assert.That(result, Is.True);

            var loanInDb = await context.Loans.FindAsync(loan.Id);
            Assert.That(loanInDb!.ReturnDate, Is.Not.Null);

            var bookInDb = await context.Books.FindAsync(book.Id);
            Assert.That(bookInDb!.AvailableCopies, Is.EqualTo(1));

            _notificationMock.Verify(n =>
                n.SendAsync(
                    member.Email,
                    It.Is<string>(s => s.Contains("Връщане")),
                    It.Is<string>(b => b.Contains(book.Title))),
                Times.Once);
        }
    }
}
