using LibraryManagement.Models.Entities;

namespace LibraryManagement.Services.Interfaces
{
    public interface ILoanService
    {
        /// <summary>
        /// Създава нов заем, ако има налична бройка и членът е активен.
        /// Връща true при успех, false при неуспех.
        /// </summary>
        Task<bool> CreateLoanAsync(int memberId, int bookId);

        /// <summary>
        /// Отбелязва връщане на книга по даден Loan Id.
        /// </summary>
        Task<bool> ReturnBookAsync(int loanId);

        Task<Loan?> GetLoanAsync(int loanId);
    }
}
