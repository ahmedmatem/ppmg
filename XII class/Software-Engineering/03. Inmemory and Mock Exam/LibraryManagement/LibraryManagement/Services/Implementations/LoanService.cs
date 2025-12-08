using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly LibraryDbContext _context;
        private readonly INotificationService _notificationService;

        public LoanService(LibraryDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<bool> CreateLoanAsync(int memberId, int bookId)
        {
            var member = await _context.Members.FindAsync(memberId);
            var book = await _context.Books.FindAsync(bookId);

            if (member == null || book == null)
                return false;

            if (!member.IsActive)
                return false;

            if (book.AvailableCopies <= 0)
                return false;

            var loan = new Loan
            {
                MemberId = memberId,
                BookId = bookId,
                LoanDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(14)
            };

            _context.Loans.Add(loan);
            book.AvailableCopies -= 1;

            await _context.SaveChangesAsync();

            await _notificationService.SendAsync(
                member.Email,
                "Ново заемане на книга",
                $"Заета книга: {book.Title}, срок за връщане: {loan.DueDate:dd.MM.yyyy}");

            return true;
        }

        public async Task<bool> ReturnBookAsync(int loanId)
        {
            var loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(l => l.Id == loanId);

            if (loan == null)
                return false;

            if (loan.ReturnDate.HasValue)
                return false; // вече върната

            loan.ReturnDate = DateTime.UtcNow;
            loan.Book.AvailableCopies += 1;

            await _context.SaveChangesAsync();

            await _notificationService.SendAsync(
                loan.Member.Email,
                "Връщане на книга",
                $"Благодарим ви, че върнахте книгата: {loan.Book.Title}");

            return true;
        }

        public async Task<Loan?> GetLoanAsync(int loanId)
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(l => l.Id == loanId);
        }
    }
}
