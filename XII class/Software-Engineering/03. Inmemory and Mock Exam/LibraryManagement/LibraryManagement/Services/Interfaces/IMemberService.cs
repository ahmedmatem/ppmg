using LibraryManagement.Models.Entities;

namespace LibraryManagement.Services.Interfaces
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task<Member> CreateAsync(Member member);
        Task<bool> UpdateAsync(Member member);
        Task<bool> DeleteAsync(int id);
    }
}
