using LibraryManagement.Models.Entities;

namespace LibraryManagement.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Променя AvailableCopies с подадения delta (може да е отрицателен).
        /// Не позволява AvailableCopies да стане по-малко от 0.
        /// </summary>
        Task<bool> ChangeAvailableCopiesAsync(int bookId, int delta);
    }
}
