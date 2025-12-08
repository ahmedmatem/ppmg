using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books
                .OrderBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Loans)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            if (!await _context.Books.AnyAsync(b => b.Id == book.Id))
                return false;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeAvailableCopiesAsync(int bookId, int delta)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
                return false;

            var newAvailable = book.AvailableCopies + delta;
            if (newAvailable < 0 || newAvailable > book.TotalCopies)
            {
                return false;
            }

            book.AvailableCopies = newAvailable;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
